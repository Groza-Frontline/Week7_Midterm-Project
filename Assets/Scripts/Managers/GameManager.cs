using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TMP_Text gameOverText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }
}
