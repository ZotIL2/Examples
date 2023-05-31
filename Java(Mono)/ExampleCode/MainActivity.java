package com.example.monobank;


import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

//import com.example.monobank.databinding.ActivityMainBinding;

import com.example.monobank.db.AppDataBase;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.android.material.bottomsheet.BottomSheetBehavior;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class MainActivity extends AppCompatActivity implements BlankFragment.OnMessageSendListener  {

  //  private ActivityMainBinding binding;
    public String Money = "500";
    ItemAdapter adapter;
    static boolean add = false;
    static boolean startG = false;
    static boolean ActiveOb = true;
    static boolean FormatingN = false;
    static String Ostatok;
    public static  int i =-1;
    BlankFragment2 blankFragment2 = new BlankFragment2();
    BlankFragment blankFragment = new BlankFragment();
    static List<ItemsTransaction> ItemsTransactions = new ArrayList();
    SharedPreferences sPref;
    String day;
    String mouth;

    ImageView obmeg;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

     //   binding = ActivityMainBinding.inflate(getLayoutInflater());
        Date date = new Date();
        setContentView(R.layout.activity_main);
        setStatusTransparency();
        obmeg = findViewById(R.id.Current_restrictions);
        day = String.format("%te", date);
        mouth = String.format("%tm", date);
        switch (mouth){
            case "1":
                mouth = "січня";
                break;
            case "2":
                mouth = "лютого";
                break;
            case "3":
                mouth = "березеня";
                break;
            case "4":
                mouth = "квітня";
                break;
            case "5":
                mouth = "травня";
                break;
            case "6":
                mouth = "червея";
                break;
            case "7":
                mouth = "липня";
                break;
            case "8":
                mouth = "серпня";
                break;
            case "9":
                mouth = "вересня";
                break;
            case "10":
                mouth = "жовтня";
                break;
            case "11":
                mouth = "листопада";
                break;
            case "12":
                mouth = "груденя";
                break;


        }

        //replaceFragment(blankFragment2);
      //  startActivityForResult(new Intent(MainActivity.this,ItemAdapter.class), 100);
        BottomNavigationView bottomNavigationView = findViewById(R.id.bottomNavigationView);
        getSupportFragmentManager().beginTransaction().replace(R.id.constr_l,  blankFragment2).commit();
       // blankFragment2.SetDate(day+mouth);
        bottomNavigationView.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                switch (item.getItemId()){
                    case R.id.home:
                        getSupportFragmentManager().beginTransaction().replace(R.id.constr_l,  blankFragment2).commit();
                        setActiveOb(ActiveOb);
                        break;
                    case R.id.settings:
                        obmeg.setVisibility(View.INVISIBLE);
                        getSupportFragmentManager().beginTransaction().replace(R.id.constr_l,  blankFragment).commit();
                        break;
                }
                return false;
            }
        });

    }




 /*   @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable @androidx.annotation.Nullable Intent data) {
        Log.d("Con", "100");
        if(requestCode == 100){
            loadItemList();
        }


        super.onActivityResult(requestCode, resultCode, data);
    }
*/
    @Override
    protected void onResume() {
        super.onResume();

        Log.d("MyTest11", new Boolean(add).toString());
        blankFragment2.SetDate("Сьогодні");
        Ostatok = blankFragment2.balance.getText().toString();
        if(ItemsTransactions.size() >0 && startG == true) {
            startG = false;
            blankFragment2.SetText(ItemsTransactions.get(0).getCount(),add);
            sPref = getPreferences(MODE_PRIVATE);
            SharedPreferences.Editor  ed = sPref.edit();
            ed.putString("saved_text", blankFragment2.balance.getText().toString());
            ed.commit();
            setItemRecycler();
        }
        setActiveOb(ActiveOb);
    }

    public void setActiveOb(boolean activeOb) {
        if(ActiveOb == true){
            obmeg.setVisibility(View.VISIBLE);
        }
        else{obmeg.setVisibility(View.INVISIBLE);}
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

    public void setItemRecycler() {
        Log.d("MyTest11", "work");
        RecyclerView.LayoutManager layoutManager = new androidx.recyclerview.widget.LinearLayoutManager(MainActivity.this, RecyclerView.VERTICAL, false );
        blankFragment2.recyclerView.setLayoutManager(layoutManager);
        ItemAdapter adapter = new ItemAdapter(MainActivity.this, ItemsTransactions,true);
        blankFragment2.recyclerView.setAdapter(adapter);
    }
    @Override
    public void onMessageSend(String message){
        Money = message;
        Log.d("MyTest1", message);
        blankFragment2.SetText(Money,add);
        sPref = getPreferences(MODE_PRIVATE);
        SharedPreferences.Editor  ed = sPref.edit();
        ed.putString("saved_text", message);
        ed.commit();
    }

    private void replaceFragment(BlankFragment2 fragment){
        FragmentManager fragmentManager = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
        fragmentTransaction.replace(R.id.constr_l,fragment);
        fragmentTransaction.commit();
    }

    public void gotopay(View view) {
        Intent intent = new Intent(this,Gotopay.class);
        startActivity(intent);
    }
}