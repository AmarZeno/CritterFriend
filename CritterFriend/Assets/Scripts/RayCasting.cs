using UnityEngine;
using System.Collections;

public class RayCasting : MonoBehaviour {
    public Camera camera;
    public UIManager uiManager;
    private int count=0;
    // Use this for initialization
    void Start () {
        uiManager.countText.text = "Pets saved: " + count.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {           
            if(hit.transform.name.Equals("Animal") && hit.distance < 2f && (hit.transform.gameObject.activeSelf))
            {
                GameObject.FindGameObjectWithTag("CollidedText");
                uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
                uiManager.text_for_capture_collision.text = "Player saved the pet";
                uiManager.EnableTextCollision();
                print("I'm looking at " + hit.transform.name);
                count += 1;
                hit.transform.gameObject.SetActive(false);
                uiManager.countText.text = "Pets saved: " + count.ToString(); 
            }
        }           
        else
            print("I'm looking at nothing!");
    }
}
