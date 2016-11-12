using UnityEngine;
using System.Collections;

public class CarBumperTrigger : MonoBehaviour {

    public GameObject selfCar;
    public Cars car;
    void Start() {
        car = selfCar.GetComponent<Cars>();
    }

    void OnTriggerEnter(Collider other ) {
        if(other.gameObject.tag == "VehicleBackTrigger") {
            car.isCarMoving = false;
        }else {
            Debug.Log("adadwdD");
        }
    }
}
