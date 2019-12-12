using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class expand_showlist : MonoBehaviour
{
    public GameObject texthead;
    public GameObject bg_textdetail;
    public GameObject textdetail;
    public GameObject textname;
    public GameObject mark_bg_textdetail;
    public GameObject score_show;

    public challenge_butt challenge_Butt;
    public create_post create_Post_scrp;

    public GameObject clear, notclear;
    public int this_star;
    // Start is called before the first frame update
    void Start()
    {
        //texthead = gameObject.transform.GetChild(1).gameObject;
        challenge_Butt = GameObject.Find("ButtonScript").GetComponent<challenge_butt>();
        create_Post_scrp = GameObject.Find("Createpost_Script").GetComponent<create_post>();
        mark_bg_textdetail = GameObject.Find("mark_bg_textdetail");
        bg_textdetail = GameObject.Find("bg_textdetail");
        textdetail = GameObject.Find("Textdetail");
        textname = GameObject.Find("Textname");
        score_show = GameObject.Find("score_show");
        this_star = create_Post_scrp.act_difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void expand()
    {
        challenge_Butt.selected_starmode = score_show;
        textdetail.GetComponent<TextMeshProUGUI>().text = texthead.GetComponent<TextMeshProUGUI>().text;
        bg_textdetail.transform.position = new Vector2(mark_bg_textdetail.gameObject.transform.position.x, mark_bg_textdetail.gameObject.transform.position.y);
        
        for (int i = 0; i < challenge_Butt.selected_starmode.transform.childCount; i++)
        {
            Destroy(challenge_Butt.selected_starmode.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < this_star; i++)
        {
            Instantiate(create_Post_scrp.img_star, challenge_Butt.selected_starmode.transform);
        }
    }

    public void clear_butt()
    {
        create_Post_scrp.score_clear += this_star;
        create_Post_scrp.show_clear.GetComponent<TextMeshProUGUI>().text = "Clear: " + create_Post_scrp.score_clear.ToString();
        gameObject.transform.SetParent(create_Post_scrp.unuse.transform);
        create_Post_scrp.detail_act_list.RemoveAt(int.Parse(gameObject.name));
        create_Post_scrp.showlist_prefab_group.RemoveAt(int.Parse(gameObject.name));
        create_Post_scrp.setting_showlist();
    }

    public void not_clear_butt()
    {
        create_Post_scrp.score_notclear += this_star;
        create_Post_scrp.show_notclear.GetComponent<TextMeshProUGUI>().text = "Not Clear: "+create_Post_scrp.score_notclear.ToString();
        gameObject.transform.SetParent(create_Post_scrp.unuse.transform);
        create_Post_scrp.detail_act_list.RemoveAt(int.Parse(gameObject.name));
        create_Post_scrp.showlist_prefab_group.RemoveAt(int.Parse(gameObject.name));
        create_Post_scrp.setting_showlist();
    }
    
}
