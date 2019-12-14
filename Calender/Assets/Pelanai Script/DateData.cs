using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class DateData
{
    public DateTime date;
    public List<Activity> activitieslist = new List<Activity>();
    public int rate = 0;
    public DateData(List<Activity> activitieslistInput, DateTime date)
    {
        activitieslist = activitieslistInput;
        int calRate = 0;
        
        foreach (Activity activity in activitieslist)
        {
            if (activity.days.Contains(Helper.Time.GetintFromDay(date.DayOfWeek.ToString())))
            {
                if (activity.compeleted == false)
                {
                    calRate = -1;
                    break;
                }
                else
                {
                    calRate = 1;
                }
            }
        }
        rate = calRate;
    }
}
