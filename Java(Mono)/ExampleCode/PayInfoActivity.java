package com.example.monobank;


import android.graphics.Color;
import android.os.Build;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;

public class PayInfoActivity extends AppCompatActivity {


    TextView card;
    TextView daten;
    TextView Bigprice;
    TextView ostatok;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.payinfoactivity);
        setStatusTransparency();
        Bundle arguments = getIntent().getExtras();
        String name = arguments.get("Name").toString();
        String price = arguments.get("Count").toString();
        String DateN = arguments.get("Date").toString();
        String ostatokS = arguments.get("Ostatok").toString();
        card = findViewById(R.id.cardnumber);
        daten = findViewById(R.id.date);
        Bigprice = findViewById(R.id.BigMoneyDrob);
        ostatok = findViewById(R.id.ostatok);
        daten.setText(DateN);
        boolean isDigits = TextUtils.isDigitsOnly(name);
        char[] chars = name.toCharArray();
        if(isDigits == true){
            chars[8] = '*';
            chars[9] = '*';
            chars[10] = '*';
            chars[11] = '*';
            Log.d("GREEN", chars.toString());
            card.setText(new String(chars));
        }else{
            card.setText(name);
        }
        BigDecimal bd = new BigDecimal(1000000);
        if(price.length() > 3){
            bd = new BigDecimal(price.replaceAll(" ",""));
            DecimalFormatSymbols symbols = DecimalFormatSymbols.getInstance();
            symbols.setGroupingSeparator(' ');
            DecimalFormat df = new DecimalFormat();
            df.setDecimalFormatSymbols(symbols);
            df.setGroupingSize(3);
            df.setMaximumFractionDigits(2);
            price = df.format(bd.longValue());
        }
        if(ostatokS.length() > 3){
            bd = new BigDecimal(ostatokS.replaceAll(" ",""));
            DecimalFormatSymbols symbols = DecimalFormatSymbols.getInstance();
            symbols.setGroupingSeparator(' ');
            DecimalFormat df = new DecimalFormat();
            df.setDecimalFormatSymbols(symbols);
            df.setGroupingSize(3);
            df.setMaximumFractionDigits(2);
            ostatokS = df.format(bd.longValue());
        }
        Bigprice.setText(price);
   /*     ConstraintLayout.LayoutParams params = new ConstraintLayout.LayoutParams(ConstraintLayout.LayoutParams.WRAP_CONTENT, ConstraintLayout.LayoutParams.WRAP_CONTENT);
      //  params.setMargins(10,10,10,10);
        Log.d("PRIE---------", price);
        if (price.length() == 3) {
            params.setMargins(80,0,0,0);
            Bigprice.setLayoutParams(params);
            Bigprice.setText(price);
            Bigprice.layout(80,0,0,0);
        }else if(price.length() == 4){
            params.setMargins(75,0,0,0);
            Bigprice.setLayoutParams(params);
            Bigprice.setText(price);
            Bigprice.layout(75,0,0,0);
        }
        else if(price.length() == 6){
            params.setMargins(60,0,0,0);
            Bigprice.setLayoutParams(params);
            Bigprice.setText(price);
            Bigprice.layout(60,0,0,0);
        }
        else if(price.length() == 7){

            params.setMarginStart(50);
            Bigprice.setLayoutParams(params);
            Bigprice.setText(price);
        }else if(price.length() == 8){
            params.setMarginStart(30);
            Bigprice.setLayoutParams(params);
            Bigprice.setText(price);
        }
        else if(price.length() == 10){
            params.setMarginStart(5);
            Bigprice.setLayoutParams(params);
            Bigprice.setText(price);
        }
*/
        ostatok.setText(ostatokS);

    }
    private void setStatusTransparency() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
            Window window = getWindow();
            window.clearFlags(WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS
                    | WindowManager.LayoutParams.FLAG_TRANSLUCENT_NAVIGATION);
            window.getDecorView().setSystemUiVisibility(View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
                    | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
                    | View.SYSTEM_UI_FLAG_LAYOUT_STABLE);
            window.addFlags(WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS);
            window.setStatusBarColor(Color.TRANSPARENT);
            window.setNavigationBarColor(Color.TRANSPARENT);
        } else if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.KITKAT) {
            Window window = getWindow();
            window.setFlags(WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS,
                    WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
        }
    }
    public void gotomenu(View view){
        onBackPressed();
    }
}