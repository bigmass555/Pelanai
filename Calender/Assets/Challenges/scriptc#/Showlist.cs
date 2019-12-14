using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Showlist : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Activity activity;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI detialText;
    public int difficulty;
    public GameObject starGrid;
    public GameObject starImage;
    public GameObject dayTextGrid;
    public Color dayHighLightColor;
    public ActivitiesGridController gridParent;
    public Image fillBar;
    [SerializeField] float fillTime = 1f;
    float fillSpeed;
    bool pointerDown = false;
    // Start is called before the first frame update
    void Start()
    {
        gridParent = GetComponentInParent<ActivitiesGridController>();
        fillSpeed = 1 / fillTime;
    }
    void Update()
    {
        if (pointerDown)
            fillBar.fillAmount += Time.deltaTime * fillSpeed;
        if (fillBar.fillAmount >= 1)
        {
            confirm();
        }
    }
    public void set_up(Activity input_activity)
    {
        activity = input_activity;
        nameText.text = activity.name;
        detialText.text = activity.detail;
        difficulty = activity.difficulty;
        TextMeshProUGUI[] dayTexts = dayTextGrid.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (int i in input_activity.days)
        {
            dayTexts[i - 1].color = dayHighLightColor;
        }
        set_star();
    }
    void set_star()
    {
        for (int i = 0; i < difficulty; i++)
        {
            Instantiate(starImage, starGrid.transform);
        }
    }
    void confirm()
    {
        PelanaiData.activitiesList.Remove(activity);
        gridParent.displayActivity.Remove(activity);
        Destroy(gameObject);
        Debug.Log("Remove Activity");
    }
    public void OnPointerDown(PointerEventData data)
    {
        pointerDown = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        pointerDown = false;
        fillBar.fillAmount = 0;
    }
}
