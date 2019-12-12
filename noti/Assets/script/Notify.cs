using Assets.SimpleAndroidNotifications;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notify : MonoBehaviour
{
    private string title = "Notification Title";

    private string content = "Notification Content";

    public InputField min_input;
    
    public int num;
    
    public int num1;


    public String month = DateTime.Now.Month.ToString();

    DateTime aaa;



    public void OnApplicationPause(bool isPause)
    {

        NotificationManager.CancelAll();
        if(isPause)
        {

            DateTime timeToNotify = DateTime.Now.AddMinutes(1);
            TimeSpan time = timeToNotify - DateTime.Now;
            NotificationManager.SendWithAppIcon(time, title, content, Color.blue, NotificationIcon.Bell);
        }
    }
    public void pum()
    {
        num = int.Parse(min_input.text);
        Debug.Log(month);
        content = num.ToString();
        DateTime timeToNotify = DateTime.Now.AddMinutes(0);
        TimeSpan time = timeToNotify - DateTime.Now;
        NotificationManager.SendWithAppIcon(time, title, content, Color.blue, NotificationIcon.Bell);
        aaa = new DateTime(2020, 2, 5, 8, 36, 44);
        Debug.Log(aaa);

    }
}
