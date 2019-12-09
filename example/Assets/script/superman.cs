using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superman : MonoBehaviour
{
    public int num = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (num == 0)
        {
            num = 0;
            Debug.Log(num);
        }
        else {
            Debug.Log(num);
        }
    }
    public void test()
    {
        Debug.Log(num);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
