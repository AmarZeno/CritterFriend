/*this script is on UIManager*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIManager : MonoBehaviour {

    public Text text_for_capture_collision;
    public Text countText;
    public GameObject button_Restart;
    public GameObject image_quote;
    public WorldUpdateHandler gameManager;

    public Text animalsSaved;
    public Text animalsCaptured;


    void Start() {
        if(text_for_capture_collision == null) {
            Debug.Log("Text collision empty");
        }else {
            text_for_capture_collision.enabled = false;
        }
        image_quote.SetActive(false);
        button_Restart.SetActive(false);
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<WorldUpdateHandler>();
    }


    void Update()
    {
        int petsSaved = gameManager.totalAnimalsSaved;
        animalsSaved.text = "Pets Saved: " + petsSaved.ToString();

        int petsCaught = gameManager.totalAnimalsCaught;
        animalsCaptured.text = "Pets Captured: " + petsCaught.ToString();
    }
    /*is called by the Poacher class*/
    public void EnableTextCollision() {
        //text_for_capture_collision.enabled = true;
    }

    public void SetTextForTextCollision(string text) {
        //text_for_capture_collision.text = text;
    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel); 
    }

    public void ActivateFinalMenu()
    {
        button_Restart.SetActive(true);
        image_quote.SetActive(true);
    }
}
