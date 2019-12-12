using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class create_post : MonoBehaviour
{
    public RectTransform content_rect;

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
   
    public int int_star = 0;
    public int score_clear, score_notclear;
       
    public TextMeshProUGUI show_clear, show_notclear;
    
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
        show_clear.text = "Clear: " + score_clear.ToString();
        show_notclear.text = "Not Clear: " + score_notclear.ToString();
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
            int_star = 1;
            change_diff(set_only: true);
            actdays.everyday();
        }

        if (activity_type.value == 2)
        {
            act_name.text = "Run 100m.";
            act_detail.text = "Run 100m. in the weekend.";
            int_star = 2;
            change_diff(set_only: true);
            actdays.weekend();
        }

        if (activity_type.value == 3)
        {
            act_name.text = "Sit-Up 30 times";
            act_detail.text = "Sit-Up 30 times every day.";
            int_star = 2;
            change_diff(set_only: true);
            actdays.everyday();
        }

        if (activity_type.value == 4)
        {
            act_name.text = "Read a book";
            act_detail.text = "Read a book in the weekend.";
            int_star = 1;
            change_diff(set_only: true);
            actdays.weekend();
        }

        if (activity_type.value == 5)
        {
            act_name.text = "Solve a <e>Judge problem";
            act_detail.text = "Solve a <e>Judge problem every monday to friday.";
            int_star = 3;
            change_diff(set_only: true);
            actdays.mon_to_fri();
        }

        if (activity_type.value == 6)
        {
            act_name.text = "Take a typing test on Ratatype";
            act_detail.text = "Take a typing test on Ratatype on sunday.";
            int_star = 2;
            change_diff(set_only: true);
            actdays.sun_only();
        }
    }// Change/Add Preset Activity Detail by OnValueChange

    public void change_diff(bool set_only = false)
    {
        for (int i = 0; i < challenge_Butt.selected_starmode.transform.childCount; i++)
        {
            Destroy(challenge_Butt.selected_starmode.transform.GetChild(i).gameObject);
        }

        if (int_star < 5) 
        {
            int_star += 1;
            if (set_only == true)
            {
                int_star -= 1;
            }
        }
        else
        {
            int_star = 1;
        }

        for (int i = 0; i < int_star; i++)
        {
            Instantiate(img_star, challenge_Butt.selected_starmode.transform);
        }
    } //change img_star number of difficulty of activity

    public void Update()
    {
        //update content_rect_tranform lenght to match with their child
        content_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (showlist_prefab_group.Count * 50));
    } 

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
            GameObject.Destroy(child.gameObject);
        }
    }
    
    
    

    public void butt_confirm_create()
    {
        act_difficulty = int_star;
        //act_daylist = { 1};
        activity newActivity = new activity();
        newActivity.name = act_name.text;
        newActivity.detail = act_detail.text;
        newActivity.difficulty = act_difficulty;
        newActivity.days = act_daylist;
        //sad.list.add(newChallenge);
        
        create();
        challenge_Butt.set_to_main();
    }//OnClick 

    public void create()
    {
        name_act_list.Add(act_name.text);
        detail_act_list.Add(act_detail.text);
        difficulty_act_list.Add(act_difficulty);
        Instantiate(prefab_showlist.gameObject.transform, content.transform);
        setting_showlist();
    }
}
