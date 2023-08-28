using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [Header("All Menu's")]
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject playerUI;
    public static bool GameIsStopped = false;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsStopped = false;
    }
    public void PauseMenu()
    {
        pauseMenuUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsStopped = true;

    }
    public void Restart()
    {
        SceneManager.LoadScene("scene_day");
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Garage");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitin game...");
        Application.Quit();
    }
}
