using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class act_days : MonoBehaviour
{
    public CreatePost create_Post_script;
    public GameObject day_grid;
    public void reset()
    {
        create_Post_script.act_daylist = new List<int>() { };
        preset();
    }
    public void everyday()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        preset();
    }
    public void weekend()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 6 };
        preset();
    }
    public void mon_to_fri()
    {
        create_Post_script.act_daylist = new List<int>() { 1, 2, 3, 4, 5 };
        preset();
    }
    public void sun_only()
    {
        create_Post_script.act_daylist = new List<int>() { 0 };
        preset();
    }
    public void mon_only()
    {
        create_Post_script.act_daylist = new List<int>() { 1 };
        preset();
    }
    public void tue_only()
    {
        create_Post_script.act_daylist = new List<int>() { 2 };
        preset();
    }
    public void wed_only()
    {
        create_Post_script.act_daylist = new List<int>() { 3 };
        preset();
    }
    public void thu_only()
    {
        create_Post_script.act_daylist = new List<int>() { 4 };
        preset();
    }
    public void fri_only()
    {
        create_Post_script.act_daylist = new List<int>() { 5 };
        preset();
    }
    public void sat_only()
    {
        create_Post_script.act_daylist = new List<int>() { 6 };
        preset();
    }
    public void preset()
    {
        Toggle[] toggle =  day_grid.GetComponentsInChildren<Toggle>();
        foreach (int i in create_Post_script.act_daylist)
        {
            toggle[i].isOn = true;
        }
    }
}
