using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CarMovement : MonoBehaviour {

    [SerializeField] private GameObject taillights;
    [SerializeField] private float minThrust = 0f;
    [SerializeField] private float maxThrust = 35000f;

    private Rigidbody rb;

    private bool engineIsOn = false;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    

    private void Start() {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void FixedUpdate() {
        TaillightsSwitch();
    }

    private void TaillightsSwitch() {
        if (!IsMoving() && engineIsOn && !taillights.activeSelf) {
            taillights.SetActive(true);
        }
        if (IsMoving() && engineIsOn && taillights.activeSelf) {
            taillights.SetActive(false);
        }
    }

    public bool IsMoving() {
        if (rb.velocity.magnitude != 0) {
            return true;
        } else {
            return false;
        }
    }

    public void StartPosition()
    {
        rb.isKinematic = true;
        transform.rotation = startRotation;
        transform.position = startPosition;
        rb.isKinematic = false;
    }

    public void ResetPosition()
    {
        rb.isKinematic = true;
        transform.rotation = lastRotation;
        transform.position = lastPosition;
        rb.isKinematic = false;
    }

    public void StartMoving(int thrustPower, int angle) {
        if (thrustPower != 0) {
            lastRotation = transform.rotation;
            lastPosition = transform.position;

            float zRot = 360 - transform.rotation.eulerAngles.y + angle;
            transform.rotation = Quaternion.Euler(90, 0, zRot);
        }
        
        float thrust = minThrust + ((maxThrust - minThrust) * thrustPower);
        rb.AddForce(transform.right * thrust);
    }

    public void EngineSwitch() {
        if (engineIsOn) {
            engineIsOn = false;
        } else {
            engineIsOn = true;
        }
    }
}
