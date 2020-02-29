using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public AudioClip openClip;
    public AudioClip closeClip;
    public AudioClip lockedClip;
    //GameObjects
    GameObject key;
    public Animator animator;

    bool isNear;


    void Start()
    {
        isNear = false;
        animator = transform.parent.GetComponent<Animator>();
        key = GameObject.Find("golden_key");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && isNear && key.activeSelf == false)
        {
            animator.SetBool("Open", !animator.GetBool("Open"));
            if (animator.GetBool("Open"))
            {
                //音の再生 displayMessage 開いた
            }
            else
            {
                //音の再生 displayMessage 開かない
            }
        }
    }
}