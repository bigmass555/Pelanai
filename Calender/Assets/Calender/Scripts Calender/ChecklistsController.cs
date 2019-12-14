using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChecklistsController : MonoBehaviour
{
    public GameObject checker;
    public GameObject checklistGrid;
    public ProfileBar profileBar;
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
            if (activity.days.Contains(toDayInt) && !displayActivity.Contains(activity))
            {
                displayActivity.Add(activity);
                Checklist checklist = Instantiate(checker, checklistGrid.transform).GetComponent<Checklist>();
                checklist.set_up(activity, profileBar);
            }
        }
        Debug.Log("Open");
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, (218 * displayActivity.Count));
    }
}
