using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Checklist : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Activity activity;
    public GameObject starGrid;
    public GameObject starImage;
    public Image fillBar;
    public int difficulty;
    public Button button;
    [SerializeField] float fillTime = 1f;
    float fillSpeed;
    bool confirmed = false;
    bool pointerDown = false;
    // Start is called before the first frame update
    void Start()
    {
        fillSpeed = 1 / fillTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown && !confirmed)
            fillBar.fillAmount += Time.deltaTime * fillSpeed;
        if (fillBar.fillAmount >= 1 && !confirmed)
        {
            confirmed = true;
            fillBar.fillAmount = 0;
            confirm();
        }
    }
    public void set_up(Activity inputActivity)
    {
        activity = inputActivity;
        nameText.text = inputActivity.name;
        descriptionText.text = inputActivity.detail;
        difficulty = inputActivity.difficulty;
        confirmed = inputActivity.compeleted;
        Debug.Log(activity.compeleted);
        set_star();
        if (inputActivity.compeleted)
        {
            disable();
        }
    }
    void set_star()
    {
        for (int i = 0; i < difficulty; i++)
        {
            Instantiate(starImage, starGrid.transform);
            Debug.Log("star Created");
        }
        Debug.Log("End");
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
    void confirm()
    {
        activity.compeleted = true;
        disable();
    }
    void disable()
    {
        nameText.fontStyle = FontStyles.Strikethrough;
        button.interactable = false;
    }
}
