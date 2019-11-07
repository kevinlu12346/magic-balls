using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;



public class Shape : MonoBehaviour
{
    public int health;
    private GameObject child;
    public static bool moveDownEndGame = true;
    public static bool moveDown = true;
    public bool ranLostFunction = false;
    float moveSpeed = 0.2f;
    private bool danger = false;
    public GameObject explosion;
    public GameObject largeExplosion;
    Animator anim;
    Animator onHitAnim;
    public GameObject onHit;
    //private Shake shake;
    public GameObject circle;

    PolygonCollider2D collider;
    SpriteRenderer renderer;
    CircleCollider2D circleCollider;
    public bool waiting = true;

    public GameObject[] myObjects;


    public Color color;
    void Start()
    {
        child = transform.Find("ShapeText").gameObject;
        ranLostFunction = false;
        moveDownEndGame = true;
        moveDown = true;
        anim = gameObject.GetComponent<Animator>();
        waiting = true;
        collider = gameObject.GetComponent<PolygonCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    void Update()
    {

        // move blocks down each frame
        if (moveDown && moveDownEndGame) {
        transform.position = new Vector2(transform.position.x, transform.position.y - (float)moveSpeed *Time.deltaTime );
        } else {
        //transform.position = new Vector2(transform.position.x, transform.position.y + (float)moveSpeed *Time.deltaTime);
        }
        if (transform.position.y <= -1.5) {
            Target.warning = true;
        }
        // lose game
        /*
        if (transform.position.y <= -3 && ranLostFunction == false) {

            ranLostFunction = true;
            //Target.gameOver = true;
            SceneTransition.gameOver = true;
            Time.timeScale = 0f;
        }
        */
        /*
        // destroy all balls
        myObjects = GameObject.FindGameObjectsWithTag("ball");
        foreach(GameObject obj in myObjects) {
            Destroy(obj);
        }
        */
    }


    void OnCollisionEnter2D(Collision2D collision) {
         if (collision.collider.tag == "redLine") {
             SceneTransition.gameOver = true;
             Time.timeScale = 0f;
         }
         if (collision.collider.tag == "ball") {

            health -= PlayerController.firePower;
            child.GetComponent<TextMeshPro>().SetText(AbbrevationUtility.AbbreviateNumber(health));

            int damageScore = 0;
            if (health > 0) {
                    onHit = transform.Find("onHitAnimation").gameObject;
                    onHitAnim = onHit.GetComponent<Animator>();

                if (waiting == true) {
                    onHitAnim.enabled = true;
                    waiting = false;
                    StartCoroutine(deactivateAfter(0.35f));
                }



                damageScore = PlayerController.firePower;
            } else if (health <= 0) {
                damageScore = health + PlayerController.firePower;
            }

            GameManager.score += damageScore;
            // if destroy circle shape then spawn an extra bullet
            if (health <= 0) {
              if (gameObject.tag == "circle") {
                Destroy(circle);
                anim.enabled = true;
                circleCollider.enabled = false;
                child = transform.Find("ShapeText").gameObject;
                child.GetComponent<TextMeshPro>().enabled = false;
                StartCoroutine(destroyAfter(0.95f));

                GameObject boom = Instantiate(explosion);
                boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                GameObject b = Instantiate(Target.bullet) as GameObject;
                Vector3 m_Position = gameObject.transform.position;
                b.transform.position = m_Position;
                b.GetComponent<Rigidbody2D>().velocity = Vector2.down * 220;
                // add player total ball count
                PlayerController.numberBalls++;
            } else if(gameObject.tag == "powerball") {

                GameObject boom = Instantiate(explosion);
                boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                //Target.isPower = true;
                Target.bulletPlaceHolder = Target.bullet;
                Target.bullet = Target.powerBall;

                TargetLeft.bullet = Target.powerBall;

                TargetRight.bullet = Target.powerBall;
                PlayerController.firePower = PlayerController.firePowerAlgorithm * 2;

                //StartCoroutine(Target.powerBallDeactivate());
                Destroy(gameObject);
            } else if (gameObject.tag == "freeze") {
                GameObject boom = Instantiate(explosion);
                boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                moveDown = false;

                DeployShapes.running = false;

                Destroy(gameObject);
                /*
                GameObject[] allObjects = GameObject.FindGameObjectsWithTag("shape");  //returns GameObject[]
                foreach (GameObject go in allObjects) {
                    Debug.Log(go.name);
                    go.
                }
                */
            } else if (gameObject.tag == "speed") {
                GameObject boom = Instantiate(explosion);
                boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                GameManager.deactivateSpeed = true;
                Destroy(gameObject);
            } else if (gameObject.tag == "money") {
                if (SceneTransition.muted == false) {
                    Target.audioSource.Play();
                }
                GameObject boom = Instantiate(explosion);
                boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                    GameManager.money++;

                anim.enabled = true;
                collider.enabled = false;
                child = transform.Find("ShapeText").gameObject;
                child.GetComponent<TextMeshPro>().enabled = false;
                StartCoroutine(destroyAfter(0.95f));
            }
            /*else if (gameObject.tag == "Large") {
                shake.camShake();
                Debug.Log("shakeeeeeeeeeeeeeeeeee");
                anim.enabled = true;
               // deactivateAfter(1f);

                collider.enabled = false;
                child = transform.Find("ShapeText").gameObject;
                child.GetComponent<TextMeshPro>().enabled = false;

                GameObject boom = Instantiate(explosion);
                boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                //Destroy(gameObject);
                StartCoroutine(destroyAfter(0.95f));
            }
            */
            else if (gameObject.tag == "Large") {
                anim.enabled = true;
                collider.enabled = false;
                child = transform.Find("ShapeText").gameObject;
                child.GetComponent<TextMeshPro>().enabled = false;

                GameObject boom = Instantiate(largeExplosion);
                boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                //Destroy(gameObject);
                StartCoroutine(destroyAfter(0.95f * 2));
            }
             else {
                 anim.enabled = true;
                // deactivateAfter(1f);

                 collider.enabled = false;
                 child = transform.Find("ShapeText").gameObject;
                 child.GetComponent<TextMeshPro>().enabled = false;

                 GameObject boom = Instantiate(explosion);
                 boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                 //Destroy(gameObject);
                 StartCoroutine(destroyAfter(0.95f));
                 //gameObject.SetActive(false);
              }
            }



        }
    }
    IEnumerator destroyAfter(float seconds) {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);

    }
    IEnumerator deactivateAfter(float seconds) {
        yield return new WaitForSeconds(seconds);
        onHitAnim.enabled = false;
        waiting = true;
        onHit = transform.Find("onHitAnimation").gameObject;
        onHit.transform.localScale = new Vector3(0,0,0);
    }

     public static class AbbrevationUtility
     {
         private static readonly SortedDictionary<long, string> abbrevations = new SortedDictionary<long, string>
         {
             {1000,"K"},
             {1000000, "M" },
             {1000000000, "B" },
             {1000000000000,"T"}
         };

         public static string AbbreviateNumber(float number)
         {
             if (number >= 10000) {
                 for (int i = abbrevations.Count - 1; i >= 0; i--)
                 {
                     KeyValuePair<long, string> pair = abbrevations.ElementAt(i);
                     if (Mathf.Abs(number) >= pair.Key)
                     {
                         int roundedNumber = Mathf.FloorToInt(number / pair.Key);
                         return roundedNumber.ToString() + pair.Value;
                     }
                 }
             }
             return number.ToString();
         }
     }

}
