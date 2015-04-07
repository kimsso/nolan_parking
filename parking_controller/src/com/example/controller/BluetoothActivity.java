package com.example.controller;

import com.example.capstonetest.R;

import android.R.color;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.widget.TextView;

public class BluetoothActivity extends Activity {
	/* Called when the activity is first created */
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.bluetooth_activity);
        
		final TextView tv = ( TextView ) findViewById(R.id.TextView02);
		
		final Intent next = new Intent(BluetoothActivity.this, ControllerActivity.class);
		new Handler().postDelayed( new Runnable() {
			
			@Override
			public void run() {
				// ���⿡ ���� �۾��� ���ָ� �ȴ�. ������� ����� ������ �޾ƿ� �ۿ� �����Ѵٴ���..
				startActivity(next);

				finish();
			}
		}, 1000) ;
	}
}
