using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    // at start of program set these variables are set (i.e. start of game)
    public static int numberBallsCost = 10;
    public static int fireSpeedCost = 20;
    public static int firePowerCost = 30;

    public static int numberBallsLevel = 5;
    public static int fireSpeedLevel = 1;
    public static int firePowerLevel = 1;
    public Player player; // reference to player object in hierachy

    public static int leftFireBallCost = 20;
    public static int leftNumberBallsLevel = 0;
    public static int rightFireBallCost = 20;
    public static int rightNumberBallsLevel = 0;

    public static int largeFireBallCost = 30;
    public static int chainLightningCost = 30;

    public static float[] fireSpeedValues = {0.2f, 0.19f, 0.18f, 0.17f, 0.16f, 0.15f, 0.14f, 0.13f, 0.12f, 0.11f, 0.10f, 0.09f, 0.08f, 0.07f, 0.06f, 0.05f, 0.04f, 0.03f};
    private GameObject child;
    public GameObject game;
    public GameObject fadecanvas;

    // Start is called everytime the scene is loaded so variables are set on load
    void Start()
    {






        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(numberBallsLevel.ToString());


        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(firePowerLevel.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(fireSpeedLevel.ToString());


        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(fireSpeedCost.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(numberBallsCost.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(firePowerCost.ToString());
// skills

        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(leftNumberBallsLevel.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(rightNumberBallsLevel.ToString());

/*
        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("largeFireBall").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("chainLightning").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());
*/
        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(leftFireBallCost.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(rightFireBallCost.ToString());
/*
        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("largeFireBall").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(30.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("chainLightning").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(50.ToString());
*/
        child = game.transform.Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().text = SceneTransition.money.ToString();
        child = fadecanvas.transform.Find("panelFadeTransition").gameObject;
        child.SetActive(true);
        StartCoroutine(turnOffCanvas(0.5f));


        if (fireSpeedLevel == 18) {
            Debug.Log("maxing");
            child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("costButton").Find("moneyScore").gameObject;
            child.GetComponent<TextMeshPro>().SetText("Max");
        }
        if (firePowerLevel == 999) {

            child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("costButton").Find("moneyScore").gameObject;
            child.GetComponent<TextMeshPro>().SetText("Max");

        }
        if (numberBallsLevel == 100) {

            child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("costButton").Find("moneyScore").gameObject;
            child.GetComponent<TextMeshPro>().SetText("Max");

        }
        if (leftNumberBallsLevel == 100) {
            child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("costButton").Find("moneyScore").gameObject;
            child.GetComponent<TextMeshPro>().SetText("Max");

        }
        if (rightNumberBallsLevel == 100) {
            child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("costButton").Find("moneyScore").gameObject;
            child.GetComponent<TextMeshPro>().SetText("Max");

        }
    }

    // Update is called once per frame
    void Update()
    {
        child = game.transform.Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().text = SceneTransition.money.ToString();
    }
    public void upgradeFireSpeed() {
        if (SceneTransition.money >= fireSpeedCost && fireSpeedLevel < 18) {
            // max level is 18
            fireSpeedLevel++;
            player.fireRate++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            SceneTransition.money -= fireSpeedCost;
            player.money -= fireSpeedCost;
            if (fireSpeedLevel == 18) {
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(fireSpeedLevel.ToString());

            } else {
                fireSpeedCost += 10;
                player.fireRateCost += 10;
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(fireSpeedLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(fireSpeedCost.ToString());
            }
            player.SavePlayer();
        }
    }
    public void upgradeFirePower() {
        if (SceneTransition.money >= firePowerCost && firePowerLevel < 999) {
            // max level is 18
            firePowerLevel++;
            player.power++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            SceneTransition.money -= firePowerCost;
            player.money -= firePowerCost;

            if (firePowerLevel == 999) {


                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(firePowerLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");

            } else {


                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(firePowerLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(firePowerCost.ToString());
            }
            player.SavePlayer();

        }
    }
    public void upgradeNumberBalls() {
        if (SceneTransition.money >= numberBallsCost && numberBallsLevel < 100) {
            // max level is 18
            numberBallsLevel++;
            player.numberBalls++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            SceneTransition.money -= numberBallsCost;
            player.money -= numberBallsCost;

            if (numberBallsLevel == 100) {


                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(numberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");

            } else {
                Debug.Log("stacked");
                numberBallsCost += 10;
                player.numberBallsCost += 10;
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(numberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(numberBallsCost.ToString());
            }
            player.SavePlayer();

        }
    }
    IEnumerator turnOffCanvas(float seconds) {
        yield return new WaitForSeconds(seconds);
        child = fadecanvas.transform.Find("panelFadeTransition").gameObject;
        child.SetActive(false);
    }


    public void upgradeLeftFireball() {
        if (SceneTransition.money >= leftFireBallCost && leftNumberBallsLevel < 100) {
            // max level is 18
            leftNumberBallsLevel++;
            player.leftFireBall++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            SceneTransition.money -= leftFireBallCost;
            player.money -= leftFireBallCost;

            if (leftNumberBallsLevel == 100) {
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(leftNumberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");

            } else {

                leftFireBallCost += 5;
                player.leftFireBallCost += 5;

                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(leftNumberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(leftFireBallCost.ToString());

            }
            Debug.Log("saving");
            player.SavePlayer();

        }
    }

    public void upgradeRightFireBall() {
        if (SceneTransition.money >= rightFireBallCost && rightNumberBallsLevel < 100) {
            // max level is 18
            rightNumberBallsLevel++;
            player.rightFireBall++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            SceneTransition.money -= rightFireBallCost;
            player.money -= rightFireBallCost;

            if (rightNumberBallsLevel == 100) {
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(rightNumberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");

            } else {

                rightFireBallCost += 5;
                player.rightFireBallCost += 5;

                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(rightNumberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(rightFireBallCost.ToString());

            }
            player.SavePlayer();

        }
    }
}
