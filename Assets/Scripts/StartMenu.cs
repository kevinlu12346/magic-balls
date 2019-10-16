using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour
{

    public GameObject game;
    private GameObject child;
    // Start is called before the first frame update
    void Start()
    {

        child = game.transform.Find("highscore").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(GameManager.highScore.ToString());


        child = game.transform.Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().text = GameManager.money.ToString();
        // reset game variables
        Time.timeScale = 1f;
        PlayerController.firePower = PlayerController.firePowerAlgorithm;
        BallMovement.multiplier = 1f;
        Shape.moveDown = true;
        DeployShapes.running = true;
        Target.isPower = false;
        DeployShapes.nLine = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

}
