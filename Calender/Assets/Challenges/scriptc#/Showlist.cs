using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Showlist : MonoBehaviour
{
    public Activity activity;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI detialText;
    public int difficulty;
    public GameObject starGrid;
    public GameObject starImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_up(Activity input_activity)
    {
        activity = input_activity;
        nameText.text = activity.name;
        detialText.text = activity.detail;
        difficulty = activity.difficulty;
        set_star();
    }
    void set_star()
    {
        for (int i = 0; i < difficulty; i++)
        {
            Instantiate(starImage, starGrid.transform);
        }
    }
}
