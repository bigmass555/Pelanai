using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Activity
{
    public string name;
    public string detail;
    public int difficulty;
    public List<int> days;
    public bool compeleted = false;
}
