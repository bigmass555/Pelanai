using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class content_hight : MonoBehaviour
{
    public RectTransform _content;
    public create_post create_Post_scrp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (create_Post_scrp.show_list_manager.Count * 50));
    }
}
