using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public AudioClip openClip;
    public AudioClip closeClip;
    public AudioClip lockedClip;
    //GameObjects
    public Animator animator;
    //近づいたらとぅっとぅるーになるフラグ
    bool isNear;
    //金のカギか銀のカギか判定させるフラグ 1ならゴールドドア 2ならシルバードア
    int whichOne;



    void Start()
    {
        isNear = false;
        whichOne = 0;
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("e") && isNear && whichOne == 2 && GameObject.Find("SilverKeyIcon"))
        {
            animator.SetBool("Open", !animator.GetBool("Open"));
            if (animator.GetBool("Open"))
            {
                //開いたときの音の再生
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(openClip);
            }
            if (!animator.GetBool("Open"))
            {
                //閉めたときの音の再生
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(closeClip);
            }
        } 
        /*else if(Input.GetKeyDown("e") && isNear && GameObject.Find("silver_key").activeSelf == true && whichOne == 2)
        {
            animator.SetBool("Open", !animator.GetBool("Open"));
            if (animator.GetBool("Open"))
            {
                //開いたときの音の再生
                gameObject.GetComponent<AudioSource>().PlayOneShot(openClip);
            }
            if (!animator.GetBool("Open"))
            {
                //閉めたときの音の再生
                gameObject.GetComponent<AudioSource>().PlayOneShot(closeClip);
            }
        }*/
        else if(Input.GetKeyDown("e") && isNear)
        {
            //カギを持っていないときのおとの再生
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(lockedClip);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown("e"))
        {
            other.GetComponent<Animator>().SetTrigger("Steal");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && this.gameObject.name == "SearchAreaGold")
        {
            isNear = true;
            whichOne = 1;
        }
        if(other.tag == "Player" && this.gameObject.name == "SearchAreaSilver")
        {
            isNear = true;
            whichOne = 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}