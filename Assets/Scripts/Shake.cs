using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void camShake() {
        camAnim.SetTrigger("shake");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
