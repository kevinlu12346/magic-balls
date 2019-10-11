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
    public void pause() {
        Debug.Log("pause");
        //pauseCanvas.GetComponent<MyPauseMenu>().enabled = false;
        child = transform.Find("PauseMenu").gameObject;
        child.SetActive(true);
        Time.timeScale = 0;
        camera.GetComponent<Target>().enabled = false;


    }


    public void Update() {
/*
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
        }
*/

        if (gameOver == true) {
            child = gameCanvas.transform.Find("pauseButton").gameObject;
            child.GetComponent<Button>().enabled = false;
            this.GetComponent<MyPauseMenu>().enabled = false;
        }

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
                child = transform.Find("PauseMenu").gameObject;
                child.SetActive(false);
            }
        }


/*
        GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
        //Create the PointerEventData with null for the EventSystem
        PointerEventData ped = new PointerEventData(null);
        //Set required parameters, in this case, mouse position
        ped.position = Input.mousePosition;
        //Create list to receive all results
        List<RaycastResult> results = new List<RaycastResult>();
        //Raycast it
        gr.Raycast(mousePos2D, results);
*/

/*
        LayerMask mask = LayerMask.GetMask("button");
      RaycastHit2D hit = Physics2D.GraphicsRayCast(mousePos2D, Vector2.zero, mask);


     //if (hit.collider != null) {
         Debug.Log(hit.collider.gameObject.name);
*/
/*
        if ( hit.collider.gameObject.name != "exitButton") {
            Time.timeScale = 1f;
            camera.GetComponent<Target>().enabled = true;
            child = transform.Find("PauseMenu").gameObject;
            child.SetActive(false);
        }
    }
*/
    }

}
}
