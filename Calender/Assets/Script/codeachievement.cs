using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class codeAchievement : MonoBehaviour
{
    public Image imagebar;
    public Button buttoned;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void press()
    {
        imagebar.fillAmount = num / 100f;
    }
}
