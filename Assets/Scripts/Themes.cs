using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Themes : MonoBehaviour
{
    private GameObject child;
    public Player player;

    // Start is called before the first frame update
    public GameObject fadecanvas;
    public void ballPage() {
        transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").gameObject.SetActive(true);
        transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").gameObject.SetActive(false);
    }
    public void themePage() {
        transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").gameObject.SetActive(false);
        transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").gameObject.SetActive(true);
    }
    void Start()
    {
        StartCoroutine(turnOffCanvas(0.5f));
        //currSelectedBall= transform.Find("Panel").Find("Objects").Find("BallPanel").Find("greyBall").gameObject;
/*
        child = game.transform.Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().text = SceneTransition.money.ToString();
*/
        //on pageLoad select currBall and show it is on by turning it green
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);


        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find(SceneTransition.currTheme).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }

    // Update is called once per frame
    void Update()
    {

    }

// balls

    public void selectGreyBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        // set currselected ball in scenetransition
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greyBall").gameObject.name;
        // save balltheme
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();

        // set currselected ball to green as selected
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greyBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectRedBall() {

        //deactivate curr selected ball

        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);


        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("redBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("redBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);


    }
    public void selectPurpleBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);


        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("purpleBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("purpleBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectYellowBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("yellowBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("yellowBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectBlueBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("blueBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("blueBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectOrangeBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("orangeBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("orangeBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreenBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greenBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();



        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greenBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectCyanBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("cyanBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        // activate curr
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("cyanBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }
    public void selectPinkBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("pinkBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("pinkBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectWhiteBall() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("whiteBall").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("whiteBall").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreyDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greyDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greyDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectRedDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("redDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("redDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectPurpleDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("purpleDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("purpleDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectYellowDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("yellowDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("yellowDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectBlueDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("blueDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("blueDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectOrangeDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("orangeDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("orangeDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectGreenDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greenDiamond").gameObject.name;

        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();


        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("greenDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectCyanDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("cyanDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        // activate curr
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("cyanDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);

    }
    public void selectPinkDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("pinkDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("pinkDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectWhiteDiamond() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find(SceneTransition.currBall).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);
        SceneTransition.currBall = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("whiteDiamond").gameObject.name;
        player.ballTheme = SceneTransition.currBall;
        player.SavePlayer();
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("balls").Find("whiteDiamond").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    IEnumerator turnOffCanvas(float seconds) {
        yield return new WaitForSeconds(seconds);
        child = fadecanvas.transform.Find("panelFadeTransition").gameObject;
        child.SetActive(false);
    }


    // Themes

    public void selectWhite() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find(SceneTransition.currTheme).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        // set currselected ball in scenetransition
        SceneTransition.currTheme = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("white").gameObject.name;
        player.squareTheme = SceneTransition.currTheme;
        player.SavePlayer();
        // set currselected ball to green as selected
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("white").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectColorful() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find(SceneTransition.currTheme).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        // set currselected ball in scenetransition
        SceneTransition.currTheme = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("colorful").gameObject.name;
        player.squareTheme = SceneTransition.currTheme;
        player.SavePlayer();
        // set currselected ball to green as selected
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("colorful").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectRed() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find(SceneTransition.currTheme).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        // set currselected ball in scenetransition
        SceneTransition.currTheme = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("red").gameObject.name;
        player.squareTheme = SceneTransition.currTheme;
        player.SavePlayer();
        // set currselected ball to green as selected
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("red").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectBlue() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find(SceneTransition.currTheme).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        // set currselected ball in scenetransition
        SceneTransition.currTheme = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("blue").gameObject.name;
        player.squareTheme = SceneTransition.currTheme;
        player.SavePlayer();
        // set currselected ball to green as selected
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("blue").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
    public void selectWood() {

        //deactivate curr selected ball
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find(SceneTransition.currTheme).Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(65, 65, 65, 255);

        // set currselected ball in scenetransition
        SceneTransition.currTheme = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("wood").gameObject.name;
        player.squareTheme = SceneTransition.currTheme;
        player.SavePlayer();
        // set currselected ball to green as selected
        child = transform.Find("Panel").Find("Objects").Find("BallPanel").Find("themes").Find("wood").Find("selected").gameObject;
        child.GetComponent<SpriteRenderer>().color =  new Color32(36, 183, 55, 255);
    }
}
