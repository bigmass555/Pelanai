using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public string playerName;
    public float playerScore;
    public DateTime lastlogin;
    public DateTime firstTimeLogin;
    public List<Activity> activitiesList = new List<Activity>();
    public Dictionary<string, DateData> dateDataDict = new Dictionary<string, DateData>();
    public bool notification;
    public int notificationHour;
    public int notificationMinute;
    public SaveData()
    {
        playerName = PelanaiData.playerName;
        playerScore = PelanaiData.playerScore;
        lastlogin = PelanaiData.lastLogin;
        firstTimeLogin = PelanaiData.firstTimeLogin;
        activitiesList = PelanaiData.activitiesList;
        dateDataDict = PelanaiData.dateDataDict;
        notification = PelanaiData.notification;
        notificationHour = PelanaiData.notificationHour;
        notificationMinute = PelanaiData.notificationMinute;
    }
}
