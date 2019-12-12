using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PelanaiData : MonoBehaviour
{
    public static List<Activity> activitiesList = new List<Activity>();
    public static Dictionary<int, List<Activity>> challengeDict = new Dictionary<int, List<Activity>>();
    public static Dictionary<DateTime, DateData> dateDataDict = new Dictionary<DateTime, DateData>();
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }
}
