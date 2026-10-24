using TMPro;
using UnityEngine;

// GameManager class that manages the game state
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Reference to the TextMeshPro text component that displays the game over message
    [SerializeField] private TMP_Text gameOverText;

    private void Awake()
    {
        // Ensure that there is only one instance of the GameManager in the scene
        Instance = this;
    }

    private void Start()
    {
        // Hide the game over text at the start of the game
        gameOverText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        // Show the game over text when the game is over
        gameOverText.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }
}
