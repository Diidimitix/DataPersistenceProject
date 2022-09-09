using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public Text HighScore;
    public static string Name;
    public TMP_InputField NameInput;
    // Start is called before the first frame update
    public void Start()
    {
        HighScore.text = "HighScore: "+MainManager.h_Points;
    }
    public void StartNew()
    {
        Name = NameInput.text;
        SceneManager.LoadScene(1);
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
