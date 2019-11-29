using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Add : MonoBehaviour
    
{
    public TextMeshProUGUI date, time, comment, dates, times, comments;
    public GameObject UImark,UImarkout,page,bgsub;
    public List<string> _date;
    public List<string> _time;
    public List<string> _comment;
    // Start is called before the first frame update
    void Start()
    {
        page.transform.position = UImarkout.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void created()
    {

    }
    public void press()
    {

    }

    public void expa()
    {
        page.transform.position = UImarkout.transform.position;
        bgsub.SetActive(true);
    }
    public void cancel()
    {
        bgsub.SetActive(false);
    }
    public void conf()
    {
        _date.Add(date.text);
        _time.Add(time.text);
        _comment.Add(comment.text);
        dates.text = date.text;
        times.text = time.text;
        comments.text = comment.text;
        bgsub.SetActive(false);
    }
}
