using System;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    [SerializeField] private TMP_Text timer;

    private Stopwatch time = new Stopwatch();
    TimeSpan ts;

    private void Update() {
        ts = time.Elapsed;
        timer.text = "Время: " + ts.TotalSeconds.ToString("0.0000");
    }

    public void StartTimer() {
        time.Start();
    }

    public void StopTimer() {
        time.Stop();
    }

    public void ResetTimer() {
        time.Reset();
    }

    public double GetTime() {
        return ts.TotalSeconds;
    }
}
