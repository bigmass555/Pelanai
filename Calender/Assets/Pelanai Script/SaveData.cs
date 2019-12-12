using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public string playerName;
    public float playerScore;
    public List<Activity> activitiesList = new List<Activity>();
    public Dictionary<DateTime, DateData> dateDataDict = new Dictionary<DateTime, DateData>();
    public SaveData()
    {
        playerName = PelanaiData.playerName;
        playerScore = PelanaiData.playerScore;
        activitiesList = PelanaiData.activitiesList;
        dateDataDict = PelanaiData.dateDataDict;
    }
}
