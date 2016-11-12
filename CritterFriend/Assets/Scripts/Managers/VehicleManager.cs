using UnityEngine;
using System;
using System.Collections;

public class VehicleManager : MonoBehaviour {

    public GameObject[] vehicles;
    public int vehicleCount;
    
    void Start()
    {
        GenerateVehicles();
    }

    IEnumerator GenerateVehicles() {
        vehicleCount = vehicles.Length;
        foreach (GameObject g in vehicles)
        {
            GameObject vehicle = Instantiate(g, gameObject.transform.position, Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(1f);
        }
    }

    
}
