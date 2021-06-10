using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string currentName;
    public string bestScoreName;
    public int bestScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.name = bestScoreName;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreName = data.name;
            bestScore = data.score;
        }
    }

}
