using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButtonScript : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private CanvasGroup textAlpha;

    private void Awake()
    {
        button = GetComponent<Button>();
        textAlpha = GetComponentInChildren<CanvasGroup>();
    }

    private void Start()
    {
        if (button.interactable == false)
        {
            textAlpha.alpha = 0.5f;
        }
    }
}
