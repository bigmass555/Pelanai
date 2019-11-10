using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class all_custom_challenge : MonoBehaviour
{
    public create_post create_post_scrp;
    public TextMeshProUGUI show_custom;
    public gotomain gotomain_scrp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void butt_confirm_custom()
    {
        create_post_scrp.selected.text = show_custom.text;
        create_post_scrp.create();
        gotomain_scrp.set_to_main();
    }
}
