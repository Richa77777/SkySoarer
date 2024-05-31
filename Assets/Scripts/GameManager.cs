using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;

    private int _score = 0;
    private bool _gameOver = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        _gameOverPanel.SetActive(false);
        _scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        _gameOver = true;
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        if (!_gameOver)
        {
            _score++;
            _scoreText.text = "Score: " + _score;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}