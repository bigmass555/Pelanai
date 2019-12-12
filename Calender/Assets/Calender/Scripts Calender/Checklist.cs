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
    public GameObject starGrid;
    public GameObject starImage;
    public Image fillBar;
    public int difficulty;
    Button button;
    [SerializeField] float fillTime = 1f;
    float fillSpeed;
    bool confirmed = false;
    bool pointerDown = false;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        fillSpeed = 1 / fillTime;
        set_star();
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
    public void set_up(Activity activity)
    {
        nameText.text = activity.name;
        descriptionText.text = activity.detail;
        difficulty = activity.difficulty;
        set_star();
        if (activity.compeleted)
        {
            disable();
        }
    }
    void set_star()
    {
        for (int i = 0; i < difficulty; i++)
        {
            Instantiate(starImage, starGrid.transform);
        }
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
        disable();
    }
    void disable()
    {
        nameText.fontStyle = FontStyles.Strikethrough;
        button.interactable = false;
    }
}
