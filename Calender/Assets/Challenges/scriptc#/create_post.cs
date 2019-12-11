using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class create_post : MonoBehaviour
{
    public TextMeshProUGUI selected_detail;
    public List<string> list_selected;
    public GameObject prefab_bg_showlist;
    public List<GameObject> show_list_manager;
    public GameObject content;
    public TextMeshProUGUI show_custom;
    public challenge_butt challenge_Butt;
    public RectTransform content_rect;
    public GameObject img_star;
    public int int_star = 0;
    public int selected_diff;
    public List<int> list_diff_selected;
    public int score_clear, score_notclear;
    public TextMeshProUGUI show_clear, show_notclear;
    public GameObject unuse;
    //>>>-----get time that create-----<<<
    // Start is called before the first frame update
    void Start()
    {
        //Setscore
        show_clear.GetComponent<TextMeshProUGUI>().text = "Clear: " + score_clear.ToString();
        show_notclear.GetComponent<TextMeshProUGUI>().text = "Not Clear: " + score_notclear.ToString();
        
    }

    public void change_diff()
    {
        for (int i = 0; i < challenge_Butt.selected_parent.transform.childCount; i++)
        {
            Destroy(challenge_Butt.selected_parent.transform.GetChild(i).gameObject);
        }

        if (int_star < 5) 
        {
            int_star += 1;
        }
        else
        {
            int_star = 1;
        }

        for (int i = 0; i < int_star; i++)
        {
            Instantiate(img_star, challenge_Butt.selected_parent.transform);
        }
    }

    public void butt_confirm_custom()
    {
        selected_detail.text = show_custom.text;
        selected_diff = int_star;
        create();
        challenge newChallenge = new challenge();
        newChallenge.detail = "asd";
        newChallenge.difficulty = 2;
        //sad.list.add(newChallenge);
        challenge_Butt.set_to_main();
    }

    public void create()
    {
        list_selected.Add(selected_detail.text);
        list_diff_selected.Add(selected_diff);
        Instantiate(prefab_bg_showlist.gameObject.transform,content.transform);
        //Instantiate(prefab_bg_showlist).name = "item" + list_selected.Count;
        set_showlist_pos();
    }

    public void Update()
    {
        content_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (show_list_manager.Count * 50));
    }

    public void set_showlist_pos()
    {
        show_list_manager.Clear();
        for (int i = 0; i < content.transform.childCount; i++)
        {
            show_list_manager.Add(content.transform.GetChild(i).gameObject);
            show_list_manager[i].name = i.ToString();
            show_list_manager[i].transform.GetComponentInChildren<TextMeshProUGUI>().text = list_selected[i];
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
}
