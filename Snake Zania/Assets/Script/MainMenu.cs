using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("1234");

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}