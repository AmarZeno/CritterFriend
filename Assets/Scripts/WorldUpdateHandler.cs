using UnityEngine;
using System.Collections;

public class WorldUpdateHandler : MonoBehaviour {

    public GameObject SpawnPoacher;
    public GameObject SpawnedPoacher;
    public GameObject IndicatorPrefab;
    public GameObject Indicator;
    public UIManager UIManager;
    public GameObject GameOverUI;

    public int totalAnimalsCaught;
    public int totalAnimalsSaved;
    public int maxAnimalsCaught;
    public bool isGameOver;

    // Use this for initialization
    void Start () {
        totalAnimalsCaught = 0;
        totalAnimalsSaved = 0;
        isGameOver = false;
        SpawnPoacherMethod();
        GameOverUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        float MoveForward = Input.GetAxis("Vertical");
        SpawnedPoacher.transform.Translate(Vector3.right * Time.deltaTime);
        CheckAnimalsCaught();

        if (Input.GetKeyDown(KeyCode.R)) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void SpawnPoacherMethod() {
        Vector3 newPos = new Vector3(-15f, 0.5f, 0);
        SpawnedPoacher = Instantiate(SpawnPoacher, newPos, Quaternion.identity) as GameObject;
      //  Indicator = Instantiate(IndicatorPrefab) as GameObject;
     //   Indicator.transform.parent = SpawnedPoacher.transform;
    }

    void CheckAnimalsCaught() {
        if(totalAnimalsCaught < maxAnimalsCaught ) {
        }else {
            //game over
            isGameOver = true;
            //display some game over gui
            UIManager.ActivateFinalMenu();
            
        }

        if(totalAnimalsCaught > 4)
        {
            GameOverUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void IncerementAnimalsCaught() {
        totalAnimalsCaught++;
    }

   public bool IsGameOver() {
        return isGameOver;
    }

    public void IncrementAnimalsSaved() {
        totalAnimalsSaved++;
    }

    public int GetTotalAnimalsCaught()
    {
        return totalAnimalsCaught;
    }

    public int GetTotalAnimalsSaved()
    {
        return totalAnimalsSaved;
    }
}
