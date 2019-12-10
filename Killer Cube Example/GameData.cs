using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class GameData : MonoBehaviour
{
    public GameObject menuLeaderboard;
    public TextMeshProUGUI noScoreText;
    public Slider sfxSlider;
    public Slider musicSlider;
    [Header("SaveData")]
    public static Dictionary<string, float> leaderboard = new Dictionary<string, float>();
    public static float sfxVolume;
    public static float musicVolume;
    public static GameData instance;
    static bool firsttime = true;
    private void Awake()
    {
        menuLeaderboard = GameObject.Find("Leader Board Menu");
        noScoreText = GameObject.Find("No Score Label").GetComponent<TextMeshProUGUI>();
        sfxSlider = GameObject.Find("SFX Slider").GetComponent<Slider>();
        musicSlider = GameObject.Find("Music Slider").GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        if(firsttime == true)
        {
            load_savedata();
            write_leaderboard();
            firsttime = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void start_in_main_menu()
    {
        menuLeaderboard = GameObject.Find("Leader Board Menu");
        noScoreText = GameObject.Find("No Score Label").GetComponent<TextMeshProUGUI>();
        sfxSlider = GameObject.Find("SFX Slider").GetComponent<Slider>();
        musicSlider = GameObject.Find("Music Slider").GetComponent<Slider>();
        write_leaderboard();
    }
    public void set_slider()
    {
        sfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;
    }
    public void save_gamedata()
    {
        Debug.Log("Game Saved");
        if(sfxSlider && musicSlider)
        {
            Debug.Log("Settings Saved");
            sfxVolume = sfxSlider.value;
            musicVolume = musicSlider.value;
        }
        SaveSystem.save(this);
    }
    public void reset_leaderboard()
    {
        leaderboard = new Dictionary<string, float>();
        save_gamedata();
    }
    void load_savedata()
    {
        SaveData data = SaveSystem.load();
        if (data != null)
        {
            Debug.Log("data!=null");
            leaderboard = data.leaderboard;
            sfxVolume = data.sfxVolume;
            musicVolume = data.musicVolume;
        }
        else
        {
            Debug.Log("data=null");
            sfxVolume = 0.75f;
            musicVolume = 0.75f;
        }
    }
    void write_leaderboard()
    {
        Debug.Log("write_leaderboard");
        if (leaderboard.Count == 0)
        {
            noScoreText.text = "No score Data.";
        }
        else
        {
            noScoreText.text = "";
        }
        GridLayoutGroup[] grids = menuLeaderboard.GetComponentsInChildren<GridLayoutGroup>();
        TextMeshProUGUI[] placeTexts = grids[0].GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] nameTexts = grids[1].GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] scoreTexts = grids[2].GetComponentsInChildren<TextMeshProUGUI>();
        //Sorted Dict
        leaderboard = leaderboard.OrderBy(x => -x.Value).ToDictionary(x => x.Key, x => x.Value);
        while(leaderboard.Count > 10)
        {
            leaderboard.Remove(leaderboard.Keys.ElementAt(leaderboard.Count - 1));
        }
        Debug.Log(leaderboard.Count);
        for (int i = 0; i < 10; i++)
        {
            if(i < leaderboard.Count)
            {
                string key = leaderboard.Keys.ElementAt(i).ToString();
                placeTexts[i].text = (i + 1).ToString() + ".";
                nameTexts[i].text = key;
                scoreTexts[i].text = leaderboard[key].ToString();
            }
            else
            {
                placeTexts[i].text = " ";
                nameTexts[i].text = " ";
                scoreTexts[i].text = " ";
            }
        }
    }
}
