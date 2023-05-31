#include <ESP8266WiFi.h>
#include "stDHT.h"
#include <PubSubClient.h>
const char* ssid = "Home_W"; //SmartSocket
const char* password = "0996417703";//Socket2442
const char* mqtt_server = "soldier.cloudmqtt.com";
const char* mqtt_login = "suobrmsd";                        
const char* mqtt_password = "Ho-0iwkOlUnd";  
#define mqtt_port 18319
#define mqtt_topic "test/logicSocket" 
WiFiClient espClient;
unsigned long readTime;
PubSubClient client(espClient);
time_t pctime = 0;
bool signaloff = true;
DHT sens(DHT11);
float temp;
float hum;  
char tempandhum[5];
int count = 1;
char tempandhum1[5];
void setup_wifi() {
  delay(10);
  // We start by connecting to a WiFi network
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived [");
  Serial.print(topic);                              // отправляем в монитор порта название топика                     
  Serial.print("] ");
  for (int i = 0; i < length; i++) {                // отправляем данные из топика
    Serial.print((char)payload[i]);
  }
  Serial.println(); 
  int systval =(int)payload[0]; // 48 = 0 и 49 = 1
    Serial.println(systval);
   if (systval == 48){
   digitalWrite( D2, LOW );
   Serial.println("off");
   count = 2;  
    }
    if (systval == 49){
     digitalWrite(D2, HIGH ); 
     Serial.println("on");    
    }
 
}
                                                // подключение к mqtt брокеру            
void reconnect() {                                                      
  while (!client.connected()) {                       // крутимся пока не подключемся.
    Serial.print("Attempting MQTT connection...");
                                                      // создаем случайный идентификатор клиента
    String clientId = "ESP8266Client-";
    clientId += String(random(0xffff), HEX);
                                                      // подключаемся, в client.connect передаем ID, логин и пасс
    if (client.connect(clientId.c_str(), mqtt_login, mqtt_password)) {
      Serial.println("connected");                    // если подключились 
      client.subscribe(mqtt_topic);                   // подписываемся на топик, в который же пишем данные
    } else {                                          // иначе ругаемся в монитор порта  
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}

void setup() {
   Serial.begin(115200);
  client.subscribe(mqtt_topic);
   pinMode(D2, OUTPUT); // реле
     digitalWrite(D2, LOW);
      pinMode(2, INPUT);
  digitalWrite(2, HIGH);
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);
}

void loop() {
   if (!client.connected()) {
     reconnect();  
  }
  client.loop();
  if(count == 1){ // это баг если розетка включена вначале
       digitalWrite( D2, LOW );
      }
  if(millis() > readTime+10000){
sensorRead();

}
  
}

void sensorRead(){
  readTime = millis();
 float temp = sens.readTemperature(D1); // чтение датчика на пине 2
  int hum = sens.readHumidity(D1);
  dtostrf(temp,0, 0, tempandhum);
 dtostrf(hum,0, 0, tempandhum1);
  client.publish("test/feedback",tempandhum);
  client.publish("test/feedback1",tempandhum1);
}
