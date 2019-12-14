using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PelanaiData : MonoBehaviour
{
    public static string playerName;
    public static float playerScore = 0;
    public static DateTime lastLogin;
    public static DateTime firstTimeLogin;
    public static List<Activity> activitiesList = new List<Activity>();
    public static Dictionary<string, DateData> dateDataDict = new Dictionary<string, DateData>();

    public ProfileBar profileBar;
    public static bool notification = false;
    public static int notificationHour;
    public static int notificationMinute;


    //Not Save
    public static int dayStreak;
    public static float expBonus;

    public int resetSave;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("resetSave"))
        {
            resetSave = PlayerPrefs.GetInt("resetSave");
        }
        else
        {
            resetSave = 0;
        }
        LoadGame();
        set_up_data();
        Debug.Log(dateDataDict.Count.ToString() + " dateDataDict Count");
        Debug.Log(activitiesList.Count.ToString() + " activitiesList Count");
        dayStreak = cal_streak();
    }
    void Start()
    {
        Debug.Log(notification);
    }
    public static void set_up_data()
    {

    }
    public static void check_day()
    {
        if (lastLogin != DateTime.Now.Date)
        {
            reset_activitiesList();
            Debug.Log("Reset Activities Data");
        }
        lastLogin = DateTime.Now.Date;
    }
    public static void reset_activitiesList()
    {
        foreach(Activity activity in activitiesList)
        {
            activity.compeleted = false;
        }
    }
    private void OnApplicationQuit()
    {
        DateData dateData = new DateData(activitiesList, DateTime.Now.Date);
        dateDataDict[DateTime.Now.Date.ToString("MM/dd/yyyy")] = dateData;
        SaveGame();
    }
    void SaveGame()
    {
        SaveSystem.save(this);
    }
    public static void addScore(float num)
    {
        playerScore += num;
        Debug.Log(playerScore);
    }
    void LoadGame()
    {
        SaveData saveData = SaveSystem.load();
        Debug.Log(resetSave);
        if (resetSave == 1)
        {
            saveData = null;
            Debug.Log("Load Null");
            resetSave = 0;
        }
        PlayerPrefs.SetInt("resetSave", 0);
        if (saveData != null)
        {
            playerName = saveData.playerName;
            playerScore = saveData.playerScore;
            lastLogin = saveData.lastlogin;
            firstTimeLogin = saveData.firstTimeLogin;
            activitiesList = saveData.activitiesList;
            dateDataDict = saveData.dateDataDict;
            notification = saveData.notification;
            notificationHour = saveData.notificationHour;
            notificationMinute = saveData.notificationMinute;
        }
        else
        {
            firstTimeLogin = DateTime.Now.Date;
            Debug.Log("No save First Time Login");
            dateDataDict = new Dictionary<string, DateData>();
        }
        if (firstTimeLogin == null)
            firstTimeLogin = DateTime.Now.Date;
    }
    int cal_streak()
    {
        int streak = 0;
        DateTime calDate = DateTime.Now.Date;
        calDate = calDate.AddDays(-1);
        string calDateKey = calDate.ToString("MM/dd/yyyy");

        while (dateDataDict.ContainsKey(calDateKey))
        {
            if (dateDataDict[calDateKey].rate == 1)
                streak += 1;
            else if (dateDataDict[calDateKey].rate == 0 || dateDataDict[calDateKey].rate == -1)
                break;
            calDate = calDate.AddDays(-1);
            calDateKey = calDate.ToString("MM/dd/yyyy");
        }
        expBonus = Mathf.Clamp((1 + streak * 0.1f), 1, 2);
        return streak;
    }

    public void setreset()
    {
        PlayerPrefs.SetInt("resetSave", 1);
        Application.Quit();
        Debug.Log("Quit");
    }
}
