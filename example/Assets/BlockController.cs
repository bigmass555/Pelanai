using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockController : MonoBehaviour
{
    public TextMeshProUGUI label;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void change_text()
    {
        label.text = Random.Range(11, 55).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
