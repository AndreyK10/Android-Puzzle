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

    private void Awake()
    {
        PlayerPrefs.SetInt("1", 1);
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
    public void CloseGame()
    {
        Application.Quit();
    }
}
