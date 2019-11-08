using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

 public class SceneTransition : MonoBehaviour
{
    public Player player;
    // 0 = startMenu
    // 1 = game
    public GameObject camera;
    public GameObject pauseCanvas;
    public GameObject reviveCanvas;
    public GameObject gameOverCanvas;
    public GameObject canvas;
    public googleads ga;

    private GameObject child;
    public static bool gameOver = false;

    public static string currBall = "greyBall";
    public static string currTheme = "colorful";
    public static bool muted = false;
    private bool x = false;
    public static int highScore = 0;
    public static int money = 0;
    public void LoadCredits() {
        SceneManager.LoadScene(4);

    }
    public void LoadThemePage () {
        SceneManager.LoadScene(3);
    }

    public void loadGame() {
        if (GameManager.score > SceneTransition.highScore) {
            SceneTransition.highScore = GameManager.score;
        }

        SceneManager.LoadScene(0);
    }

    public void loadUpgradePage() {
        SceneManager.LoadScene(2);
    }

    void Awake()
    {

        gameOver = false;

        x = false;
        StartCoroutine(turnOffx(0.5f));

    }

    void Update()
    {
        //Debug.Log("ball is " + currBall);
        /*
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetMouseButtonDown(0)  && scene.buildIndex == 0) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            if(EventSystem.current.IsPointerOverGameObject())
            {
                // clicked on button
                Debug.Log("clicked on UI with tag invisible");
                if (EventSystem.current.currentSelectedGameObject != null) {
                    Debug.Log(EventSystem.current.currentSelectedGameObject.name);

                    if (EventSystem.current.currentSelectedGameObject.name == "upgradeButton") {
                        Debug.Log("destank");
                    }
                } else {
                    // start game
                    SceneManager.LoadScene(1);
                }
            }
        }
        */
/*
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetMouseButtonDown(0) && scene.buildIndex == 0) {

          Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

          RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


          if (EventSystem.current.IsPointerOverGameObject()) {
              // click upgrade button load upgrade page
              Debug.Log(EventSystem.current.currentSelectedGameObject);
          }
           else if (hit.collider != null) {
              // else start game
              if (hit.collider.gameObject.name == "background") {


                  // start game
                  //child = canvas.transform.Find("Game").gameObject;
                  //child.SetActive(true);
                  SceneManager.LoadScene(1);
               }
              //hit.collider.attachedRigidbody.AddForce(Vector2.up);
          }
      }
      */
      Scene scene = SceneManager.GetActiveScene();


      if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && scene.buildIndex == 0 && x == true) {
               if (IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {
                       Debug.Log("Hit UI, Ignore Touch");
               } else {
                       Debug.Log("Handle Touch");
                       SceneManager.LoadScene(1);
               }
      }





        if (gameOver == true && GameManager.playedVideoAD == false) {
            Debug.Log("game over");
            gameOver = false;
            child = reviveCanvas.transform.Find("revivePanel").gameObject;
            child.SetActive(true);
            camera.GetComponent<Target>().enabled = false;
            camera.GetComponent<TargetRight>().enabled = false;
            camera.GetComponent<TargetLeft>().enabled = false;
            //child = canvas.transform.Find("Game").gameObject;
            //child.SetActive(false);

            Shape.moveDownEndGame = false;
            //StartCoroutine(loadEndGamePanel());
        } else if (gameOver == true && GameManager.playedVideoAD == true) {
            gameOver = false;
            child = gameOverCanvas.transform.Find("gameOverPanel").gameObject;
            child.SetActive(true);
            camera.GetComponent<Target>().enabled = false;
            camera.GetComponent<TargetRight>().enabled = false;
            camera.GetComponent<TargetLeft>().enabled = false;
            //child = canvas.transform.Find("Game").gameObject;
            //child.SetActive(false);

            Shape.moveDownEndGame = false;
        }
        /*
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("dankerino");
            if (Time.timeScale == 1f) {
                Time.timeScale = 0;
                this.GetComponent<Target>().enabled = false;
                SceneManager.LoadScene(3);

            } else {
                Time.timeScale = 1f;
                this.GetComponent<Target>().enabled = true;
                SceneManager.LoadScene(1);
            }
        }
*/

    }

         IEnumerator loadEndGamePanel() {
             Debug.Log("loadingendpanel");
             Time.timeScale = 1f;
             yield return new WaitForSeconds(5.0f);
             Debug.Log("after 5 secs");
             child = gameOverCanvas.transform.Find("gameOverPanel").gameObject;
             child.SetActive(true);
             child = reviveCanvas.transform.Find("revivePanel").gameObject;
             child.SetActive(false);
         }
         IEnumerator turnOffx(float seconds) {
             yield return new WaitForSeconds(seconds);
             x = true;
         }
         public

         bool IsPointerOverGameObject( int fingerId )
         {
            EventSystem eventSystem = EventSystem.current;
            return ( eventSystem.IsPointerOverGameObject( fingerId )
                && eventSystem.currentSelectedGameObject != null );
         }

}
