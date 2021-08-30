using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public Color color;
    public GameObject squareLight;

    private Transform allSquares;
    private List<SpriteRenderer> _allSquares = new List<SpriteRenderer>();

    [SerializeField] private GameObject finishUI, pauseButton, player;

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
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel <= SceneManager.sceneCount) PlayerPrefs.SetInt(nextLevel.ToString(), 1);
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
