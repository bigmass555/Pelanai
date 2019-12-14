using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileBar : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI streakText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public Image expFillbar;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        playerName.text = PelanaiData.playerName;
        streakText.text = PelanaiData.dayStreak.ToString();
        expText.text = "X" + PelanaiData.expBonus.ToString();
        cal_score();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cal_score()
    {
        Debug.Log("CaCulate Score");
        level = Mathf.FloorToInt(PelanaiData.playerScore / 2500);
        levelText.text = level.ToString();
        expFillbar.fillAmount = (PelanaiData.playerScore / 2500) - level;

    }
}
