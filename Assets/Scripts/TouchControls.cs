using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CarMovement))]

public class TouchControls : MonoBehaviour {

    [SerializeField] private LineRenderer line;
    [SerializeField] private Tension tension;
    [SerializeField] private Attempts attempts;

    private CarMovement carMovement;

    private int power = 0;

    int rotationAngle = 0;
    float mouseStartPosition = 0f;
    float mouseLastPosition = 0f;

    private bool buttonPressed = false;
    private bool controlsIsOn = false;

    private void Start() {
        carMovement = GetComponent<CarMovement>();
    }

    private void Update() {
        if (controlsIsOn) {
            ThrustControl();
        }
    }

    private void ThrustControl() {
        if (Input.GetMouseButton(0) && !carMovement.IsMoving()) {
            if (!buttonPressed) {
                mouseStartPosition = Input.mousePosition.y;
                buttonPressed = true;
            }

            mouseLastPosition = Input.mousePosition.y;

            power = Mathf.RoundToInt(Mathf.Clamp((mouseStartPosition - mouseLastPosition) * 100 / (Screen.height / 2), 0, 100));

            rotationAngle = Mathf.RoundToInt((Input.mousePosition.x - (Screen.width / 2)) * 90 / (Screen.width / 2));
            Vector3 linePos = new Vector3(0, Mathf.Cos((90 - rotationAngle) * Mathf.PI / 180), Mathf.Sin((90 - rotationAngle) * Mathf.PI / 180));

            line.gameObject.SetActive(true);
            line.SetPosition(1, linePos * power / 10);
        }

        if (power > 0 && Input.GetMouseButtonUp(0) && !carMovement.IsMoving()) {
            buttonPressed = false;

            attempts.AddAttempt();
            carMovement.StartMoving(power, rotationAngle);
            line.gameObject.SetActive(false);

            power = 0;
        }

        tension.SetValue(power);
    }

    public void ChangeControlsMode() {
        if (controlsIsOn) {
            controlsIsOn = false;
        } else {
            controlsIsOn = true;
        }
    }

    public void ResetButtonState() {
        buttonPressed = false;
    }
}
