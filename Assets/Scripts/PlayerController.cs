using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public GameObject shot;
    public Transform shotSpawn;
    public static int firePower = 1000;
    // base stats of actual player that never change through out the game
    public static int firePowerAlgorithm = 1000; // always == firepower doesnt change with power ups



    public static int ballsAlgorithm = 100; // base game stat never changes unless upgraded
    public static int balls = 100; // number of curr balls changes ready to shoot
    public static int numberBalls = 100; // total number of balls in current run
    private float nextFire;



    // right cannon
    public static int rightBalls = 100;
    public static int rightBallsAlgorithm = 100;
    public static int rightNumberBalls = 100; // total number of balls in current run

    // left cannon
    public static int leftBalls = 190;
    public static int leftBallsAlgorithm = 100;
    public static int leftNumberBalls = 100; // total number of balls in current run


    // Start is called before the first frame update
    void Start()
    {
        /*
        ballsAlgorithm = UpgradeMenu.numberBallsLevel;
        balls = UpgradeMenu.numberBallsLevel;
        numberBalls = UpgradeMenu.numberBallsLevel;
        firePower = UpgradeMenu.firePowerLevel;
        firePowerAlgorithm = UpgradeMenu.firePowerLevel;
        */
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(numberBalls);
    }
}
