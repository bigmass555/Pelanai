using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class create_post : MonoBehaviour
{
    public TextMeshProUGUI selected;
    public List<string> list_selected;
    public GameObject prefab_bg_showlist;
    public List<GameObject> show_list_manager;
    public GameObject setmarkpos_showlist;
    public GameObject content;
    //>>>-----get time that create-----<<<
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(prefab_bg_showlist).transform.SetParent(content.transform);
    }

    
    public void create()
    {
        list_selected.Add(selected.text);
        Instantiate(prefab_bg_showlist).name = "item" + list_selected.Count;
        show_list_manager.Add(GameObject.Find("item" + list_selected.Count));
        set_showlist_pos();
    }

    public void Update()
    {
        
    }

    public void set_showlist_pos()
    {
        for (int i = 0; i < show_list_manager.Count; i++)
        {
            show_list_manager[i].GetComponentInChildren<TextMeshProUGUI>().text = list_selected[i];
            show_list_manager[i].transform.SetParent(content.transform);
            
            //show_list_manager[i].GetComponent<RectTransform>().anchorMax = setmarkpos_showlist.GetComponent<RectTransform>().anchorMax;
            //show_list_manager[i].GetComponent<RectTransform>().anchorMin = setmarkpos_showlist.GetComponent<RectTransform>().anchorMin;
            //show_list_manager[i].GetComponent<RectTransform>().pivot = setmarkpos_showlist.GetComponent<RectTransform>().pivot;
            show_list_manager[i].GetComponent<RectTransform>().position = new Vector2(setmarkpos_showlist.GetComponent<RectTransform>().position.x, setmarkpos_showlist.GetComponent<RectTransform>().position.y);
            if (i > 0)
            {
                show_list_manager[i].GetComponent<RectTransform>().position = new Vector2(show_list_manager[i-1].GetComponent<RectTransform>().position.x, show_list_manager[i - 1].GetComponent<RectTransform>().position.y - 50);
            }

        }
    }
}
