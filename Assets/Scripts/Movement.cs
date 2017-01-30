using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float movementSpeed = 5.0f;

    public GameObject CameraEye;
    public GameObject playerInitialPosition;
    private Vector2 CameraEyeInitialState;
    public GameObject HMWRig;
    public GameObject gameManager;
    private WorldUpdateHandler worldUpdateHandler;

  
    //private Transform CameraEyeInitialState;
    // Use this for initialization
    void Start () {
        CameraEyeInitialState = playerInitialPosition.transform.position;
        worldUpdateHandler = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WorldUpdateHandler>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || HMWRig.GetComponent<Motion>().isAccelerationEnabled == true)
        {
            //print("hell");
            // Debug.Log("Hell");
            if (playerInitialPosition.transform.position.y + 0.3 >= CameraEyeInitialState.y)
                transform.position += new Vector3(CameraEye.transform.forward.x, CameraEye.transform.forward.y, CameraEye.transform.forward.z) * Time.deltaTime * movementSpeed;
           
        }

        

        if (Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }
   }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Target") {
            worldUpdateHandler.IncrementAnimalsSaved(); 
        }
    }
}
