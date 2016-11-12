/*this script is attached on the animal gameobject*/
using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {


    public bool hasBeenCaught;
    public bool hasOwnerArrived;
    public Transform poacher;
    public WorldUpdateHandler gameManager;

    public GameObject[] positions;
    public int posiCount;
    public int posiLimit;
    void Start() {
        posiCount = 0;
        hasBeenCaught = false;
        hasOwnerArrived = false;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WorldUpdateHandler>();
        gameObject.transform.position = positions[posiCount].transform.position;
        posiLimit = positions.Length;
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            hasOwnerArrived = true;
            
            //spawn a particle system to cover the destroy mechanic
        } else if(other.gameObject.tag == "Poacher") {
            // Destroy(gameObject);
            RepositionAnimal();
            //spawn a differnt particle system to cover the destory mechanic
        }
    }

    void HasOwnerFound() {
        //do the grab action, and the animal has been found

        /*destroy the animal*/
       // Destroy(gameObject);

        /*generate a particle system for it to cover the destroy mechanic*/

        /*incerement the animals found counter*/
        gameManager.IncrementAnimalsSaved();
    }

    public bool HasOwnerFoundAnimal() {
        return hasOwnerArrived;
    }

    public void RepositionAnimal() {
        if(posiLimit <= posiCount)
        {
            posiCount = 0;
        }
        posiCount++;
        gameObject.transform.position = positions[posiCount].transform.position;
    }
}
