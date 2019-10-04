using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    // 0 = startMenu
    // 1 = game
    public GameObject camera;
    public GameObject pauseCanvas;
    public void hel () {
        Debug.Log("hel)");
        //pauseCanvas.GetComponent<MyPauseMenu>().enabled = false;
    }

    public void loadGame() {
        Debug.Log("dankaaaaaaaaaaaaaaaaaaaaaaaaaa");
        if (GameManager.score > GameManager.highScore) {
            GameManager.highScore = GameManager.score;
        }
        SceneManager.LoadScene(0);
    }
    void Start()
    {
    }

    void Update()
    {
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
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetMouseButtonDown(0) && scene.buildIndex == 0) {

          Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

          RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
          if (hit.collider != null) {

              if (hit.collider.gameObject.name == "background") {
                  /*
                  currentState = PageState.game;
                  //Debug.Log("change to gamestate");
                  startMenu.SetActive(false);
                  game.GetComponent<DeployShapes>().enabled = true;
                  this.GetComponent<Target>().enabled = true;
                  */
                  SceneManager.LoadScene(1);
               }
              //hit.collider.attachedRigidbody.AddForce(Vector2.up);
          }
      }
    }

}
