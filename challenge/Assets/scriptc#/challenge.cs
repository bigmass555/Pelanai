using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge : MonoBehaviour
{
    public GameObject Bg_sub, B_custom, B_random;
    void Start()
    {
        Bg_sub.SetActive(false);
        B_custom.SetActive(false);
        B_random.SetActive(false);
    }

    void Update()
    {
        
    }

    public void button_create()
    {
        Bg_sub.SetActive(true);
    }
    public void button_cancle_create()
    {
        Bg_sub.SetActive(false);
    }
    public void button_to_create_custom()
    {
        B_custom.SetActive(true);
    }
    public void button_cancle_create_custom()
    {
        B_custom.SetActive(false);
    }

    public void button_to_create_random()
    {
        B_random.SetActive(true);
    }
    public void button_cancle_create_random()
    {
        B_random.SetActive(false);
    }

}
