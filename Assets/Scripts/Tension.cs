using UnityEngine;
using TMPro;

public class Tension : MonoBehaviour {

    [SerializeField] private TMP_Text tension;

    private int currentTension = 0;

    private void Update() {
        tension.text = "Натяжение: " + currentTension + "%";
    }

    public void SetValue(float t) {
        currentTension = Mathf.RoundToInt(t);
    }
}
