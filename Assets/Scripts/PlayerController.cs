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
    public static int ballsAlgorithm = 20;
    //end

    public static float PlayerNumBalls = 50;
    public static float balls = 50;
    private float nextFire;



    // right cannon
    public static int rightBalls = 30;
    public static int rightPlayerNumBalls = 30;
    // left cannon
    public static int leftBalls = 40;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
