using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRight : MonoBehaviour
{
    public static GameObject bullet;
    public GameObject ball;
    public GameObject fireBall;
    private float fireRate;
    private float nextFire;
    public LineRenderer lineRenderer;
    public GameObject player;
    public GameObject powerBall;

    public static bool isPower = false;
    bool running = false;


    private float nextFireRight;

    // Start is called before the first frame update
    void Start()
    {
        isPower = false;
        fireRate = UpgradeMenu.fireSpeedValues[UpgradeMenu.fireSpeedLevel - 1];
        bullet = Target.bullet;
        powerBall = Target.powerBall;
    }

    void Awake() {

        bullet = ball;

    }
    // Update is called once per frame
    void Update()
    {
         // activate power Ball POWER UP
         if (bullet == powerBall && running == false) {
            running = true;
            bullet = powerBall;
            //PlayerController.firePowerAlgorithm = PlayerController.firePower;
            //PlayerController.firePower *= 2;
            StartCoroutine(powerBallDeactivate());
        }
        // get mouse position
        Vector3 mousePosition = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        // restrict targets
        if (mousePosition.y < -3.4f) {
            mousePosition.y = -3.4f;

        }

        if (mousePosition.y <= -3.4f && mousePosition.x < 0) {
            mousePosition.y = -3.4f;
            mousePosition.x = -1f;
        }

        if (mousePosition.y <= -3.2f && mousePosition.x < -1.6) {
            mousePosition.y = -3.4f;
            mousePosition.x = -1f;
        }
        if (mousePosition.y <= -3.4f && mousePosition.x > 0) {
            mousePosition.y = -3.4f;
            mousePosition.x = 1f;
        }

        if (mousePosition.y <= -3.2f && mousePosition.x > 1.6) {
            mousePosition.y = -3.4f;
            mousePosition.x = 1f;
        }

        // angle between x axis and (x,y) in radians
        Vector3 difference = mousePosition - player.transform.position;
        // angle between x axis and (x,y) in radians
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        // make player rotate to where mouse is

        //float distance = difference.magnitude;
        //Vector2 direction = difference / distance;
        Vector2 direction = difference;
        //direction = RotateVector(direction, 20f);
        direction.Normalize();


        Vector2 rightDirection = RotateVector(direction, -2.25f);
        // fire right balls
        if (PlayerController.rightBalls <= 0) {
            return;
        } else {
            if (Time.time > nextFireRight) {
                nextFireRight = Time.time + fireRate;
                fireBulletRight(rightDirection, rotationZ);
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


     void fireBulletRight(Vector2 direction, float rotationZ) {
        //create bullet
        GameObject b = Instantiate(bullet) as GameObject;
        b.GetComponent<BallMovement>().type = 1;
        // give bullet starting position
        b.transform.position = player.transform.position;

        float radian = rotationZ*Mathf.Deg2Rad;
        float x = 0.5f * Mathf.Cos(radian);
        float y = 0.5f * Mathf.Sin(radian);
        Vector3 temp = new Vector3(x ,y ,0);
        //b.transform.position += temp;
        Vector3 pushBack = new Vector3(0,0, 0.02f);
        b.transform.position += pushBack;
        // give bullet starting rotation
        //b.transform.rotation =  Quaternion.Euler(0.0f, 0.0f, rotationZ); // rotates circle but no matter how u rotate circle it will always be a circle
        // give bullet velocity (Direction and speed)
        b.GetComponent<Rigidbody2D>().velocity = direction;
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
         yield return new WaitForSeconds(11.0f);
         PlayerController.firePower = PlayerController.firePowerAlgorithm;
         bullet = Target.bulletPlaceHolder;

         // bug fix this
         running = false;
     }
}
