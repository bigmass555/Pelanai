using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChecklistsController : MonoBehaviour
{
    public GameObject checker;
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
        if (PelanaiData.challengeDict.ContainsKey(toDayInt))
        {
            foreach (Activity activity in PelanaiData.challengeDict[toDayInt])
            {
                Checklist checklist = Instantiate(checker, transform).GetComponent<Checklist>();
                checklist.set_up(activity);
            }
        }     
    }
}
