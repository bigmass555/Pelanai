using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class all_random_challenge : MonoBehaviour
{
    private static Dictionary<int, string> _all_challenge = new Dictionary<int, string>();
    public TextMeshPro show_random;
    public create_post create_post_scrp;
    
    // Start is called before the first frame update
    void Start()
    {
        //ADD method =>
        //_all_challenge.Add(int, string)
        _all_challenge.Add(1, "a");
        _all_challenge.Add(2, "b");
        _all_challenge.Add(3, "c");
        _all_challenge.Add(4, "d");
        _all_challenge.Add(5, "e");
        _all_challenge.Add(6, "f");
        _all_challenge.Add(7, "g");
        _all_challenge.Add(8, "h");
        _all_challenge.Add(9, "i");
        _all_challenge.Add(10, "j");
        _all_challenge.Add(11, "k");
        _all_challenge.Add(12, "l");
        _all_challenge.Add(13, "m");
        _all_challenge.Add(14, "n");
        _all_challenge.Add(15, "o");
        _all_challenge.Add(16, "p");
        _all_challenge.Add(17, "q");
        _all_challenge.Add(18, "r");
        _all_challenge.Add(19, "s");
        _all_challenge.Add(20, "t");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void butt_random()
    {
        show_random.text = _all_challenge[Random.Range(1, 20)];
    }

    public void butt_confirm_random()
    {
        create_post_scrp.selected = show_random;
    }
}
