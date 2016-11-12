using UnityEngine;
using System.Collections;

public class VehicleManager : MonoBehaviour
{

    public GameObject[] vehicles;

    public float currentTimer;
    public float maxTimer;

    void Start()
    {
        currentTimer = Time.deltaTime;
        StartCoroutine(GenerateVehicles());
    }

    void Update() {
        if (currentTimer > maxTimer) {
            currentTimer = 0f;
            Debug.Log("yeah, timer is over");

        }
        currentTimer += Time.deltaTime * 1f;
    }

    IEnumerator GenerateVehicles()
    {
        foreach (GameObject g in vehicles) {
            yield return new WaitForSeconds(4f);
        }
    }
}