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
    bool houseCollided;

  
    //private Transform CameraEyeInitialState;
    // Use this for initialization
    void Start () {
        CameraEyeInitialState = playerInitialPosition.transform.position;
        worldUpdateHandler = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WorldUpdateHandler>();
        houseCollided = false;
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

        if(gameObject.transform.position.y < -1f) {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0f, 5f, 0f);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }

        if(houseCollided == false)
        {
            //gameObject.transform.position = transform.forward - new Vector3(gameObject.transform.position.x - 10f, gameObject.transform.position.y, gameObject.transform.position.z - 10f);
        }
   }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Target") {
            worldUpdateHandler.IncrementAnimalsSaved(); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target") {
            Animal animalScript = other.gameObject.GetComponent<Animal>();
            animalScript.hasOwnerArrived = true;
            animalScript.RepositionAnimal();
            worldUpdateHandler.IncrementAnimalsSaved();
        }

        if (other.gameObject.layer == 8) {
            houseCollided = true;
        }
        else {
            houseCollided = false;
        }
    }
}
