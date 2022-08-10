using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject highscores;
    [SerializeField] private GameObject endGameMenu;

    public void InGameUISwitch() {
        if (inGameUI.activeSelf) {
            inGameUI.SetActive(false);
        } else {
            inGameUI.SetActive(true);
        }
    }

    public void StartMenuSwitch() {
        if (startMenu.activeSelf) {
            startMenu.SetActive(false);
        } else {
            startMenu.SetActive(true);
        }        
    }

    public void PauseButtonSwitch() {
        if (pauseButton.activeSelf) {
            pauseButton.SetActive(false);
        } else {
            pauseButton.SetActive(true);
        }        
    }

    public void PauseMenuSwitch() {
        if (pauseMenu.activeSelf) {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        } else {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }        
    }

    public void HighscoresSwitch() {
        if (highscores.activeSelf) {
            Time.timeScale = 1;
            highscores.SetActive(false);
        } else {
            Time.timeScale = 0;
            highscores.SetActive(true);
        }        
    }

    public void ExitButton() {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void EndGameMenuSwitch() {
        if (!endGameMenu.activeSelf) {
            Time.timeScale = 0;
            endGameMenu.SetActive(true);
        }
    }
}
