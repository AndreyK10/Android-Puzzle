using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Transform levelsPanel;
    private List<Button> levelButtons = new List<Button>();

    public const string LEVEL1_PREFS = "1";
    public const string LEVEL2_PREFS = "2";
    public const string LEVEL3_PREFS = "3";
    public const string LEVEL4_PREFS = "4";
    public const string LEVEL5_PREFS = "5";
    public const string LEVEL6_PREFS = "6";

    private void Awake()
    {
        PlayerPrefs.SetInt(LEVEL1_PREFS, 1);
        foreach (Transform s in levelsPanel)
        {
            if (s.TryGetComponent(out Button _button)) levelButtons.Add(_button);
        }

        for (int i = 0; i < levelButtons.Count; i++)
        {
            if (PlayerPrefs.GetInt(levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().text) == 0)
            {
                levelButtons[i].GetComponent<Button>().interactable = false;
            }
            else if (PlayerPrefs.GetInt(levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().text) == 1)
            {
                levelButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }


    private void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Level1()
    {
        LoadLevel(1);
    }
    public void Level2()
    {
        LoadLevel(2);
    }
    public void Level3()
    {
        LoadLevel(3);
    }
    public void Level4()
    {
        LoadLevel(4);
    }
    public void Level5()
    {
        LoadLevel(5);
    }
    public void Level6()
    {
        LoadLevel(6);
    }
}
