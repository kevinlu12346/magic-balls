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
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void selectGreyBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        // set currselected ball in scenetransition
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greyBall").gameObject.name;

        // set currselected ball to green as selected
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greyBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectRedBall() {

        //deactivate curr selected ball

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);


        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("redBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("redBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);


    }
    public void selectPurpleBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);


        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("purpleBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("purpleBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectYellowBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("yellowBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("yellowBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectBlueBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("blueBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("blueBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectOrangeBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("orangeBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("orangeBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreenBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greenBall").gameObject.name;




        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greenBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectCyanBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("cyanBall").gameObject.name;

        // activate curr
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("cyanBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }
    public void selectPinkBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("pinkBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("pinkBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectWhiteBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("whiteBall").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("whiteBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreyDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greyDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greyDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectRedDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("redDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("redDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectPurpleDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("purpleDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("purpleDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectYellowDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("yellowDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("yellowDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectBlueDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("blueDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("blueDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectOrangeDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("orangeDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("orangeDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreenDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greenDiamond").gameObject.name;




        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greenDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectCyanDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("cyanDiamond").gameObject.name;

        // activate curr
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("cyanDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }
    public void selectPinkDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("pinkDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("pinkDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectWhiteDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("whiteDiamond").gameObject.name;

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("whiteDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    IEnumerator turnOffCanvas(float seconds) {
        yield return new WaitForSeconds(seconds);
        child = fadecanvas.transform.Find("panelFadeTransition").gameObject;
        child.SetActive(false);
    }

}
