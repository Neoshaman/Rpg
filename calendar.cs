using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calendar : MonoBehaviour {

	//24 mn, 1mn = 1h

	//3 tiers:
	//moonlight/daylight: 12h each
	//sunrise/day/sunset/twilight: 6h each
	//dawn/morning/afternoon/mid afternoon/dusk/evening/midnight/small hours: 3h each

	//base routine: (bed table desk)
	//6h - wake up/breakfast (bed, table)
	//9h - begining work (desk)
	//12h - lunch break (table)
	//18h - going home/dinner (table)
	//21h - sleeping (bed)

	//each update, increment overall time, mod time and output tiers with percent completion

	//newTime = time.now
	//intervalTime = newTime - oldTime
	//oldTime = newTime
	//gametime += intervalTime
	public float deltatime, unscaleddeltatime, basetick;//time in second fraction
	public int milisecond, second, minute, hour, day, week, month, years;
	public int gamesecond, gameminute, gamehour, gameday, gameweek, gamemonth, gameyears;
	public int displaygamesecond, displaygameminute, displaygamehour, displaygameday, displaygameweek, displaygamemonth, displaygameyears;

	void Start(){
		basetick = 350;
	}

	void Update(){
		deltatime = Time.deltaTime;
		unscaleddeltatime = Time.unscaledDeltaTime;

		//TODO: make code to pause the basetick
		basetick += deltatime;

		//real time
		//TODO: should separate incrementation from basetick past the minutes, to avoid float precision
		//ie reset the basetick after some cycle.

		milisecond = (int) (basetick  * 1000f);
		second = (int) basetick;
		minute = second / 60; 
		hour = minute / 60; 
		day = hour / 24;
		week = day / 7;
		//month = week / 4; //need complex

		//game time
		gameminute = second;
		gamehour = minute;
		gameday = gamehour / 24;
		gameweek = gameday / 7;

		//display time SHOULD BE FLOAT for interpolation
		displaygameminute = gameminute % 60;
		displaygamehour = gamehour % 24;
		displaygameday = gameday % 7;

	}

}
