using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public GameObject shot;
    public Transform shotSpawn;
    public static int firePower = 5;
    // base stats of actual player that never change through out the game
    public static int firePowerAlgorithm = 5; // always == firepower doesnt change with power ups



    public static int ballsAlgorithm = 20; // base game stat never changes unless upgraded
    public static int balls = 20; // number of curr balls changes ready to shoot
    public static int numberBalls = 20; // total number of balls in current run
    private float nextFire;



    // right cannon
    public static int rightBalls = 10;
    public static int rightBallsAlgorithm = 10;
    public static int rightNumberBalls = 10; // total number of balls in current run

    // left cannon
    public static int leftBalls = 10;
    public static int leftBallsAlgorithm = 10;
    public static int leftNumberBalls = 10; // total number of balls in current run


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
     }
}
