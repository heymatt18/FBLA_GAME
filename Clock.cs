using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
using System;
 using UnityEngine.UI;

public class Clock : MonoBehaviour {
    public Text timerText;
    private float startTime;
    private string DayNight = "AM";
    private bool AmPm = true; //if its true its AM if false its PM

    void Start()
    {
       startTime = Time.time;
    }

     void Update()
    { 
      float t = Time.time - startTime;
        
      string hours = (((int)t / 60) + 11).ToString();
      string mins = (t % 60).ToString("f0");

      string millis = (t % 60).ToString("f2");

        if (hours == "13")//changes 12 back to one after 12:59
        {
            hours = ((int)t / 60).ToString();
        }

            if (Convert.ToInt32(hours) == 12 && Convert.ToDouble(millis) == 0.00) //AM and PM system
            {
                if (AmPm == true)
                {
                    AmPm = false;
                    DayNight = "PM";
                }
                else
                {
                    AmPm = true;
                    DayNight = "AM";
                }
            }

        if (Convert.ToInt32(mins) < 10)
        {
            timerText.text = hours + ":0" + mins + " " + DayNight;
        }
        else
            timerText.text = hours + ":" + mins + " " + DayNight;
    }
 		
 }