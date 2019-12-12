using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DateData
{
    public List<Activity> activitieslist = new List<Activity>();
    public int rate = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void set_data(List<Activity> activitieslistInput)
    {
        activitieslist = activitieslistInput;
        int calRate = 1;
        foreach (Activity activity in activitieslist)
        {
            if (activity.compeleted == false)
            {
                calRate = -1;
                break;
            }
        }
        rate = calRate;
    }
}
