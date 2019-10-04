using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
		{

			// Check if the mouse was clicked over a UI element
			if(!EventSystem.current.IsPointerOverGameObject())
			{
				Debug.Log("Did not Click on the UI");
			} else {
                Debug.Log("clicked on UI");
            }
		}
    }
}
