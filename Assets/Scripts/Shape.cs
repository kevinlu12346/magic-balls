using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shape : MonoBehaviour
{
    public int health;
    private GameObject child;
    public GameObject bullet;
    public static bool moveDownEndGame = true;
    public static bool moveDown = true;
    public bool ranLostFunction = false;
    float moveSpeed = 0.2f;
    private bool danger = false;
    public GameObject powerBall;
    public GameObject ball;
    public GameObject explosion;




    void Start()
    {
        child = transform.Find("ShapeText").gameObject;



    }

    void Update()
    {
        // move blocks down each frame
        if (moveDown && moveDownEndGame) {
        transform.position = new Vector2(transform.position.x, transform.position.y - (float)moveSpeed *Time.deltaTime);
        } else {
        //transform.position = new Vector2(transform.position.x, transform.position.y + (float)moveSpeed *Time.deltaTime);
        }

        // lose game
        if (transform.position.y <= -2.5 && ranLostFunction == false) {
            ranLostFunction = true;
            Target.gameOver = true;
            MyPauseMenu.gameOver = true;
            //GameManager.score = 0;
            SceneTransition.gameOver = true;
        }
    }


    void OnCollisionEnter2D(Collision2D collision) {

         if (collision.collider.tag == "ball") {
            health -= PlayerController.firePower;
            child.GetComponent<TextMeshPro>().SetText(health.ToString());
            int damageScore = 0;
            if (health > 0) {
                damageScore = PlayerController.firePower;
            } else if (health <= 0) {
                damageScore = health + PlayerController.firePower;
            }
            GameManager.score += damageScore;
            // if destroy circle shape then spawn an extra bullet
            if (health <= 0) {
              if (gameObject.tag == "circle") {
                GameObject boom = Instantiate(explosion);
                boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
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
                Destroy(gameObject);
            } else if (gameObject.tag == "freeze") {
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
                GameManager.deactivateSpeed = true;
                Destroy(gameObject);
            } else if (gameObject.tag == "money") {
                GameManager.money++;
                Destroy(gameObject);
            }
             else {
                 GameObject boom = Instantiate(explosion);
                 boom.transform.position = new Vector3(transform.position.x, transform.position.y, -5.39f);
                 Destroy(gameObject);

                 //gameObject.SetActive(false);
              }
            }



        }
    }



}
