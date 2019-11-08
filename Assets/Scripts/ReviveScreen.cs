using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReviveScreen : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject[] myObjects;
    public GameObject explosion;

    public GameObject camera;
    public GameObject canvas;

    private GameObject child;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

//        if (Input.GetMouseButtonDown(0)) {
//            revive();
            /*
            this.transform.gameObject.SetActive(false);
            gameOverPanel.transform.gameObject.SetActive(true);
            */
    //    }

        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
                 if (IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {
                         Debug.Log("Hit UI, Ignore Touch");
                 } else {
                         Debug.Log("Handle Touch");
                         this.transform.gameObject.SetActive(false);
                         gameOverPanel.transform.gameObject.SetActive(true);
                 }
        }

    }
    public void revive() {
        Time.timeScale = 1f;
        string[] tagsToDisable =  {"shape", "circle", "money", "freeze", "powerball", "speed", "Large"};
        foreach(string s in tagsToDisable) {
            myObjects = GameObject.FindGameObjectsWithTag(s);
                foreach(GameObject obj in myObjects) {
                    if (obj.transform.position.y <= 4) {
                        if (obj.tag == "Large") {
                            GameObject boom = Instantiate(obj.GetComponent<Shape>().largeExplosion);
                            float x = obj.transform.position.x;
                            float y = obj.transform.position.y;
                            boom.transform.position = new Vector3(x, y, -5.39f);
                        } else if (obj.tag == "shape" || obj.tag == "circle" || obj.tag == "money"){
                            GameObject boom = Instantiate(obj.GetComponent<Shape>().explosion);
                            float x = obj.transform.position.x;
                            float y = obj.transform.position.y;
                            boom.transform.position = new Vector3(x, y, -5.39f);
                        }

                        Destroy(obj);

                    }
                }
        }

            camera.GetComponent<Target>().enabled = true;
            camera.GetComponent<TargetRight>().enabled = true;
            camera.GetComponent<TargetLeft>().enabled = true;
            child = canvas.transform.Find("Game").gameObject;
            child.SetActive(true);

            Shape.moveDownEndGame = true;


        this.transform.gameObject.SetActive(false);
    }

    bool IsPointerOverGameObject( int fingerId )
    {
       EventSystem eventSystem = EventSystem.current;
       return ( eventSystem.IsPointerOverGameObject( fingerId )
           && eventSystem.currentSelectedGameObject != null );
    }
}
