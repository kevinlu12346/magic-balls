using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public GameObject shot;
    public Transform shotSpawn;
    public static int firePower = 1;
    // base stats of actual player that never change through out the game
    public static int firePowerAlgorithm = 1; // always == firepower doesnt change with power ups



    public static int ballsAlgorithm = 5; // base game stat never changes unless upgraded
    public static int balls = 5; // number of curr balls changes ready to shoot
    public static int numberBalls = 5; // total number of balls in current run
    private float nextFire;



    // right cannon
    public static int rightBalls = 0;
    public static int rightBallsAlgorithm = 0;
    public static int rightNumberBalls = 0; // total number of balls in current run

    // left cannon
    public static int leftBalls = 0;
    public static int leftBallsAlgorithm = 0;
    public static int leftNumberBalls = 0; // total number of balls in current run


    // Start is called before the first frame update
    void Start()
    {

        ballsAlgorithm = UpgradeMenu.numberBallsLevel;
        balls = UpgradeMenu.numberBallsLevel;
        numberBalls = UpgradeMenu.numberBallsLevel;

        firePower = UpgradeMenu.firePowerLevel;
        firePowerAlgorithm = UpgradeMenu.firePowerLevel;


        leftBallsAlgorithm = UpgradeMenu.leftNumberBallsLevel;
        leftBalls = UpgradeMenu.leftNumberBallsLevel;
        leftNumberBalls = UpgradeMenu.leftNumberBallsLevel;
        rightBallsAlgorithm = UpgradeMenu.rightNumberBallsLevel;
        rightBalls = UpgradeMenu.rightNumberBallsLevel;
        rightNumberBalls = UpgradeMenu.rightNumberBallsLevel;
    }

    // Update is called once per frame
    void Update()
    {
     }
}
