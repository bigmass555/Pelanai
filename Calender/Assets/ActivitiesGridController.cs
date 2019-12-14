using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivitiesGridController : MonoBehaviour
{
    public GameObject showList;
    public GameObject activitiesGrid;
    public List<Activity> displayActivity;
    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open_checklist_menu()
    {
        PelanaiData.check_day();
        int toDayInt = Helper.Time.GetintFromDay(DateTime.Now.DayOfWeek.ToString());
        foreach (Activity activity in PelanaiData.activitiesList)
        {
            if (!displayActivity.Contains(activity))
            {
                createShowlist(activity);
            }
        }
        Debug.Log(displayActivity.Count * 200);
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, (230 * displayActivity.Count));
    }
    public void createShowlist(Activity activity)
    {
        displayActivity.Add(activity);
        Showlist showlist = Instantiate(showList, activitiesGrid.transform).GetComponent<Showlist>();
        showlist.set_up(activity);
    }
}
