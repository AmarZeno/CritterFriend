using UnityEngine;
using System.Collections;

public class GrabTrigger : MonoBehaviour {

    public GameObject HandsModel;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hell Yeah");
        if(col.gameObject.tag == "AnimalObject")
        {
            Debug.Log("adadadad");
            HandsModel.GetComponent<Motion>().AnimalPicked = col.gameObject;
        } 
    }
}
