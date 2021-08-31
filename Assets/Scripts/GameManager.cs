using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName = "";

    public int highScore = 0;
    public string highScorePlayerName = "";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void SetNewHighScore(int points)
    {
        highScore = points;
        highScorePlayerName = playerName;
    }

    public string GetHighScoreMessage()
    {
        if (highScorePlayerName != "")
        {
            return "High Score: " + highScore + " by " + highScorePlayerName;
        }
        else
        {
            return "High Score: " + highScore;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScorePlayerName;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScorePlayerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayerName = data.highScorePlayerName;
        }
    }

}
