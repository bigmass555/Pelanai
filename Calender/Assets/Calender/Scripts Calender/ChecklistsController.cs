using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChecklistsController : MonoBehaviour
{
    public GameObject checker;
    public GameObject checklistGrid;
    public List<Activity> displayActivity;
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
        int toDayInt = Helper.Time.GetintFromDay(DateTime.Now.DayOfWeek.ToString());
        foreach (Activity activity in PelanaiData.activitiesList)
        {
            if (activity.days.Contains(toDayInt) && !displayActivity.Contains(activity))
            {
                displayActivity.Add(activity);
                Checklist checklist = Instantiate(checker, checklistGrid.transform).GetComponent<Checklist>();
                checklist.set_up(activity);
            }
        } 
    }
}
