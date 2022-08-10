using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private Quaternion defaultRotation;
    [SerializeField] private Transform target;
    [SerializeField] private Transform lookPosition;
    [SerializeField] private float smoothSpeed = 0.125f;

    private bool isInGame = false;

    private void FixedUpdate() {
        if (isInGame) {
            GameplayMode();
        } else {
            StartMenuMode();
        }
    }

    private void StartMenuMode() {
        Vector3 finalPosition = defaultPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.rotation = defaultRotation;
    }

    private void GameplayMode() {
        Vector3 finalPosition = new Vector3(target.position.x, target.position.y, target.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(lookPosition);
    }

    public void ChangeCameraMode() {
        if (isInGame) {
            isInGame = false;
        } else {
            isInGame = true;
        }
    }
}
