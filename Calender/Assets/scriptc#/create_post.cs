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
    private static Dictionary<int, string> _all_challenge = new Dictionary<int, string>();
    public TextMeshProUGUI show_random;
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
        //Instantiate(prefab_bg_showlist).transform.SetParent(content.transform);
        //_all_challenge.Add(int, string)
        _all_challenge.Add(1, "a");
        _all_challenge.Add(2, "b");
        _all_challenge.Add(3, "c");
        _all_challenge.Add(4, "d");
        _all_challenge.Add(5, "e");
        _all_challenge.Add(6, "f");
        _all_challenge.Add(7, "g");
        _all_challenge.Add(8, "h");
        _all_challenge.Add(9, "i");
        _all_challenge.Add(10, "j");
        _all_challenge.Add(11, "k");
        _all_challenge.Add(12, "l");
        _all_challenge.Add(13, "m");
        _all_challenge.Add(14, "n");
        _all_challenge.Add(15, "o");
        _all_challenge.Add(16, "p");
        _all_challenge.Add(17, "q");
        _all_challenge.Add(18, "r");
        _all_challenge.Add(19, "s");
        _all_challenge.Add(20, "t");
        show_random.text = _all_challenge[Random.Range(1 , _all_challenge.Count+1)];
        
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

    public void butt_confirm_random()
    {
        selected_detail.text = show_random.text;
        selected_diff = int_star;
        create();
        challenge_Butt.set_to_main();
    }

    public void butt_try()
    {
        show_random.text = _all_challenge[Random.Range(1, 20)];
        for (int i = 0; i < challenge_Butt.selected_parent.transform.childCount; i++)
        {
            Destroy(challenge_Butt.selected_parent.transform.GetChild(i).gameObject);
        }
        int_star = Random.Range(1, 6);
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
