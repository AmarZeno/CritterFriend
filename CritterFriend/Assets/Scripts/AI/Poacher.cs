/*this script is attached to the poacher gameobject*/
using UnityEngine;
using System.Collections;

public class Poacher : MonoBehaviour {

    public Vector3 startingPosition;
    public Transform target;   //the poacher will follow this animal !!!
    public Transform alternateTarget;   //the dummy target the poacher will follow
    public NavMeshAgent navMeshAgent;
    public UIManager uiManager;
    public WorldUpdateHandler gameManager;

    private Vector3 animalPosition;
    private bool hasAnimalFoundOwner;
    public bool hasFoundPosition;   //is executed, when we need to search for the target again

   void Start() {
        if(navMeshAgent == null) {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        }
        target = GameObject.FindGameObjectWithTag("Target").transform;

        if(uiManager == null) {
            uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        }

        if (gameManager == null) {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WorldUpdateHandler>();
        }

        if(alternateTarget == null) {
            alternateTarget = GameObject.FindGameObjectWithTag("DummyTarget").transform;
        }

        hasAnimalFoundOwner = false;

        startingPosition = gameObject.transform.position;
    } 

    void Update() {

        if (target != null)
            navMeshAgent.SetDestination(target.position);

        /*check if game is over ? */
        if (!gameManager.IsGameOver()) {
            /*find the animal where it is*/
            LocateAnimal();
        }
        /*keep checking whether the animal has been picked up or not*/
        CheckAnimalHasBeenPicked();

        /*if yes, then divert to another location*/
        //....DONE

        /*once it reaches the diverted location, respawn from it soriginal location*/
        //....DONE

        /*if not, destroy that animal, and spawn another at different position*/
        //....DONE

        /*keep going, until 5 animals are not caught*/
        //....DONE

        CheckDisatanceBetweeenPoacherAlternateTarget();
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Target") {
            uiManager.SetTextForTextCollision("Poacher captured the pet");
            uiManager.EnableTextCollision();
        }
    }

    void LocateAnimal() {
        if (hasAnimalFoundOwner == false) {
            if (hasFoundPosition == false) {
                target = GameObject.FindGameObjectWithTag("Target").transform;
                animalPosition = target.position;
                hasFoundPosition = true;
            }
        }
    }

    void CheckAnimalHasBeenPicked() {
        if(target.GetComponent<Animal>().hasOwnerArrived == true) {
            /*divert to another location*/
            DivertPoacherToDummyTarget();
        }
        else {
            /*increment the caught counter*/
            gameManager.IncerementAnimalsCaught();
            /*destroy the animal*/

            /*play a particle system*/

            /*display something on UI*/
        }
    }

    void DivertPoacherToDummyTarget() {
        hasAnimalFoundOwner = target.GetComponent<Animal>().HasOwnerFoundAnimal();
        navMeshAgent.SetDestination(alternateTarget.position);
    }

    void RepositionPoacher() {
        gameObject.transform.position = startingPosition;
        navMeshAgent.SetDestination(target.transform.position);
    }

    void CheckDisatanceBetweeenPoacherAlternateTarget() { 
        if(hasAnimalFoundOwner == true) {
            if(Vector3.Distance(gameObject.transform.position, alternateTarget.transform.position) < 2f)
            {
                RepositionPoacher();
            }
        }
    }


    
}
