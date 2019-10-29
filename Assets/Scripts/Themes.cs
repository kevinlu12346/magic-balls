using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Themes : MonoBehaviour
{
    private GameObject child;
    // Start is called before the first frame update
    public GameObject fadecanvas;

    void Start()
    {
        StartCoroutine(turnOffCanvas(0.5f));
        //currSelectedBall= transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").gameObject;



        //on pageLoad select currBall and show it is on by turning it green
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void selectGreyBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        // set currselected ball in scenetransition
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").gameObject.name;

        // set currselected ball to green as selected
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectRedBall() {

        //deactivate curr selected ball

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);


        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("redBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("redBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);


    }
    public void selectPurpleBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);


        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("purpleBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("purpleBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectYellowBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("yellowBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("yellowBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectBlueBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("blueBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("blueBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectOrangeBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("orangeBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("orangeBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreenBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greenBall").gameObject.name;




        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greenBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectCyanBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("cyanBall").gameObject.name;

        // activate curr
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("cyanBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }
    public void selectPinkBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("pinkBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("pinkBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectWhiteBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("whiteBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("whiteBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreyDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectRedDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("redDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("redDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectPurpleDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("purpleDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("purpleDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectYellowDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("yellowDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("yellowDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectBlueDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("blueDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("blueDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectOrangeDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("orangeDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("orangeDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreenDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greenDiamond").gameObject.name;




        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greenDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectCyanDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("cyanDiamond").gameObject.name;

        // activate curr
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("cyanDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }
    public void selectPinkDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("pinkDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("pinkDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectWhiteDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("whiteDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("whiteDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    IEnumerator turnOffCanvas(float seconds) {
        yield return new WaitForSeconds(seconds);
        child = fadecanvas.transform.Find("panelFadeTransition").gameObject;
        child.SetActive(false);
    }

}
