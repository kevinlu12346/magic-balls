using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MyPauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    private GameObject child;
    //public GameObject pauseCanvas;
    // Update is called once per frame
    public GameObject camera;
    public GameObject gameCanvas;

    public static bool gameOver = false;
    public void Start() {
        gameOver = false;
        isPaused = false;
    }

    public void Update() {
/*
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
        }
*/
 /*
        if (gameOver == true) {
            gameOver = false;
            child = gameCanvas.transform.Find("pauseButton").gameObject;
            child.GetComponent<Button>().enabled = false;
            this.transform.Find("MyPauseMenu").GetComponent<MyPauseMenu>().enabled = false;
        } else if (gameOver == false) {
            child = gameCanvas.transform.Find("pauseButton").gameObject;
            child.GetComponent<Button>().enabled = true;
            this.GetComponent<MyPauseMenu>().enabled = true;
        }
*/
        if (Input.GetMouseButtonDown(0)) {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        //RaycastHit2D[] hits;
        //hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
        // Check if the mouse was clicked over a UI element
        if(EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("clicked on UI with tag invisible");
            if (EventSystem.current.currentSelectedGameObject != null) {
                Debug.Log(EventSystem.current.currentSelectedGameObject.name);

                if (EventSystem.current.currentSelectedGameObject.name == "exitButton") {
                    Debug.Log("destank");
                }

            } else {
                // resume game
                Time.timeScale = 1f;
                camera.GetComponent<Target>().enabled = true; // stop player aimer
                this.transform.gameObject.SetActive(false);

            }
        }

    }

}
}
