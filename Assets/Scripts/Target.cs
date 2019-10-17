using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Target : MonoBehaviour
{
    public static GameObject bullet;
    public GameObject ball;
    public GameObject fireBall;
    public static float fireRate = UpgradeMenu.fireSpeedValues[0];
    private float nextFire;
    public LineRenderer lineRenderer;
    public GameObject player;
    public GameObject powerBall;
    public static bool gameOver = false;

    public static bool isPower = false;
    bool running = false;
    bool ranWarningFunction = false;

    private float nextFireRight;
    public static bool firedFireBall = false;

    public Image damageImage;
    public Image line;                          // Reference to an image to flash on the screen on being hurt.
    public float flashSpeed = 1f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public Color lineColour;
    public static bool warning = false;
    Renderer rend;
    public Material[] material;
    TrailRenderer myTrailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Target>().enabled = true;
        gameOver = false;
        isPower = false;
        warning = false;
        firedFireBall = false;



        //fireRate = UpgradeMenu.fireSpeedValues[UpgradeMenu.fireSpeedLevel - 1];
        //fireRate = UpgradeMenu.fireSpeedValues[17];
        fireRate = .02f; // change firerate here
    }

    void Awake() {
        PlayerController.balls = PlayerController.ballsAlgorithm;
        PlayerController.numberBalls = PlayerController.ballsAlgorithm;
        bullet = ball;
        PlayerController.rightBalls = PlayerController.rightBallsAlgorithm;
        PlayerController.rightNumberBalls = PlayerController.rightBallsAlgorithm;
        PlayerController.leftBalls = PlayerController.leftBallsAlgorithm;
        PlayerController.leftNumberBalls = PlayerController.leftBallsAlgorithm;


    }
    // Update is called once per frame
    void Update()
    {

        if (warning && ranWarningFunction == false) {
            ranWarningFunction = true;
            StartCoroutine(ranWarningFunctionFalse());
            damageImage.color  = flashColour;
            line.color = lineColour;
            warning = false;
        } else {
            line.color = Color.Lerp(line.color, Color.clear, flashSpeed * Time.deltaTime);

            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

/*
        if (gameOver == true) {
            gameOver = false;
            this.GetComponent<Target>().enabled = false;
            // this refers to the object which Target script is attached to so in this case it is the camera and we get the Target script component from the Camera
        }
    */
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

        // end restrict target

        Vector3 difference = mousePosition - player.transform.position;
        // angle between x axis and (x,y) in radians
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        // make player rotate to where mouse is
        //player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        lineRenderer.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        //float distance = difference.magnitude;
        //Vector2 direction = difference / distance;
        Vector2 direction = difference;
        //direction = RotateVector(direction, 20f);
        direction.Normalize();


        Vector2 rightDirection = RotateVector(direction, -10f);



        // fire fireball

        if (firedFireBall == false) {
            firedFireBall = true;
            //fireFireBall(direction, rotationZ);
        }

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
     IEnumerator ranWarningFunctionFalse() {
         yield return new WaitForSeconds(0.5f);
             ranWarningFunction = false;
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

        float radian = rotationZ*Mathf.Deg2Rad;

        float x = 0.5f * Mathf.Cos(radian);
        float y = 0.5f * Mathf.Sin(radian);
        Vector3 temp = new Vector3(x ,y ,0);
        b.transform.position += temp;

        // give bullet starting rotation
        //b.transform.rotation =  Quaternion.Euler(0.0f, 0.0f, rotationZ); // rotates circle but no matter how u rotate circle it will always be a circle
        // give bullet velocity (Direction and speed)
        b.GetComponent<Rigidbody2D>().velocity = direction;
        PlayerController.balls--;
     }


     void fireFireBall(Vector2 direction, float rotationZ) {
       GameObject b = Instantiate(fireBall) as GameObject;
       b.GetComponent<BallMovement>().type = 3;

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
