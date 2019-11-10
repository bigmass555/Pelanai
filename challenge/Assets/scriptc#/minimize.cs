using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimize : MonoBehaviour
{
    public GameObject bg_textdetail;
    public float hide_x, hide_y;
    // Start is called before the first frame update
    void Start()
    {
        hide_x = bg_textdetail.transform.position.x;
        hide_y = bg_textdetail.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void minimize_butt()
    {
        bg_textdetail.transform.position = new Vector2(hide_x, hide_y);
    }
}
