package com.example.controller;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

import com.example.capstonetest.R;

public class StartActivity extends Activity {
	/* Called when the activity is first created */
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		final Intent next = new Intent(StartActivity.this, BluetoothActivity.class);
		new Handler().postDelayed( new Runnable() {
			
			@Override
			public void run() {
				// 여기에 사전 작업을 해주면 된다. 예를들어 사용자 정보를 받아와 앱에 적용한다던지..
				startActivity(next);

				finish();
			}
		}, 5000) ;
		
	}
}
