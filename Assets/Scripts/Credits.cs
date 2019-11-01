using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject fadecanvas;
    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(turnOffCanvas(0.5f));

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator turnOffCanvas(float seconds) {
        yield return new WaitForSeconds(seconds);
        child = fadecanvas.transform.Find("panelFadeTransition").gameObject;
        child.SetActive(false);
    }
}
