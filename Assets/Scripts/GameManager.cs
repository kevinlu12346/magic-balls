using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject startMenu;
    public GameObject gameOverMenu;
    public GameObject respawnMenu;
    public GameObject upgradeMenu;
    public GameObject child;
    public GameObject childMoney;

    public static int score;
    public static bool deactivateSpeed = false;
    public static int highScore = 0;
    public static int money = 0;

    public enum PageState {
        start,
        game,
        gameover,
        respawn,
        upgrade
    }
    public static PageState currentState;

    public GameObject game;

    public static bool frozen = false;
    bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PageState.start;
        //game.GetComponent<DeployShapes>().enabled = false;
        //this.GetComponent<Target>().enabled = false;
     }

    // Update is called once per frame
    void Update()
    {
        // update score
        child = game.transform.Find("score").gameObject;
        child.GetComponent<TextMeshPro>().text = GameManager.score.ToString();
        if (Shape.moveDown == false) {
            StartCoroutine(moveDownDeactivate());
        }
        if (deactivateSpeed == true) {
            deactivateSpeed = false;
            BallMovement.multiplier = 2f;
            StartCoroutine(speedDeactivate());
        }

        childMoney = game.transform.Find("moneyScore").gameObject;
        childMoney.GetComponent<TextMeshPro>().text = GameManager.money.ToString();









/*
        if (Input.GetMouseButtonDown(0))
      {
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          RaycastHit hitInfo;
          if (Physics.Raycast(ray, out hitInfo))
          {
              if (hitInfo.collider.gameObject.tag == "Background")
              {
                  Debug.Log("tag");
              }
          }
      }

      */
    }

    IEnumerator speedDeactivate() {
        yield return new WaitForSeconds(10.0f);
        Debug.Log("Slowed");
        BallMovement.multiplier = 1f;
    }

     IEnumerator moveDownDeactivate() {
         yield return new WaitForSeconds(10.0f);
         Shape.moveDown = true;
         DeployShapes.running = true;

     }

    public void  confirmGameOver() {
        // activated when
        // reset game variables
    }
    public void startGame() {
        // activated when you touch the screen

    }
}
