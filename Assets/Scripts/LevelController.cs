using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public Color color;
    public GameObject squareLight;

    private Transform allSquares;
    private List<SpriteRenderer> _allSquares = new List<SpriteRenderer>();
    private int nextLevel;

    [SerializeField] private GameObject finishUI, pauseButton, player;
    [SerializeField] private Button nextLevelButton;

    private void Awake()
    {
        instance = this;

        allSquares = GameObject.FindGameObjectWithTag("Map").transform;

        foreach (Transform square in allSquares)
        {
            if (square.TryGetComponent(out SpriteRenderer sr)) _allSquares.Add(sr);
        }
    }

    private void Update()
    {
        if (_allSquares.Count == 0)
        {
            GameFinished();
        }        
        if (nextLevel >= SceneManager.sceneCountInBuildSettings) nextLevelButton.interactable = false;
    }

    public void RemoveFromList()
    {
        _allSquares.RemoveAt(0);
    }
    private void GameFinished()
    {
        finishUI.SetActive(true);
        pauseButton.SetActive(false);
        player.SetActive(false);
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel <= SceneManager.sceneCountInBuildSettings)
        { 
            PlayerPrefs.SetInt(nextLevel.ToString(), 1);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
