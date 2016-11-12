using UnityEngine;
using System.Collections;

public class AnimalSpawner : MonoBehaviour {

    public GameObject SpawnAnimal;
    public GameObject SpawnedAnimal;

	// Use this for initialization
	void Start () {
        SpawnAnimalMethod();
	}
	
	// Update is called once per frame
	void Update () {
        float MoveForward = Input.GetAxis("Vertical");
        SpawnedAnimal.transform.Translate(Vector3.right * Time.deltaTime);
    }

    void SpawnAnimalMethod()
    {
        Vector3 newPos = new Vector3(-15f, 0.5f, 0);
        SpawnedAnimal = Instantiate(SpawnAnimal, newPos, Quaternion.identity) as GameObject;
    }
}
