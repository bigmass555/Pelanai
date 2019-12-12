using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class act_days : MonoBehaviour
{
    public create_post create_Post_script;
    public Toggle sunday, monday, tuesday, wednesday, thursday, friday, saturday;
    public void reset()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 0, 0, 0, 0, 0, 0 };
        set_toggle();
    }
    public void everyday()
    {
        create_Post_script.act_daylist = new List<int>() { 1, 1, 1, 1, 1, 1, 1 };
        set_toggle();
    }
    public void weekend()
    {
        create_Post_script.act_daylist = new List<int>() { 1, 0, 0, 0, 0, 0, 1 };
        set_toggle();
    }
    public void mon_to_fri()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 1, 1, 1, 1, 1, 0 };
        set_toggle();
    }
    public void sun_only()
    {
        create_Post_script.act_daylist = new List<int>() { 1, 0, 0, 0, 0, 0, 0 };
        set_toggle();
    }
    public void mon_only()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 1, 0, 0, 0, 0, 0 };
        set_toggle();
    }
    public void tue_only()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 0, 1, 0, 0, 0, 0 };
        set_toggle();
    }
    public void wed_only()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 0, 0, 1, 0, 0, 0 };
        set_toggle();
    }
    public void thu_only()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 0, 0, 0, 1, 0, 0 };
        set_toggle();
    }
    public void fri_only()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 0, 0, 0, 0, 1, 0 };
        set_toggle();
    }
    public void sat_only()
    {
        create_Post_script.act_daylist = new List<int>() { 0, 0, 0, 0, 0, 0, 1 };
        set_toggle();
    }
    public void set_toggle() 
    {
        sunday.isOn = (create_Post_script.act_daylist[0] != 0);
        monday.isOn = (create_Post_script.act_daylist[1] != 0);
        tuesday.isOn = (create_Post_script.act_daylist[2] != 0);
        wednesday.isOn = (create_Post_script.act_daylist[3] != 0);
        thursday.isOn = (create_Post_script.act_daylist[4] != 0);
        friday.isOn = (create_Post_script.act_daylist[5] != 0);
        saturday.isOn = (create_Post_script.act_daylist[6] != 0);
    }
}
