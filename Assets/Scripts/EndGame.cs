using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour {

    [SerializeField] private TMP_Text attempts;
    [SerializeField] private TMP_Text finalTime;
    [SerializeField] private TMP_Text nameInput;
    [SerializeField] private Highscores highscores;

    private string playerName = "Unknown";
    private double playerTime;

    public void SetFinalTime(double t) {
        playerTime = t;
        finalTime.text = "Общее время: " + playerTime.ToString("0.0000");
    }

    public void SetAttempts(int a) {
        attempts.text = "Всего попыток: " + a;
    }

    public void GetName() {
        if (nameInput.text != "") {
            playerName = nameInput.text;
        }
    }

    public void SaveHighscore() {
        highscores.NewRecord(playerName, playerTime);
    }
}
