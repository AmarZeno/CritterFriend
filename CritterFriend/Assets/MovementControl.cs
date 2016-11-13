using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {

    public GameObject player;
    public float movementSpeed = 5.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            //print("hell");
            // Debug.Log("Hell");
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
            player.transform.position = transform.position;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
            player.transform.position = transform.position;
        }
    }
}
