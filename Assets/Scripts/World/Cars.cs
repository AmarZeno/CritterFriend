using UnityEngine;
using System.Collections;

public class Cars : MonoBehaviour {

    public float vehicleSpeed;
    private Vector3 startingPosition;
    public bool isCarMoving = false;
    public int direction;

    void Start()
    {
        startingPosition = gameObject.transform.position;
    }
    void Update() {
        if (isCarMoving) {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * vehicleSpeed * direction;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "ReverseVehicle") {
            gameObject.transform.position = startingPosition;
        }
    }
}
