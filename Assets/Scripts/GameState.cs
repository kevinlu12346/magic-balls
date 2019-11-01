using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(scene2());
    }

    // Update is called once per frame
    IEnumerator scene2() {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene(1);
    }
}
