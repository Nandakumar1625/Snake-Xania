using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Slider bigBallSlider;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverPanel;

    public AudioSource eatSound;

    int score = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScore();
       
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void PlayEatSound()
    {
        eatSound.Play();
    }

    public void ShowSlider(float maxTime)
    {
        bigBallSlider.gameObject.SetActive(true);
        bigBallSlider.maxValue = maxTime;
        bigBallSlider.value = maxTime;
    }

    public void UpdateSlider(float value)
    {
        bigBallSlider.value = value;
    }

    public void HideSlider()
    {
        bigBallSlider.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        Debug.Log("Retry1");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Retry");
    }
}