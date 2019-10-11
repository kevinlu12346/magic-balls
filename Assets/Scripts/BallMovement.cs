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
    public static float multiplier = 1;
    public int type;
    // Start is called before the first frame update
    void Start()
    {

        Physics2D.IgnoreLayerCollision(8,8);
    }

    // Update is called once per frame
    void Update()
    {
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


        /*
        if (collision.collider.tag == "powerball") {
            Debug.Log("hi"+collision.collider.GetComponent<Shape>().health);
            if (collision.collider.GetComponent<Shape>().health <= 0) {
                Debug.Log("skyed");
                StartCoroutine(powerBallDeactivate());
                Destroy(collision.gameObject);

            }
        }
    }
    IEnumerator powerBallDeactivate() {
        Debug.Log("entered");
        yield return new WaitForSeconds(2.0f);
        Target.bullet = ball;
    }





    if (collision.collider.tag == "ball") {
       health -= PlayerController.firePower;
       child.GetComponent<TextMeshPro>().SetText(health.ToString());


       // if destroy circle shape then spawn an extra bullet
       if (health <= 0) {
         if (gameObject.tag == "circle") {
           Destroy(gameObject);
           GameObject b = Instantiate(bullet) as GameObject;
           Vector3 m_Position = gameObject.transform.position;
           b.transform.position = m_Position;
           b.GetComponent<Rigidbody2D>().velocity = Vector2.down * 220;
           // add player total ball count
           PlayerController.PlayerNumBalls++;
       } else if(gameObject.tag == "powerball") {
           Target.isPower = true;
           Target.bullet = powerBall;
           //StartCoroutine(Target.powerBallDeactivate());
           //Destroy(gameObject);
       } else {
           Destroy(gameObject);
         }
       }


*/
   }


}
