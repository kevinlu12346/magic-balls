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

    public static bool isPower = false;
    bool running = false;

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
         if (bullet == powerBall && running == false) {
            running = true;
            bullet = powerBall;
            PlayerController.firePowerAlgorithm = PlayerController.firePower;
            PlayerController.firePower *= 2;
            StartCoroutine(powerBallDeactivate());
        }
        //Debug.Log("dank");
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



        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

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

     void fireBullet(Vector2 direction, float rotationZ) {
         Debug.Log("firing");
        //create bullet
        GameObject b = Instantiate(bullet) as GameObject;
        // give bullet starting position
        b.transform.position = player.transform.position;
        // give bullet starting rotation
        b.transform.rotation =  Quaternion.Euler(0.0f, 0.0f, rotationZ);
        // give bullet velocity (Direction and speed)
        b.GetComponent<Rigidbody2D>().velocity = direction;
        PlayerController.balls--;
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
