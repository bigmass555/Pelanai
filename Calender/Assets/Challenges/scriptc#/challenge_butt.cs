using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge_butt : MonoBehaviour
{
    public GameObject create_activity_bg;
    public GameObject bg_textdetail;
    public float hide_x, hide_y;
    public create_post create_Post_script;
    public GameObject difficulty_of_act;
    public GameObject selected_starmode;
    void Start()
    {
        create_activity_bg.SetActive(false);
        hide_x = bg_textdetail.transform.position.x;
        hide_y = bg_textdetail.transform.position.y;
    }

    public void minimize_butt()
    {
        bg_textdetail.transform.position = new Vector2(hide_x, hide_y);
    }

    public void button_to_create_activity()
    {
        create_activity_bg.SetActive(true);
        selected_starmode = difficulty_of_act;
    }
    public void button_cancle_create_activity()
    {
        create_activity_bg.SetActive(false);
    }

    public void set_to_main()
    {
        create_activity_bg.SetActive(false);
    }

}
