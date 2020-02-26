using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public AudioClip openclip;
    public AudioClip closeclip;
    //ドアのサーチエリアに入っているかどうか
    private bool isNear;
    //ドアのアニメーター
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f") && isNear)
        {
            animator.SetBool("Open", !animator.GetBool("Open"));
            if (animator.GetBool("Open"))
            {
                animator.SetTrigger("Steal");
                gameObject.GetComponent<AudioSource>().PlayOneShot(openclip);
            }
            else
            {
                animator.SetTrigger("Steal");
                gameObject.GetComponent<AudioSource>().PlayOneShot(closeclip);
            }
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isNear = false;
        }
    }
}
