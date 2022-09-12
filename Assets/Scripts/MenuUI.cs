using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public Text HighScore;
    public static int Record;
    public static String Name;
    public TMP_InputField NameInput;
    public static MenuUI Instance;
    public static String CurrentName;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    [System.Serializable]
    class SaveData
    {
        public Text HighScore;
        public int Record;
        public string Name;
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Record = data.Record;
            Name = data.Name;
        }
    }
    public static void SaveScore()
    {
        SaveData data = new SaveData();
        Record = MainManager.h_Points;
        data.Name = Name;
        data.Record = Record;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Start()
    {
        HighScore.text = "HighScore: "+Name +": " +Record;
    }
    public void StartNew()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            CurrentName = NameInput.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            Name = NameInput.text;
            SceneManager.LoadScene(1);
        }
    }
    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
