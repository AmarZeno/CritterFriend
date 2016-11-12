using UnityEngine;
using System.Collections;

public class GrabTrigger : MonoBehaviour {

    public GameObject HMWRig;

    void OnTriggerEnter(Collider col)
    {
      //  Debug.Log("Hell Yeah");
        Debug.Log(col.gameObject.name);
        if(col.gameObject.name == "palm" || col.gameObject.name == "forearm" || col.gameObject.name == "bone1" || col.gameObject.name == "bone2" || col.gameObject.name == "bone3")
        {
            // Debug.Log("adadadad");
            Destroy(gameObject);
        } 
    }
}
