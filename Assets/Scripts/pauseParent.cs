using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseParent : MonoBehaviour
{
    private GameObject child;
    public GameObject camera;
    // Start is called before the first frame Update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pause() {
        Debug.Log("pause");
        child = transform.Find("PauseMenu").gameObject;
        child.SetActive(true);
        Time.timeScale = 0;
        camera.GetComponent<Target>().enabled = false;
        

    }
}
