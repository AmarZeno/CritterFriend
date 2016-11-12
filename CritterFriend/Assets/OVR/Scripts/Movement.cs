using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
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
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
        }
   }
}
