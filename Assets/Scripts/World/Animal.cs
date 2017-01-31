/*this script is attached on the animal gameobject*/
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net;

public class Animal : MonoBehaviour {


    public bool hasBeenCaught;
    public bool hasOwnerArrived;
    public Transform poacher;
    public WorldUpdateHandler gameManager;

    public GameObject savedParticleSystem;
    public GameObject capturedParticleSystem;

    public GameObject[] positions;
	public GameObject FallbackObject;

	private int posiCount;
	private int posiLimit;
    void Start()
    {
        posiCount = 0;
        hasBeenCaught = false;
        hasOwnerArrived = false;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WorldUpdateHandler>();
        gameObject.transform.position = positions[posiCount].transform.position;
		posiLimit = GetAnimalCountFromAzure();
		Debug.Log ("Length is" +posiLimit);
    }

    void OnCollisionEnter(Collision other)
    {
		Debug.Log (other.collider.name);
        if (other.gameObject.tag == "Player")
        {
           // hasOwnerArrived = true;

			RepositionAnimal();
            //spawn a particle system to cover the destroy mechanic
        }
        else if (other.gameObject.tag == "Poacher")
        {
            // Destroy(gameObject);
            RepositionAnimal();
            //spawn a differnt particle system to cover the destory mechanic
        }
    }

    void HasOwnerFound()
    {
        //do the grab action, and the animal has been found

        /*destroy the animal*/
        // Destroy(gameObject);

        /*generate a particle system for it to cover the destroy mechanic*/

        /*incerement the animals found counter*/
        gameManager.IncrementAnimalsSaved();
    }

    public bool HasOwnerFoundAnimal()
    {
        return hasOwnerArrived;
    }

    public void RepositionAnimal()
    {
		if (posiCount >= posiLimit)
        {
            posiCount = 0;
        }
		posiCount++;
		if (posiCount < positions.Length) {
			gameObject.transform.position = positions [posiCount].transform.position;
		} else {
			gameObject.transform.position = FallbackObject.transform.position;
		}
		gameObject.transform.rotation = Quaternion.identity;
    }

    public int GetAnimalCountFromAzure() {
        int enemyCount;
        using (WebClient wc = new WebClient())
        {
            var client = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            string json = client.DownloadString("http://critterfriend.azurewebsites.net/enemyCount.json");
            enemyCount = int.Parse(Regex.Match(json, @"\d+").Value);
        }
        return enemyCount;
    }
}
