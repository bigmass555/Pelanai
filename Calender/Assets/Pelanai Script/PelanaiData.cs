using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PelanaiData : MonoBehaviour
{
    public static string playerName;
    public static float playerScore;
    public static List<Activity> activitiesList = new List<Activity>();
    public static Dictionary<DateTime, DateData> dateDataDict = new Dictionary<DateTime, DateData>();
    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        set_up_data();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void set_up_data()
    {

    }
    private void OnApplicationQuit()
    {
        DateData dateData = new DateData();
        dateData.set_data(activitiesList);
        dateDataDict[DateTime.Now] = dateData;
        SaveGame();
    }
    void SaveGame()
    {
        SaveSystem.save(this);
    }
    void LoadGame()
    {
        SaveData saveData = SaveSystem.load();
        if (saveData != null)
        {
            playerName = saveData.playerName;
            playerScore = saveData.playerScore;
            activitiesList = saveData.activitiesList;
            dateDataDict = saveData.dateDataDict;
        }
    }
}
