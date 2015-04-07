package com.example.controller;

import com.example.capstonetest.R;

import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Matrix;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.os.Bundle;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnTouchListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ImageView.ScaleType;
import android.widget.SeekBar;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class ControllerActivity extends Activity {
	
	SensorManager sensormanager;
	SensorEventListener acc; 	
	Sensor accSensor;
	TextView x,y,z;
	
	private static final int P = 0;
	private static final int GEAR_R = 1;
	private static final int N = 2;
	private static final int D = 3;
	private static final int TWO = 4;
	private static final int ONE = 5;	
	
	
	private int mode = 0;
	private float start_Y;
		
	ImageButton gear;
	ImageButton accel_pedal;
	ImageButton break_pedal;
	
	////////////////////////////////////////////////////////
	
	ImageView imageView;
	Spinner spinnerScale;
	SeekBar seekbarRotate;
	SeekBar seekbarSkewX, seekbarSkewY;
	TextView textRotate, textSkewX, textSkewY;

	private static final String[] strScale = { "0.2x", "0.5x", "1.0x", "2.0x",
			"5.0x" };
	private static final Float[] floatScale = { 0.2F, 0.5F, 1F, 2F, 5F };
	private final int defaultSpinnerScaleSelection = 2;

	private ArrayAdapter<String> adapterScale;

	private float curScale = 1F;
	private float curRotate = 0F;
	private float curSkewX = 0F;
	private float curSkewY = 0F;

	Bitmap bitmap;
	int bmpWidth, bmpHeight;
	
	
	////////////////////////////////////////////////////////
	
	
	/* Called when the activity is first created */
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.controller_activity);
		////////////////////////////////////////////////////////
		
		sensormanager = (SensorManager)getSystemService(SENSOR_SERVICE);
		accSensor = sensormanager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER);
		
		acc = new accListener();
		
		x = (TextView) findViewById(R.id.x);
		y = (TextView) findViewById(R.id.y);
		z = (TextView) findViewById(R.id.z);
		
		
		//imageView = (ImageView) findViewById(R.id.imageview);
		 
        spinnerScale = (Spinner) findViewById(R.id.scale);
        seekbarRotate = (SeekBar) findViewById(R.id.rotate);
        seekbarSkewX = (SeekBar) findViewById(R.id.skewx);
        seekbarSkewY = (SeekBar) findViewById(R.id.skewy);
         
        spinnerScale.setOnItemSelectedListener(spinScaleOnItemSelectedListener);
        seekbarRotate.setOnSeekBarChangeListener(seekbarRotateChangeListener);
        seekbarSkewX.setOnSeekBarChangeListener(seekbarSkewXChangeListener);
        seekbarSkewY.setOnSeekBarChangeListener(seekbarSkewYChangeListener);
         
        textRotate = (TextView) findViewById(R.id.textrotate);
        textSkewX = (TextView) findViewById(R.id.textskewx);
        textSkewY = (TextView) findViewById(R.id.textskewy);
         
        adapterScale = new ArrayAdapter<String>(this, 
                android.R.layout.simple_spinner_item, strScale);
        adapterScale.setDropDownViewResource(
                android.R.layout.simple_spinner_dropdown_item);
        spinnerScale.setAdapter(adapterScale);
        spinnerScale.setSelection(defaultSpinnerScaleSelection);
        curScale = floatScale[defaultSpinnerScaleSelection];
 
        //bitmap = BitmapFactory.decodeFile(imageSdCard);
        bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.accel_pedal);
        bmpWidth = bitmap.getWidth();
        bmpHeight = bitmap.getHeight();

        
		//////////////////////////////////////////////////////////
		
		gear = ( ImageButton ) findViewById(R.id.Gear_P);
		accel_pedal = ( ImageButton ) findViewById(R.id.Accel_Pedal);
		break_pedal = ( ImageButton ) findViewById(R.id.Break_Pedal);
		
		accel_pedal.setImageBitmap( bitmap );
		accel_pedal.setScaleType( ScaleType.FIT_CENTER );
				
		gear.setOnTouchListener( new OnTouchListener() {
			
			@Override
			public boolean onTouch(View v, MotionEvent event) {
				
				if ( event.getAction() == MotionEvent.ACTION_DOWN ) {
					//if ( start_yn ) {
						start_Y = event.getRawY();
					//}
					
				} else if (event.getAction() == MotionEvent.ACTION_UP ) {
					// 아래로 드래그
					if ( start_Y < event.getRawY() ) {
						Log.d("down", "DOWN!!!");		
						mode++;						
						// 5를 초과하는 기어는 없다.
						if( mode > 5 )
							mode--;

						Log.d("start_Y, getRawY", start_Y + ", " + event.getRawY() );
						Log.d("mode", mode+"");
					} else { // 위로 드래그
						Log.d("up", "UP");
						mode--;
						// 0 미만의 기어는 없다.
						if( mode < 0 )
							mode++;

						Log.d("start_Y, getRawY", start_Y + ", " + event.getRawY() );
						Log.d("mode", mode+"");
					}					
				} 
				
				/* 왜 스위치는 안되는 것인가
				switch( mode ) {
				case P : gear.setImageResource(R.drawable.gear_p);
				case GEAR_R : gear.setImageResource(R.drawable.gear_r);
				case N : gear.setImageResource(R.drawable.gear_n);
				case D : gear.setImageResource(R.drawable.gear_d);
				case TWO : gear.setImageResource(R.drawable.gear_2);
				case ONE : gear.setImageResource(R.drawable.gear_1);
				default : gear.setImageResource(R.drawable.gear_p);				
				}
				*/
				if ( mode == P )
					gear.setImageResource(R.drawable.gear_p);
				else if ( mode == GEAR_R )
					gear.setImageResource(R.drawable.gear_r);
				else if ( mode == N )
					gear.setImageResource(R.drawable.gear_n);
				else if ( mode == D )
					gear.setImageResource(R.drawable.gear_d);
				else if ( mode == TWO )
					gear.setImageResource(R.drawable.gear_2);
				else if ( mode == ONE )
					gear.setImageResource(R.drawable.gear_1);
				
				return false;
			}
		});
		
		
		accel_pedal.setOnClickListener( new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// accel pedal 조작 부분
				Toast.makeText(getApplicationContext(), "Accel 조작!!", Toast.LENGTH_SHORT).show();
			}
		});
			
		
		break_pedal.setOnClickListener( new OnClickListener() {
			
			@Override
			public void onClick(View v) { 
				// break pedal 조작 부분
				Toast.makeText(getApplicationContext(), "Break 조작!!", Toast.LENGTH_SHORT).show();
			}
		});
		 
        drawMatrix();			
	}

	public void onResume(){
		super.onResume();
		
		sensormanager.registerListener(acc, accSensor, SensorManager.SENSOR_DELAY_GAME);
	}
	
	public void onPause(){
		super.onPause();
		sensormanager.unregisterListener(acc);
	}
	
	private class accListener implements SensorEventListener{
		public void onSensorChanged(SensorEvent event){
			x.setText(Float.toString(event.values[0]));
			y.setText(Float.toString(event.values[1]));
			z.setText(Float.toString(event.values[2]));
		}
		
		public void onAccuracyChanged(Sensor sensor, int accuracy){
			
		}
	}
	private void drawMatrix() {

		Matrix matrix = new Matrix();
		matrix.postScale(curScale, curScale);
		matrix.postRotate(curRotate);
		matrix.postSkew(curSkewX, curSkewY);

		Bitmap resizedBitmap = Bitmap.createBitmap(bitmap, 0, 0, bmpWidth,
				bmpHeight, matrix, true);
		accel_pedal.setImageBitmap(resizedBitmap);

	}

	private SeekBar.OnSeekBarChangeListener seekbarSkewYChangeListener = new SeekBar.OnSeekBarChangeListener() {

		public void onStopTrackingTouch(SeekBar seekBar) {
		}

		public void onStartTrackingTouch(SeekBar seekBar) {
		}

		public void onProgressChanged(SeekBar seekBar, int progress,
				boolean fromUser) {
			curSkewY = (float) (progress - 100) / 100;
			textSkewY.setText("Skew-Y: " + String.valueOf(curSkewY));
			drawMatrix();
		}
	};

	private SeekBar.OnSeekBarChangeListener seekbarSkewXChangeListener = new SeekBar.OnSeekBarChangeListener() {

		public void onProgressChanged(SeekBar seekBar, int progress,
				boolean fromUser) {
			curSkewX = (float) (progress - 100) / 100;
			textSkewX.setText("Skew-X: " + String.valueOf(curSkewX));
			drawMatrix();
		}

		public void onStartTrackingTouch(SeekBar seekBar) {
		}

		public void onStopTrackingTouch(SeekBar seekBar) {
		}
	};

	private SeekBar.OnSeekBarChangeListener seekbarRotateChangeListener = new SeekBar.OnSeekBarChangeListener() {

		public void onProgressChanged(SeekBar seekBar, int progress,
				boolean fromUser) {
			curRotate = (float) progress;
			textRotate.setText("Rotate : " + String.valueOf(curRotate));
			drawMatrix();
		}

		public void onStartTrackingTouch(SeekBar seekBar) {
		}

		public void onStopTrackingTouch(SeekBar seekBar) {
		}
	};

	private Spinner.OnItemSelectedListener spinScaleOnItemSelectedListener = new Spinner.OnItemSelectedListener() {

		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2,
				long arg3) {
			curScale = floatScale[arg2];
			drawMatrix();
		}

		public void onNothingSelected(AdapterView<?> arg0) {
			spinnerScale.setSelection(defaultSpinnerScaleSelection);
			curScale = floatScale[defaultSpinnerScaleSelection];
		}
	};
}
