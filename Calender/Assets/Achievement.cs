using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Achievement : MonoBehaviour
{
    public int streak;
    public int level;
    public TimeSpan timeInservice;
    public GameObject achievementGrid;
    public AchieveList[] achieveLists; 
    // Start is called before the first frame update
    void Start()
    {
        streak = PelanaiData.dayStreak;
        level = Mathf.FloorToInt(PelanaiData.playerScore / 2500);
        achieveLists = achievementGrid.GetComponentsInChildren<AchieveList>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void achievecheck() 
    {
        timeInservice = PelanaiData.lastLogin - PelanaiData.firstTimeLogin;
        achieveLists[0].fillbar.fillAmount = streak / 5;
        achieveLists[0].percentText.text = Mathf.FloorToInt(achieveLists[0].fillbar.fillAmount * 100).ToString() + "%";

        achieveLists[1].fillbar.fillAmount = streak / 10;
        achieveLists[1].percentText.text = Mathf.FloorToInt(achieveLists[1].fillbar.fillAmount * 100).ToString() + "%";

        achieveLists[2].fillbar.fillAmount = streak / 20;
        achieveLists[2].percentText.text = Mathf.FloorToInt(achieveLists[2].fillbar.fillAmount * 100).ToString() + "%";

        achieveLists[3].fillbar.fillAmount = int.Parse(timeInservice.TotalHours.ToString()) / 24;
        achieveLists[3].percentText.text = Mathf.FloorToInt(achieveLists[3].fillbar.fillAmount * 100).ToString() + "%";

        achieveLists[4].fillbar.fillAmount = int.Parse(timeInservice.TotalDays.ToString()) / 7;
        achieveLists[4].percentText.text = Mathf.FloorToInt(achieveLists[4].fillbar.fillAmount * 100).ToString() + "%";

        achieveLists[5].fillbar.fillAmount = int.Parse(timeInservice.TotalDays.ToString()) / 30;
        achieveLists[5].percentText.text = Mathf.FloorToInt(achieveLists[5].fillbar.fillAmount * 100).ToString() + "%";

        achieveLists[6].fillbar.fillAmount = int.Parse(timeInservice.TotalDays.ToString()) / 365;
        achieveLists[6].percentText.text = Mathf.FloorToInt(achieveLists[6].fillbar.fillAmount * 100).ToString() + "%";

        achieveLists[7].fillbar.fillAmount = level / 10;
        achieveLists[7].percentText.text = Mathf.FloorToInt(achieveLists[7].fillbar.fillAmount * 100).ToString() + "%";

        achieveLists[8].fillbar.fillAmount = level / 100;
        achieveLists[8].percentText.text = Mathf.FloorToInt(achieveLists[8].fillbar.fillAmount * 100).ToString() + "%";
    }
}
