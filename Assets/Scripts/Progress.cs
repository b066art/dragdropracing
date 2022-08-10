using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Progress : MonoBehaviour {

    [SerializeField] private TMP_Text progress;
    [SerializeField] private Transform carCenter;
    private List<Vector3> waypoints = new List<Vector3>();

    private void Start() {
        GameObject[] waypointsArray = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject wp in waypointsArray) {
            waypoints.Add(wp.transform.position);
        }
    }

    private void Update() {
        progress.text = "Пройдено: " + CalculateProgress() + "%";
    }

    private int CalculateProgress() {
        int i = CompareDistance();
        int progress = Mathf.RoundToInt(100 / (waypoints.Count - 1) * SegmentProgress(waypoints[i], waypoints[i + 1]) + (20 * i));
        return progress;
    }

    private float SegmentProgress(Vector3 start, Vector3 end) {
        float distance = Vector3.Distance(start, end);
        float result = 1 - Mathf.Clamp((((carCenter.position.x - end.x) * (start.x - end.x) + (carCenter.position.y - end.y) * (start.y - end.y) + (carCenter.position.z - end.z) * (start.z - end.z)) / (distance * distance)), 0f, 1f);
        return result;
    }

    private int CompareDistance() {
        int index = 0;
        float lowestDistance = Mathf.Infinity;

        for (int i = 0; i < waypoints.Count - 1; i++) {
            float currentDistance = Vector3.Distance(carCenter.position, Vector3.Lerp(waypoints[i], waypoints[i + 1], 0.5f));

            if (currentDistance < lowestDistance) {
                lowestDistance = currentDistance;
                index = i;
            }
        }

        return index;
    }
}
