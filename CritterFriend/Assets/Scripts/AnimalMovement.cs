using UnityEngine;
using System.Collections;

public class AnimalMovement : MonoBehaviour {

    bool moveDirectionForward;
    Vector3 initialPosition;
    
    // Use this for initialization
    void Start () {
	    initialPosition = transform.position;
        Debug.Log(initialPosition.z+" "+" is the vector");
        transform.eulerAngles = new Vector3(0f,0f,0f);

    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.z > (initialPosition.z + 10f))
        {
            moveDirectionForward = false;
            transform.Rotate(transform.rotation.x, transform.rotation.y - 180, transform.rotation.z);
        }

        if (transform.position.z < (initialPosition.z - 10f))
        {
            moveDirectionForward = true;
            transform.Rotate(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
        }

        if (moveDirectionForward)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f);
            //transform.rotation
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.01f);
        }


        //
	}
}
