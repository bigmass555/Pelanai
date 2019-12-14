using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Assets.SimpleAndroidNotifications;

public class NotificationController : MonoBehaviour
{
    public TMP_InputField hourInputField;
    public TMP_InputField minuteInputField;
    public TextMeshProUGUI invalidText;
    public Toggle toggle;
    public int hour = 0;
    public int minute = 0;
    // Start is called before the first frame update
    void Start()
    {
        toggle.isOn = PelanaiData.notification;
        hourInputField.text = PelanaiData.notificationHour.ToString();
        minuteInputField.text = PelanaiData.notificationMinute.ToString();
        hour = int.Parse(hourInputField.text);
        minute = int.Parse(minuteInputField.text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void notification_set()
    {
        PelanaiData.notification = toggle.isOn;
        if (int.Parse(hourInputField.text) > 23 || int.Parse(minuteInputField.text) > 59)
        {
            invalid_show();
        }
        else
        {
            hour = int.Parse(hourInputField.text);
            minute = int.Parse(minuteInputField.text);
            Debug.Log(hour);
            Debug.Log(minute);
            PelanaiData.notificationHour = hour;
            PelanaiData.notificationMinute = minute;
            invalidText.text = "Settings Confirmed.";
        }
    }
    void invalid_show()
    {
        invalidText.text = "Invalid time input.";
        Debug.Log("Invalid Time INput");
    }
    public void OnApplicationPause(bool isPause)
    {
        if (PelanaiData.notification)
        {
            Debug.Log("Notification On");
            DateTime dateTimeNow = DateTime.Now;
            Debug.Log(hour.ToString() + "hour");
            DateTime newtime = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day, hour, minute, 0);
            Debug.Log(newtime.ToString() + " newtime");
            TimeSpan delay = newtime - dateTimeNow;
            NotificationManager.CancelAll();
            if (isPause)
            {
                for (int i = 0; i < 7; i++)
                {
                    Debug.Log(delay);
                    int toDayInt = Helper.Time.GetintFromDay(newtime.DayOfWeek.ToString());
                    int activitiesNum = 0;
                    foreach (Activity activity in PelanaiData.activitiesList)
                    {
                        if (activity.days.Contains(toDayInt))
                        {
                            activitiesNum += 1;
                        }
                    }
                    if (activitiesNum != 0)
                    {
                        string detail = "You have " + activitiesNum.ToString() + " activities to do today.";
                        NotificationManager.SendWithAppIcon(delay, "You have somthing to do.", detail, Color.cyan, NotificationIcon.Bell);
                    }
                    newtime = newtime.AddDays(1);
                    delay = newtime - dateTimeNow;
                }

            }
        }
    }
    private void OnApplicationQuit()
    {
        Debug.Log("notifications Quit");
        if (PelanaiData.notification)
        {
            Debug.Log("Notification On");
            DateTime dateTimeNow = DateTime.Now;
            Debug.Log(hour.ToString() + "hour");
            DateTime newtime = new DateTime(dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day, hour, minute, 0);
            Debug.Log(newtime.ToString() + " newtime");
            TimeSpan delay = newtime - dateTimeNow;
            NotificationManager.CancelAll();
            if (true)
            {
                for (int i = 0; i < 7; i++)
                {
                    Debug.Log(delay);
                    int toDayInt = Helper.Time.GetintFromDay(newtime.DayOfWeek.ToString());
                    int activitiesNum = 0;
                    foreach (Activity activity in PelanaiData.activitiesList)
                    {
                        if (activity.days.Contains(toDayInt))
                        {
                            activitiesNum += 1;
                        }
                    }
                    if (activitiesNum != 0)
                    {
                        string detail = "You have " + activitiesNum.ToString() + " activities to do today.";
                        Debug.Log(detail);
                        NotificationManager.SendWithAppIcon(delay, "You have somthing to do.", detail, Color.cyan, NotificationIcon.Bell);
                    }
                    newtime = newtime.AddDays(1);
                    delay = newtime - dateTimeNow;
                }

            }
        }
    }
}
