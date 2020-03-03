using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    bool isNear;
    Animator animator;
    private GameObject silverKeyIcon;

    void Start()
    {
        isNear = false;
        silverKeyIcon = GameObject.Find("SilverKeyIcon");
        silverKeyIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
        //カギを入手するときの動作
    {
        if (isNear && Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
            if(this.gameObject.name == "silver_key_searchArea")
            {
                silverKeyIcon.SetActive(true);
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            other.GetComponent<Animator>().SetTrigger("Steal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}
