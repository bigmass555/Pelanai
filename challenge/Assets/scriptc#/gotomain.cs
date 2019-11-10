using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotomain : MonoBehaviour
{
    public GameObject sub_bg, ccc_bg, crc_bg;
    // Start is called before the first frame update
    public void set_to_main()
    {
        sub_bg.SetActive(false);
        ccc_bg.SetActive(false);
        crc_bg.SetActive(false);
    }
}
