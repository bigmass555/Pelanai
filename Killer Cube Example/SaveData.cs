using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public Dictionary<string, float> leaderboard = new Dictionary<string, float>();
    public float sfxVolume = 1;
    public float musicVolume = 1;
    public SaveData()
    {
        Debug.Log("some");
        leaderboard = GameData.leaderboard;
        sfxVolume = GameData.sfxVolume;
        musicVolume = GameData.musicVolume;
    }
}
