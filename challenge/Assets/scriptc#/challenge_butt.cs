using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge_butt : MonoBehaviour
{
    public GameObject sub_bg, ccc_bg, crc_bg;
    public GameObject bg_textdetail;
    public float hide_x, hide_y;
    public create_post create_Post_script;
    public GameObject ccc_score_butt;
    public GameObject crc_score_butt;
    public GameObject selected_parent;
    void Start()
    {
        sub_bg.SetActive(false);
        ccc_bg.SetActive(false);
        crc_bg.SetActive(false);

        hide_x = bg_textdetail.transform.position.x;
        hide_y = bg_textdetail.transform.position.y;
    }

    void Update()
    {
        
    }

    public void minimize_butt()
    {
        bg_textdetail.transform.position = new Vector2(hide_x, hide_y);
    }

    public void button_create()
    {
        sub_bg.SetActive(true);
    }
    public void button_cancle_create()
    {
        sub_bg.SetActive(false);
    }
    public void button_to_create_custom()
    {
        ccc_bg.SetActive(true);
        selected_parent = ccc_score_butt;


    }
    public void button_cancle_create_custom()
    {
        ccc_bg.SetActive(false);
    }

    public void button_to_create_random()
    {
        crc_bg.SetActive(true);
        selected_parent = crc_score_butt;
    }
    public void button_cancle_create_random()
    {
        crc_bg.SetActive(false);
    }

    public void set_to_main()
    {
        sub_bg.SetActive(false);
        ccc_bg.SetActive(false);
        crc_bg.SetActive(false);
    }

}
