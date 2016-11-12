using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float movementSpeed = 5.0f;

    public GameObject CameraEye;
    public GameObject HMWRig;

  
    private Transform CameraEyeInitialState;
    // Use this for initialization
    void Start () {
        CameraEyeInitialState = CameraEye.transform;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || HMWRig.GetComponent<Motion>().isAccelerationEnabled == true)
        {
            //print("hell");
           // Debug.Log("Hell");
            transform.position += new Vector3(CameraEye.transform.forward.x, CameraEye.transform.forward.y, CameraEye.transform.forward.z) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }
   }
}
