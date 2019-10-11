using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static GameObject bullet;
    public GameObject ball;
    public GameObject fireBall;
    public float fireRate;
    private float nextFire;
    public LineRenderer lineRenderer;
    public GameObject player;
    public GameObject powerBall;
    public static bool gameOver = false;

    public static bool isPower = false;
    bool running = false;


    private float nextFireRight;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake() {
        PlayerController.balls = PlayerController.ballsAlgorithm;
        PlayerController.PlayerNumBalls = PlayerController.ballsAlgorithm;
        GameManager.score = 0;
        bullet = ball;

    }
    // Update is called once per frame
    void Update()
    {

        if (gameOver == true) {
            this.GetComponent<Target>().enabled = false;
            // this refers to the object which Target script is attached to so in this case it is the camera and we get the Target script component from the Camera
        }
         // activate power Ball POWER UP
         if (bullet == powerBall && running == false) {
            running = true;
            bullet = powerBall;
            PlayerController.firePowerAlgorithm = PlayerController.firePower;
            PlayerController.firePower *= 2;
            StartCoroutine(powerBallDeactivate());
        }
        // get mouse position
        Vector3 mousePosition = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));

        // restrict targets
        if (mousePosition.y < -2.5f) {
            mousePosition.y = -2.5f;
        }
        if (mousePosition.x <= -3) {
            mousePosition.x = -3;
        }
        if (mousePosition.x >= 3) {
            mousePosition.x = 3;
        }
        // end restrict target

        Vector3 difference = mousePosition - player.transform.position;
        // angle between x axis and (x,y) in radians
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        // make player rotate to where mouse is
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        //float distance = difference.magnitude;
        //Vector2 direction = difference / distance;
        Vector2 direction = difference;
        //direction = RotateVector(direction, 20f);
        direction.Normalize();


        Vector2 rightDirection = RotateVector(direction, -10f);



        // fire fireball
        /*
        if (Input.GetMouseButtonDown(0)){
            fireFireBall(direction, rotationZ);
        }
        */
        // fire ball
        if (PlayerController.balls <= 0) {
          return;
        } else {
            if (Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                fireBullet(direction, rotationZ);
            }
        }




     }

     public Vector2 RotateVector(Vector2 v, float angle)
     {
         float radian = angle*Mathf.Deg2Rad;
         float _x = v.x*Mathf.Cos(radian) - v.y*Mathf.Sin(radian);
         float _y = v.x*Mathf.Sin(radian) + v.y*Mathf.Cos(radian);
         return new Vector2(_x,_y);
     }
     void fireBullet(Vector2 direction, float rotationZ) {
        //create bullet
        GameObject b = Instantiate(bullet) as GameObject;
        b.GetComponent<BallMovement>().type = 0;
        // give bullet starting position
        b.transform.position = player.transform.position;
        // give bullet starting rotation
        //b.transform.rotation =  Quaternion.Euler(0.0f, 0.0f, rotationZ); // rotates circle but no matter how u rotate circle it will always be a circle
        // give bullet velocity (Direction and speed)
        b.GetComponent<Rigidbody2D>().velocity = direction;
        PlayerController.balls--;
     }

     void fireBulletRight(Vector2 direction, float rotationZ) {
        //create bullet
        GameObject b = Instantiate(bullet) as GameObject;
        b.GetComponent<BallMovement>().type = 1;
        // give bullet starting position
        b.transform.position = player.transform.position;
        // give bullet starting rotation
        //b.transform.rotation =  Quaternion.Euler(0.0f, 0.0f, rotationZ); // rotates circle but no matter how u rotate circle it will always be a circle
        // give bullet velocity (Direction and speed)
        b.GetComponent<Rigidbody2D>().velocity = direction;
        Debug.Log("fire right");
        PlayerController.rightBalls--;
     }

     void fireFireBall(Vector2 direction, float rotationZ) {
       GameObject b = Instantiate(fireBall) as GameObject;
       b.transform.position = player.transform.position;
       Vector3 temp = new Vector3(0.0f,1f,0);

       b.transform.position += temp;
       b.transform.rotation =  Quaternion.Euler(0.0f, 0.0f, rotationZ);
       b.GetComponent<Rigidbody2D>().velocity = direction;
     }

     IEnumerator powerBallDeactivate() {
         Debug.Log("entered");
         yield return new WaitForSeconds(10.0f);
         PlayerController.firePower = PlayerController.firePowerAlgorithm;
         bullet = ball;
         running = false;
     }
}
