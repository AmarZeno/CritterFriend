/*this script is attached to the poacher gameobject*/
using UnityEngine;
using System.Collections;

public class Poacher : MonoBehaviour {

    public Transform target;   //the poacher will follow this target
    public NavMeshAgent navMeshAgent;
    public UIManager uiManager;
    
    
   void Start() {
        if(navMeshAgent == null) {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        }
        target = GameObject.FindGameObjectWithTag("Target").transform;

        if(uiManager == null) {
            uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        }
    } 

    void Update() {
        navMeshAgent.SetDestination(target.position);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Target") {
            uiManager.EnableTextCollision();
        }
    }
}
