using UnityEngine;

[RequireComponent(typeof(CarMovement))]

public class DeadZoneCheck : MonoBehaviour {

    [SerializeField] private GameObject deadZone;

    private CarMovement carMovement;

    private void Start() {
        carMovement = GetComponent<CarMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == deadZone.name) {
            carMovement.ResetPosition();
        }
    }
}
