using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAnimationController : MonoBehaviour
{
    Animation redAnim;
    Animation goldAnim;
    Animation greenAnim;

    void Start()
    {
        redAnim = GetComponent<Animation>();
        goldAnim = GetComponent<Animation>();
        greenAnim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") )//&& anim.isPlaying)
        {
            //anim.Stop();
        }
    }

    public void redAnimToggle()
    {

    }
}
