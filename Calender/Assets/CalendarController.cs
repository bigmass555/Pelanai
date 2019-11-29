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
        oriposition = transform.position;
        write_calendar(Helper.Time.SubtractDate(Helper.Time.FullDate, index), 1);
        change_text(index);
        Debug.Log(Helper.Time.GetMonthName(Helper.Time.FullDate));
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
            TextMeshProUGUI text = textInSlot[0];
            System.DateTime caldate = Helper.Time.CalDate(first_date_of_month, step - first_day_of_month);
            text.text = caldate.ToString("dd");
            if (caldate.Month != month)
            {
                text.color = greyOut;
            }
            if (caldate == Helper.Time.FullDate)
            {
                text.color = highlightToday;
            }
            step += 1;
        }
    }
    public void OnDrag(PointerEventData data)
    {
        if (!transitioning)
        {
            float differ = (data.pressPosition.x - data.position.x) * swipeSpeed;
            if (differ > 0)
            {
                write_calendar(Helper.Time.SubtractDate(Helper.Time.FullDate, index + 1), 2);
            }
            else if (differ < 0)
            {
                write_calendar(Helper.Time.SubtractDate(Helper.Time.FullDate, index - 1), 0);
            }
            transform.position = oriposition - new Vector3(differ, 0, 0);
        }
    }
    public void OnEndDrag(PointerEventData data)
    {
        if (!transitioning)
        {
            float percent = (data.pressPosition.x - data.position.x) / Screen.width;
            if (Mathf.Abs(percent) > percentThreshold)
            {
                Vector3 newposition = oriposition;
                if (percent > 0)
                {
                    index += 1;
                    instantiate_month_page(1, 0, 3);
                    change_text(index);
                    newposition += new Vector3(-375, 0, 0);
                }
                else if (percent < 0)
                {
                    index -= 1;
                    instantiate_month_page(-1, 2, 0);
                    change_text(index);
                    newposition += new Vector3(375, 0, 0);
                }
                StartCoroutine(smoothMove(transform.position, newposition, easing));
                oriposition = newposition;
            }
            else
            {
                StartCoroutine(smoothMove(transform.position, oriposition, easing));
            }
        }
    }
    void instantiate_month_page(int direction, int destroyindex, int childindex)
    {
        GridLayoutGroup[] monthPages = gameObject.GetComponentsInChildren<GridLayoutGroup>();
        Destroy(monthPages[destroyindex].gameObject);
        GameObject newMonthPages = Instantiate(monthPage, transform);
        newMonthPages.transform.SetSiblingIndex(childindex);
        newMonthPages.transform.localPosition = new Vector3(375 * (index + direction), 0, 0);
    }
    void change_text(int num)
    {
        monthText.text = Helper.Time.FullDate.AddMonths(num).ToString("MMMM");
        yearText.text = Helper.Time.FullDate.AddMonths(num).ToString("yyyy");
    }
    IEnumerator smoothMove(Vector3 position, Vector3 newposition, float time)
    {
        float elastime = 0f;
        transitioning = true;
        while (elastime <= 1)
        {
            elastime += Time.deltaTime / time;
            transform.position = Vector3.Lerp(position, newposition, Mathf.SmoothStep(0f, 1f, elastime));
            yield return null;
        }
        transitioning = false;
    }
}
