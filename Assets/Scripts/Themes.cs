using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Themes : MonoBehaviour
{
    private GameObject child;
    private GameObject currSelectedBall;
    // Start is called before the first frame update
    void Start()
    {
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").gameObject.name;
        currSelectedBall= transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").gameObject;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void selectGreyBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectRedBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("redBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("redBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("redBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectPurpleBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("purpleBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("purpleBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("purpleBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectYellowBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("yellowBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("yellowBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("yellowBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectBlueBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("blueBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("blueBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("blueBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectOrangeBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("orangeBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("orangeBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("orangeBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreenBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greenBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greenBall").gameObject.name;




        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greenBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectCyanBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("cyanBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("cyanBall").gameObject.name;

        // activate curr
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("cyanBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }
    public void selectPinkBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("pinkBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("pinkBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("pinkBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectWhiteBall() {

        //deactivate curr selected ball
        currSelectedBall = currSelectedBall.transform.Find("selected").gameObject;
        currSelectedBall.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        currSelectedBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("whiteBall").gameObject;
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("whiteBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("whiteBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }

}
