using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private GameObject child;
    private int health = 1;
    public GameObject ball;
    public static float multiplier = 10; // not this one use other one in startmenu
    public int type;
    public static bool gameOver = false;
    Vector3 currDir;
    // Start is called before the first frame update
    void Start()
    {

        Physics2D.IgnoreLayerCollision(8,8);
        gameOver = false;
        //Time.timeScale = 1f;

    }
    void FixedUpdate()
     {
         currDir = new Vector3(transform.position.x, transform.position.y, 0);
     }
    // Update is called once per frame
    void Update()
    {
        Vector3 newDir = new Vector3(transform.position.x, transform.position.y, 0);
        float newDirValue = Mathf.Atan2(newDir.y - currDir.y, newDir.x - currDir.x);
        float newDirValueDeg = (180 / Mathf.PI) * newDirValue;
        transform.rotation = Quaternion.Euler(0, 0, newDirValueDeg);
        if (gameOver == true) {
            // pause ball movements
            //Time.timeScale = 0f;

        }
        rigidBody = GetComponent<Rigidbody2D>();


        // all balls move at a constant speed of 220
        rigidBody.velocity = 5 * (rigidBody.velocity.normalized) * multiplier;
    }


    void OnCollisionEnter2D(Collision2D collision) {
        // destroy balls if they cross the red line
        if (collision.collider.tag == "brick" && type == 1) {
          Destroy(gameObject);
          PlayerController.rightBalls++;
        }
        if (collision.collider.tag == "brick" && type == 0) {
          Destroy(gameObject);
          PlayerController.balls++;
        }
        // right ball
        if (collision.collider.tag == "brick" && type == 2) {
          Destroy(gameObject);
          PlayerController.leftBalls++;
        }
        // fireBall
        if (collision.collider.tag == "brick" && type == 3) {
            Debug.Log("bricked");
          Destroy(gameObject);
          Target.firedFireBall = false;
        }

   }


}
