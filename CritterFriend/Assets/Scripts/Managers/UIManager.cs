/*this script is on UIManager*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIManager : MonoBehaviour {

    public Text text_for_capture_collision;
    public Text countText;
    public GameObject button_Restart;
    public GameObject image_quote;

    void Start() {
        if(text_for_capture_collision == null) {
            Debug.Log("Text collision empty");
        }else {
            text_for_capture_collision.enabled = false;
        }
        image_quote.SetActive(false);
        button_Restart.SetActive(false);
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
}
