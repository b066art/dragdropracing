using UnityEngine;

public class Attempts : MonoBehaviour {

    private int attempts = 0;

    public void AddAttempt() {
        attempts++;
    }

    public int GetAttempts() {
        return attempts;
    }

    public void ResetAttempts() {
        attempts = 0;
    }
}
