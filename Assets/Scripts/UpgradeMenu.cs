using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    private GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("numberBalls").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(5.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("ballSpeed").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("firePower").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());

        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("level").Find("levelText").gameObject;
        child.GetComponent<TextMeshProUGUI>().SetText(1.ToString());


        child = transform.Find("Image").Find("scrollCanvas").Find("shooterStats").Find("fireSpeed").Find("costButton").Find("moneyScore").gameObject;
        child.GetComponent<TextMeshPro>().SetText(1.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
