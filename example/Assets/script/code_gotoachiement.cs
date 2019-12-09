using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class code_gotoachiement : MonoBehaviour
{
    public GameObject empty;
    public Button buttoned;
    public Canvas[] canvas;
    public TextMeshProUGUI text_;
    public TextMeshProUGUI textScore;
    public superman man;
    public Image imagebar;
    public GameObject block;
    public GameObject panel;
    public Image imagebartwo;
    int num = 0;
    public float num2 = 2.4f;

    // Start is called before the first frame update
    void Start()
    {
        canvas = empty.GetComponentsInChildren<Canvas>();
        show_name();
        textScore.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
    }
    void show_name()
    {
        Debug.Log("asd");
        foreach (Canvas kuy in canvas)
        {
            Debug.Log(kuy.name);
        }
    }
    public void press()
    {
        BlockController blabla;
        buttoned.interactable = true;
        text_.text = 123.ToString();
        num += 1;
        textScore.text = num.ToString();
        int asd = int.Parse("123");
        int abc = (int)1.5;
        imagebar.fillAmount = num / 100f;
        imagebartwo.fillAmount = num / 50f;
        Debug.Log(num / 100);
        blabla = Instantiate(block, panel.transform).GetComponent<BlockController>();
        blabla.change_text();
    }
}
