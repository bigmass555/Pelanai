using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreatePost : MonoBehaviour
{
    public RectTransform content_rect;
    public GameObject dayGrid;
    public GameObject starImage;
    public GameObject difficultyGrid;

    //activity_list
    public List<string> name_act_list;
    public List<string> detail_act_list;
    public List<int> difficulty_act_list;

    ///deadline_list
    public List<string> name_deadline_list;
    public List<string> detail_deadline_list;
    public List<int> difficulty_deadline_list;

    public List<GameObject> showlist_prefab_group;

    public List<string> activity_type_optionDropdown;

    public TMP_Dropdown activity_type;
   
    public GameObject prefab_showlist;
    public GameObject content;
    public GameObject unuse;
    public GameObject img_star;
   
    public int starInt = 1;
    
    public challenge_butt challenge_Butt;
    public act_days actdays;

    //create activity variable to save per activity
    public TMP_InputField act_name;
    public TMP_InputField act_detail;
    public int act_difficulty;
    public List<int> act_daylist;
    /// <summary>
    /// act_daylist = new List<int>() { 1, 1, 1, 1, 1, 1, 1 };
    /// </summary>
    
    void Start()
    {
        //Setscore
        activity_type_optionDropdown = new List<string>
        {   
            "---CUSTOM ACTIVITY---",
            "Preset1: Walk 100m.",
            "Preset2: Run 100m.",
            "Preset3: Sit-Up 30 times",
            "Preset4: Read a book",
            "Preset5: Solve a <e>Judge problem",
            "Preset6: Take a typing test on Ratatype"
        };
        activity_type.AddOptions(activity_type_optionDropdown);
        activity_type.RefreshShownValue();
        
    }

    public void change_activity_type()
    {
        if (activity_type.value == 0)
        {
            Debug.Log("0");
        }

        if (activity_type.value == 1)
        {
            act_name.text = "Walk 100m.";
            act_detail.text = "Walk 100m. every day.";
            starInt = 1;
            //change_difficulty(set_only: true);
            actdays.everyday();
        }

        if (activity_type.value == 2)
        {
            act_name.text = "Run 100m.";
            act_detail.text = "Run 100m. in the weekend.";
            starInt = 2;
            //change_difficulty(set_only: true);
            actdays.weekend();
        }

        if (activity_type.value == 3)
        {
            act_name.text = "Sit-Up 30 times";
            act_detail.text = "Sit-Up 30 times every day.";
            starInt = 2;
            //change_difficulty(set_only: true);
            actdays.everyday();
        }

        if (activity_type.value == 4)
        {
            act_name.text = "Read a book";
            act_detail.text = "Read a book in the weekend.";
            starInt = 1;
            //change_difficulty(set_only: true);
            actdays.weekend();
        }

        if (activity_type.value == 5)
        {
            act_name.text = "Solve a <e>Judge problem";
            act_detail.text = "Solve a <e>Judge problem every monday to friday.";
            starInt = 3;
            //change_difficulty(set_only: true);
            actdays.mon_to_fri();
        }

        if (activity_type.value == 6)
        {
            act_name.text = "Take a typing test on Ratatype";
            act_detail.text = "Take a typing test on Ratatype on sunday.";
            starInt = 2;
            //change_difficulty(set_only: true);
            actdays.sun_only();
        }
    }// Change/Add Preset Activity Detail by OnValueChange

    public void change_difficulty()
    {
        starInt++;
        if (difficultyGrid.transform.childCount < 5)
        {
            Instantiate(starImage, difficultyGrid.transform);
        }
        else
        {
            clear_star_to_one();
        }
        Debug.Log(starInt);
    } //change img_star number of difficulty of activity
    public void clear_star_to_one()
    {
        foreach(Transform star in difficultyGrid.transform)
        {
            Destroy(star.gameObject);
        }
        Instantiate(starImage, difficultyGrid.transform);
        starInt = 1;
    }

    public void Update()
    {
        //update content_rect_tranform lenght to match with their child
        content_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (showlist_prefab_group.Count * 50));
    } 
    /*
    public void setting_showlist()
    {
        showlist_prefab_group.Clear();
        for (int i = 0; i < content.transform.childCount; i++)
        {
            showlist_prefab_group.Add(content.transform.GetChild(i).gameObject);
            showlist_prefab_group[i].name = i.ToString();
            showlist_prefab_group[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = detail_act_list[i];
        }
        unuse_destroy_its_chlid();
    }

    public void unuse_destroy_its_chlid()
    {
        foreach (Transform child in unuse.transform)
        {
            Destroy(child.gameObject);
        }
    }
    */
    public void butt_confirm_create()
    {
        Activity newActivity = new Activity();
        newActivity.name = act_name.text;
        newActivity.detail = act_detail.text;
        newActivity.difficulty = starInt;
        newActivity.days = set_toggle();
        PelanaiData.activitiesList.Add(newActivity);
        foreach(int i in newActivity.days)
        {
            Debug.Log(i);
        }
        Debug.Log("created");
        create(newActivity);
    }
    List<int> set_toggle()
    {
        List<int> dayList = new List<int>();
        int step = 1;
        foreach (Toggle toggle in dayGrid.GetComponentsInChildren<Toggle>())
        {
            if (toggle.isOn)
            {
                dayList.Add(step);
            }
            step++;
        }
        return dayList;
    }

    public void create(Activity activity)
    {
        Showlist show_list = Instantiate(prefab_showlist, content.transform).GetComponent<Showlist>();
        show_list.set_up(activity);
    }

}
