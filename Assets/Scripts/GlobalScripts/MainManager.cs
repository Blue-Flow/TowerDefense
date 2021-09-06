using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public LevelDataSO LastLoadedLevel { get; set; }
    private bool level1Completed = false;
    private bool level2Completed = false;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadLevelCompleted();
    }

    private void SetMaxLevelReached(int levelNumber)
    {
        switch (levelNumber)
        {
            case 1:
            {
                level1Completed = true;
                    Debug.Log("Level 1 completed");
                    break;
            }
            case 2:
            {
                level2Completed = true;
                    Debug.Log("Level 2 completed");
                    break;
            }
            default:
                {
                    Debug.Log($"No variable for level {levelNumber}");
                    break;
                }
        }   
    }

    #region events
    private void OnEnable()
    {
        EventHandler.OnWinGame += SetMaxLevelReached;
    }

    private void OnDisable()
    {
        EventHandler.OnWinGame -= SetMaxLevelReached;
    }
    #endregion

    [System.Serializable]
    class SaveData
    {
        public bool level1Completed;
        public bool level2Completed;
    }

    public void SaveLevelCompleted()
    {
        SaveData data = new SaveData();
        data.level1Completed = level1Completed;
        data.level2Completed = level2Completed;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadLevelCompleted()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            level1Completed = data.level1Completed;
            level2Completed = data.level2Completed;
        }
    }
}
