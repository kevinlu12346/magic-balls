using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    public static int numberBallsCost = 10;
    public static int fireSpeedCost = 20;
    public static int firePowerCost = 30;

    public static int numberBallsLevel = 5;
    public static int fireSpeedLevel = 1;
    public static int firePowerLevel = 1;


    public static int leftFireBallCost = 20;
    public static int leftNumberBallsLevel = 1;
    public static int rightFireBallCost = 20;
    public static int rightNumberBallsLevel = 1;

    public static int largeFireBallCost = 30;
    public static int chainLightningCost = 30;

    public static float[] fireSpeedValues = {0.2f, 0.19f, 0.18f, 0.17f, 0.16f, 0.15f, 0.14f, 0.13f, 0.12f, 0.11f, 0.10f, 0.09f, 0.08f, 0.07f, 0.06f, 0.05f, 0.04f, 0.03f};
    private GameObject child;
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(5.ToString());


        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());


        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(20.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(10.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(30.ToString());
// skills

        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("largeFireBall").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("chainLightning").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(20.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(20.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("largeFireBall").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(30.ToString());
        child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("chainLightning").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(50.ToString());

        child = game.transform.Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().text = GameManager.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        child = game.transform.Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().text = GameManager.money.ToString();
    }
    public void upgradeFireSpeed() {
        if (GameManager.money >= fireSpeedCost && fireSpeedLevel < 18) {
            // max level is 18
            fireSpeedLevel++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            GameManager.money -= fireSpeedCost;
            if (fireSpeedLevel == 18) {
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(fireSpeedLevel.ToString());

            } else {
                fireSpeedCost += 10;
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(fireSpeedLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(fireSpeedCost.ToString());
            }
        }
    }
    public void upgradeFirePower() {
        if (GameManager.money >= firePowerCost && firePowerLevel < 999) {
            // max level is 18
            firePowerLevel++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            GameManager.money -= firePowerCost;
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
        }
    }
    public void upgradeNumberBalls() {
        if (GameManager.money >= numberBallsCost && numberBallsLevel < 100) {
            // max level is 18
            numberBallsLevel++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            GameManager.money -= numberBallsCost;
            if (numberBallsLevel == 100) {


                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(numberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");

            } else {

                numberBallsCost += 10;
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(numberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(numberBallsCost.ToString());
            }
        }
    }

    public void upgradeLeftFireball() {
        if (GameManager.money >= leftFireBallCost && leftNumberBallsLevel < 100) {
            // max level is 18
            leftNumberBallsLevel++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            GameManager.money -= leftFireBallCost;
            if (leftNumberBallsLevel == 100) {
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(leftNumberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");

            } else {

                leftFireBallCost += 5;

                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(leftNumberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("leftFireBall").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(leftFireBallCost.ToString());

            }
        }
    }

    public void upgradeRightFireBall() {
        if (GameManager.money >= rightFireBallCost && rightNumberBallsLevel < 100) {
            // max level is 18
            rightNumberBallsLevel++;
            //Target.fireRate = fireSpeedValues[fireSpeedLevel - 1];
            GameManager.money -= rightFireBallCost;
            if (rightNumberBallsLevel == 100) {
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(rightNumberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText("Max");

            } else {

                rightFireBallCost += 5;

                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("level").Find("levelText").gameObject;
                child.GetComponent<TextMeshProUGUI>().SetText(rightNumberBallsLevel.ToString());
                child = transform.Find("Image").Find("scrollCanvas").Find("skillsPanel").Find("rightFireBall").Find("costButton").Find("moneyScore").gameObject;
                child.GetComponent<TextMeshPro>().SetText(rightFireBallCost.ToString());

            }
        }
    }
}
