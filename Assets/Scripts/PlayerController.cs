using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public static int firePower = 1;

    // base stats of actual player that never change through out the game
    public static int firePowerAlgorithm = 1; // always == firepower doesnt change with power ups
    public static int ballsAlgorithm = 5;
    //end

    public static float PlayerNumBalls = 5;
    public static float balls = 5;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
