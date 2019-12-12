using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CalendarController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject monthPage;
    public TextMeshProUGUI monthText;
    public TextMeshProUGUI yearText;
    public Color greyOut;
    public Color highlightToday;
    RectTransform monthPagesPlaceHolder;
    [SerializeField] float horizontalSpacing;
    [SerializeField] RectTransform rt;
    [SerializeField] float percentThreshold = 0.2f;
    [SerializeField] float easing = 1f;
    [SerializeField] float swipeSpeed = 0.1f;
    bool transitioning = false;
    int index = 0;
    Vector3 oriposition;
    // Start is called before the first frame update
    void Start()
    {
        monthPagesPlaceHolder = GetComponent<RectTransform>();
        Debug.Log(transform.position);
        Debug.Log(transform.localPosition);
        oriposition = transform.localPosition;
        instantiate_month_page(-1, 0);
        instantiate_month_page(0, 1);
        instantiate_month_page(1, 2);
        write_calendar(Helper.Time.SubtractDate(Helper.Time.FullDate, index), 1);
        change_text(index);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void write_calendar(System.DateTime date, int target)
    {
        int month = int.Parse(date.Month.ToString());
        int year = int.Parse(date.Year.ToString());
        GridLayoutGroup[] monthPages = gameObject.GetComponentsInChildren<GridLayoutGroup>();
        GridLayoutGroup targetPage = monthPages[target];
        int first_day_of_month = Helper.Time.GetFirstDaysOfMonth(month, year);
        string first_date_of_month = Helper.Time.GetDate(month.ToString() + "/1/" + year.ToString()).ToString();
        int step = 0;
        foreach (Transform dateslot in targetPage.transform)
        {
            TextMeshProUGUI[] textInSlot = dateslot.GetComponentsInChildren<TextMeshProUGUI>();
            DateSlot dateSlot = dateslot.GetComponent<DateSlot>();
            TextMeshProUGUI text = textInSlot[0];
            System.DateTime caldate = Helper.Time.CalDate(first_date_of_month, step - first_day_of_month);
            text.text = caldate.ToString("dd");
            if (caldate.Month != month)
            {
                text.color = greyOut;
            }
            else if (caldate == Helper.Time.FullDate)
            {
                text.color = highlightToday;
            }
            else if (PelanaiData.dateDataDict.ContainsKey(caldate))
            {
                int dateDataRate = PelanaiData.dateDataDict[caldate].rate;
                if (dateDataRate == 1)
                    dateSlot.button.image.color = dateSlot.completeColor;
                else if (dateDataRate == -1)
                    dateSlot.button.image.color = dateSlot.faliedColor;
            }
            step += 1;
        }
    }
    public void OnDrag(PointerEventData data)
    {
        if (!transitioning)
        {
            float differ = (data.pressPosition.x - data.position.x) * swipeSpeed;
            transform.localPosition = oriposition - new Vector3(differ, 0);
        }
    }
    public void OnEndDrag(PointerEventData data)
    {
        if (!transitioning)
        {
            float percent = (data.pressPosition.x - data.position.x) / Screen.width;
            if (Mathf.Abs(percent) > percentThreshold)
            {
                Vector2 newposition = oriposition;
                if (percent > 0)
                {
                    index += 1;
                    instantiate_month_page(1, 3, 0);
                    change_text(index);
                    newposition += new Vector2(-(monthPagesPlaceHolder.rect.width + horizontalSpacing), transform.localPosition.y);
                    Debug.Log((monthPagesPlaceHolder.rect.width + horizontalSpacing));
                }
                else if (percent < 0)
                {
                    index -= 1;
                    instantiate_month_page(-1, 0, 2);
                    change_text(index);
                    newposition += new Vector2(monthPagesPlaceHolder.rect.width + horizontalSpacing, transform.localPosition.y);
                }
                StartCoroutine(smoothMove(transform.localPosition, newposition, easing));
                oriposition = newposition;
            }
            else
            {
                StartCoroutine(smoothMove(transform.localPosition, oriposition, easing));
            }
        }
    }
    void instantiate_month_page(int direction, int childindex, int destroyindex=-1)
    {
        GridLayoutGroup[] monthPages = gameObject.GetComponentsInChildren<GridLayoutGroup>();
        if (destroyindex != -1)
                Destroy(monthPages[destroyindex].gameObject);
        GameObject newMonthPages = Instantiate(monthPage, transform);
        RectTransform newMonthPagesRect = newMonthPages.GetComponent<RectTransform>();
        GridLayoutGroup layoutGroup = newMonthPages.GetComponent<GridLayoutGroup>();
        newMonthPagesRect.sizeDelta = new Vector2(monthPagesPlaceHolder.rect.width, monthPagesPlaceHolder.rect.height);
        layoutGroup.cellSize = new Vector2(newMonthPagesRect.sizeDelta.x / 7, newMonthPagesRect.sizeDelta.y / 6);
        newMonthPages.transform.SetSiblingIndex(childindex);
        write_calendar(Helper.Time.SubtractDate(Helper.Time.FullDate, index + direction), childindex);
        newMonthPages.transform.localPosition = new Vector3((monthPagesPlaceHolder.rect.width + horizontalSpacing) * (index + direction), 0, 0);
    }
    void change_text(int num)
    {
        monthText.text = Helper.Time.FullDate.AddMonths(num).ToString("MMMM");
        yearText.text = Helper.Time.FullDate.AddMonths(num).ToString("yyyy");
    }
    IEnumerator smoothMove(Vector2 position, Vector2 newposition, float time)
    {
        float elastime = 0f;
        transitioning = true;
        while (elastime <= 1)
        {
            elastime += Time.deltaTime / time;
            transform.localPosition = Vector2.Lerp(position, newposition, Mathf.SmoothStep(0f, 1f, elastime));
            yield return null;
        }
        Debug.Log(transform.position);
        Debug.Log(transform.localPosition);
        transitioning = false;
    }
}
