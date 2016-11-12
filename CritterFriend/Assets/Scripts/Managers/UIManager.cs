/*this script is on UIManager*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIManager : MonoBehaviour {

    public Text text_for_capture_collision;
    public Text countText;

    void Start() {
        if(text_for_capture_collision == null) {
            Debug.Log("Text collision empty");
        }else {
            text_for_capture_collision.enabled = false;
        }
        
    }

    /*is called by the Poacher class*/
    public void EnableTextCollision() {
        //text_for_capture_collision.enabled = true;
    }

    public void SetTextForTextCollision(string text) {
        //text_for_capture_collision.text = text;
    }
}
