using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("MainScene");
        }
    }
}
