using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class expand_showlist : MonoBehaviour
{
    public GameObject texthead;
    public GameObject bg_textdetail;
    public GameObject textdetail;
    public GameObject mark_bg_textdetail;
    
    // Start is called before the first frame update
    void Start()
    {
        texthead = gameObject.transform.GetChild(1).gameObject;
        mark_bg_textdetail = GameObject.Find("mark_bg_textdetail");
        bg_textdetail = GameObject.Find("bg_textdetail");
        textdetail = GameObject.Find("Textdetail");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void expand()
    {
        textdetail.GetComponent<TextMeshProUGUI>().text = texthead.GetComponent<TextMeshProUGUI>().text;
        bg_textdetail.transform.position = new Vector2(mark_bg_textdetail.gameObject.transform.position.x, mark_bg_textdetail.gameObject.transform.position.y);
    }

    
}
