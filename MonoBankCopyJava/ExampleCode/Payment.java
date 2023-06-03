package com.example.monobank;


import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;

import androidx.appcompat.app.AppCompatActivity;

import java.text.SimpleDateFormat;
import java.util.Date;

public class Payment extends AppCompatActivity {
    EditText NameOrNum, eBalance;
    String months[] = {"січеня", "лютого", "березеня", "квітеня", "травеня", "червня", "липня", "серпня", "вересня",
            "жовтня", "листопада", "грудня"};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_payment);
        eBalance = findViewById(R.id.Balance);
        NameOrNum = findViewById(R.id.Nameornum);
        Bundle arguments = getIntent().getExtras();
        String name = arguments.get("kard").toString();
        NameOrNum.setText(name);

    }


    public void gotomenu1(View view){
        onBackPressed();
    }
    public void addB(View view){
        MainActivity.add = true;
        MainActivity.startG = true;
        Date dateN = new Date();
        String ostatoksave =  String.valueOf(Integer.parseInt(MainActivity.Ostatok.replaceAll(" ","")) + Integer.parseInt(eBalance.getText().toString()));
        int mounth1 =  Integer.parseInt(String.format("%tm", dateN));
        String dateNow = String.format("%te", dateN);
        dateNow += String.format(" %s ",months[mounth1-1]);
        dateNow += String.format("%1$tY, %1$tR", dateN);
        MainActivity.ItemsTransactions.add(0,new ItemsTransaction(NameOrNum.getText().toString(), eBalance.getText().toString().replaceAll("-"," "), "refill", "Поповнення картки", true,dateNow,ostatoksave));
        // Collections.reverse(MainActivity.items);
        finish();
//        Intent intent = new Intent(this, MainActivity.class);
//        startActivity(intent);
        //onBackPressed();
    }

    public void send(View view){
        MainActivity.startG = true;
        MainActivity.add = false;
        Date dateN = new Date();
        int mounth1 =  Integer.parseInt(String.format("%tm", dateN));
        String dateNow = String.format("%te ", dateN);
        dateNow += String.format("%s",months[mounth1-1]);
        dateNow += String.format(" %1$tY, %1$tR", dateN);
        Log.d("DATE:", dateNow);
        String ostatoksave =  String.valueOf(Integer.parseInt(MainActivity.Ostatok.replaceAll(" ","")) - Integer.parseInt(eBalance.getText().toString()));
        MainActivity.ItemsTransactions.add(0,new ItemsTransaction(NameOrNum.getText().toString(), "-"+eBalance.getText().toString(), "transfer", "Переказ на картку", false, dateNow,ostatoksave));
     //   Collections.reverse(MainActivity.items);
//        Intent intent = new Intent(this, MainActivity.class);
//        startActivity(intent);
        //onBackPressed();
        finish();
//        EditText Bal = findViewById(R.id.Balance);
//        Intent intent = new Intent(this,BlankFragment2.class);
//        intent.putExtra("Bal",Bal.getText().toString());
//        startActivity(intent);
//        Log.d("gfgf", "!!!!!!!!!!!!!!!!FBBBBF");

      //  BlankFragment2 fragInfo = new BlankFragment2();
       // FragmentManager transaction = getSupportFragmentManager();
//        Bundle bundle = new Bundle();
//        bundle.putString("Balance", Bal.getText().toString() );
//        fragInfo.setArguments(bundle);
      //  transaction.beginTransaction().replace(R.id.constr_l,  fragInfo).commit();

    }
}