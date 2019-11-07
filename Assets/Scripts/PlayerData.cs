using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PlayerData
{
    public int fireRate;
    public int power;
    public int numberBalls;
    public int powerCost;
    public int fireRateCost;
    public int numberBallsCost;


    public int leftFireBall;
    public int rightFireBall;
    public int leftFireBallCost;
    public int rightFireBallCost;

    public string ballTheme;
    public string squareTheme;

    public bool muted;

    public int money;
    public int highscore;

    public PlayerData (Player player) {
        fireRate = player.fireRate;
        power = player.power;
        numberBalls = player.numberBalls;
        powerCost = player.powerCost;
        fireRateCost = player.fireRateCost;
        numberBallsCost = player.numberBallsCost;


        leftFireBall = player.leftFireBall;
        rightFireBall = player.rightFireBall;
        leftFireBallCost = player.leftFireBallCost;
        rightFireBallCost = player.rightFireBallCost;

        ballTheme = player.ballTheme;
        squareTheme = player.squareTheme;

        muted = player.muted;



        money = player.money;
        highscore = player.highscore;
    }
}
