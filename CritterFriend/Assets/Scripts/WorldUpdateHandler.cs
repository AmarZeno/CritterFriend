using UnityEngine;
using System.Collections;

public class WorldUpdateHandler : MonoBehaviour {

    public GameObject SpawnPoacher;
    public GameObject SpawnedPoacher;
    public GameObject IndicatorPrefab;
    public GameObject Indicator;

    // Use this for initialization
    void Start () {
        SpawnPoacherMethod();
	}
	
	// Update is called once per frame
	void Update () {
        float MoveForward = Input.GetAxis("Vertical");
        SpawnedPoacher.transform.Translate(Vector3.right * Time.deltaTime);
    }

    void SpawnPoacherMethod()
    {
        Vector3 newPos = new Vector3(-15f, 0.5f, 0);
        SpawnedPoacher = Instantiate(SpawnPoacher, newPos, Quaternion.identity) as GameObject;
      //  Indicator = Instantiate(IndicatorPrefab) as GameObject;
     //   Indicator.transform.parent = SpawnedPoacher.transform;
    }
}
