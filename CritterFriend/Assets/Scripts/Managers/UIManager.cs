/*this script is on UIManager*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIManager : MonoBehaviour {

    public Text text_Poacher_Target_collision;

    void Start() {
        if(text_Poacher_Target_collision == null) {
            Debug.Log("Text collision empty");
        }else {
            text_Poacher_Target_collision.enabled = false;
        }
        
    }

    /*is called by the Poacher class*/
    public void EnableTextCollision() {
        text_Poacher_Target_collision.enabled = true;
    }
}
