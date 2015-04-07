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
				// ���⿡ ���� �۾��� ���ָ� �ȴ�. ������� ����� ������ �޾ƿ� �ۿ� �����Ѵٴ���..
				startActivity(next);

				finish();
			}
		}, 5000) ;
		
	}
}
