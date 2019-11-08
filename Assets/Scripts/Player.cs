using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int fireRate = 1;
    public int power = 1;
    public int numberBalls = 5;
    public int powerCost = 30;
    public int fireRateCost =20;
    public int numberBallsCost = 10;


    public int leftFireBall = 0;
    public int rightFireBall = 0;
    public int leftFireBallCost = 20;
    public int rightFireBallCost = 20;


    public string ballTheme = "greyBall";
    public string squareTheme = "colorful";

    public bool muted = false;

    public int highscore = 0;
    public int money = 0;


    // Start is called before the first frame update
    void Awake()
    {
        LoadPlayer();
        SceneTransition.highScore = highscore;
        SceneTransition.money = money;
        if (ballTheme != null ) {
        SceneTransition.currBall = ballTheme;
        }
        if (squareTheme !=null) {
            SceneTransition.currTheme = squareTheme;
        }

        UpgradeMenu.firePowerLevel = power;
        UpgradeMenu.firePowerCost = powerCost;

        UpgradeMenu.fireSpeedLevel = fireRate;
        UpgradeMenu.fireSpeedCost = fireRateCost;

        UpgradeMenu.numberBallsLevel = numberBalls;
        UpgradeMenu.numberBallsCost = numberBallsCost;

        UpgradeMenu.leftNumberBallsLevel = leftFireBall;
        UpgradeMenu.leftFireBallCost = leftFireBallCost;

        UpgradeMenu.rightNumberBallsLevel = rightFireBall;
        UpgradeMenu.rightFireBallCost = rightFireBallCost;
    }



    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();
        power = data.power;
        fireRate = data.fireRate;
        numberBalls = data.numberBalls;
        fireRateCost = data.fireRateCost;
        powerCost = data.powerCost;
        numberBallsCost = data.numberBallsCost;
        leftFireBall = data.leftFireBallCost;
        rightFireBall = data.rightFireBallCost;

        ballTheme = data.ballTheme;
        squareTheme = data.squareTheme;
        muted = data.muted;

        money = data.money;
        highscore = data.highscore;
    }
/*
    fire rate
    power
    number balls

    left
    rightBalls

    highscore
    money

    balltheme
    squaretheme

    ismuted
*/
    // Update is called once per frame
    void Update()
    {

    }
}
