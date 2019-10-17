using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour
{

    public GameObject game;
    private GameObject child;
    // Start is called before the first frame update
    public GameObject canvas;
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
        child = canvas.transform.Find("panelFadeTransition").gameObject;
        child.SetActive(true);
        StartCoroutine(turnOffCanvas(0.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator turnOffCanvas(float seconds) {
        yield return new WaitForSeconds(seconds);
        child = canvas.transform.Find("panelFadeTransition").gameObject;
        child.SetActive(false);

    }
}
