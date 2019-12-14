using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileEditor : MonoBehaviour
{
    public TMP_InputField InputField;
    public TextMeshProUGUI nameText;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PelanaiData.playerName + " playername");
        nameText.text = PelanaiData.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void change_name()
    {
        nameText.text = InputField.text;
        PelanaiData.playerName = InputField.text;        
    }
    public void open_profile_editor()
    {
        InputField.text = PelanaiData.playerName;
    }
}
