using UnityEngine;
using System.Collections;

public class RayCasting : MonoBehaviour {
    public Camera camera;
    public UIManager uiManager;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {           
            if(hit.transform.name.Equals("Animal") && hit.distance < 2f)
            {
                GameObject.FindGameObjectWithTag("CollidedText");
                uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
                uiManager.text_for_capture_collision.text = "Player saved the pet";
                uiManager.EnableTextCollision();
                print("I'm looking at " + hit.transform.name);
            }
        }           
        else
            print("I'm looking at nothing!");
    }
}
