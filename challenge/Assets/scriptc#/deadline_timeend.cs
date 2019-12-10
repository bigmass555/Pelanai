using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deadline_timeend : MonoBehaviour
{
    public GameObject Drop_28, Drop_29, Drop_30, Drop_31, Drop_Month, Drop_Year;
    public List<int> Month_30;
    public List<int> Month_31;
    public List<int> Year_29;
    private void Start()
    {
        Month_30 = new List<int> { 3, 5, 8, 10 };
        Month_31 = new List<int> { 0, 2, 4, 6, 7, 9, 11 };
        Year_29 = new List<int> { 1, 5 };
    }
    private void Update()
    {
        if(Drop_Month.GetComponent<TMP_Dropdown>().value == 1)
        {
            if (Year_29.Contains(Drop_Year.GetComponent<TMP_Dropdown>().value))
            {
                Drop_28.SetActive(false);
                Drop_29.SetActive(true);
                Drop_30.SetActive(false);
                Drop_31.SetActive(false);
            }
            if (!Year_29.Contains(Drop_Year.GetComponent<TMP_Dropdown>().value))
            {
                Drop_28.SetActive(true);
                Drop_29.SetActive(false);
                Drop_30.SetActive(false);
                Drop_31.SetActive(false);
            }
        }
        
        if (Month_30.Contains(Drop_Month.GetComponent<TMP_Dropdown>().value))
        {
            Drop_28.SetActive(false);
            Drop_29.SetActive(false);
            Drop_30.SetActive(true);
            Drop_31.SetActive(false);
        }
        
        if (Month_31.Contains(Drop_Month.GetComponent<TMP_Dropdown>().value))
        {
            Drop_28.SetActive(false);
            Drop_29.SetActive(false);
            Drop_30.SetActive(false);
            Drop_31.SetActive(true);
        }
    }
}
