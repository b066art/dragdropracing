using UnityEngine;
using TMPro;

[RequireComponent(typeof(CarMovement))]
[RequireComponent(typeof(TouchControls))]

public class FinishZoneCheck : MonoBehaviour {

    [SerializeField] private GameObject finishZone;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private EndGame endGame;
    [SerializeField] private UI ui;
    [SerializeField] private Timer timer;
    [SerializeField] private Attempts attempts;
    [SerializeField] private Transform rayPoint;

    private CarMovement carMovement;
    private TouchControls touchControls;
    private bool isInFinishZone = false;
    private LayerMask mask;

    private void Start() {
        carMovement = GetComponent<CarMovement>();
        touchControls = GetComponent<TouchControls>();
        mask = LayerMask.GetMask("FinishZone");
    }

    private void Update() {
        if (!isInFinishZone) {
            CheckZone();
        }
    }

    private void CheckZone() {
        RaycastHit hit;

        if (Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask) && !carMovement.IsMoving() && hit.collider.name == finishZone.name) {
            isInFinishZone = true;
            EndGame();
        }
    }

    private void EndGame() {
        timer.StopTimer();
        touchControls.ChangeControlsMode();
        ui.EndGameMenuSwitch();
        ui.InGameUISwitch();
        ui.PauseButtonSwitch();
        inputField.ActivateInputField();
        endGame.SetFinalTime(timer.GetTime());
        endGame.SetAttempts(attempts.GetAttempts());
    }
}
