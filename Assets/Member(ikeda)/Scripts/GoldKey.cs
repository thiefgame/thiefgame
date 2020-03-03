using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
{
    bool isNear;
    Animator animator;
    //private GameObject goldKeyIcon;
    private GameObject goldKeyIcon;

    void Start()
    {
        isNear = false;
        goldKeyIcon = GameObject.Find("SilverKeyIcon");
        goldKeyIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    //カギを入手するときの動作
    {
        if (isNear && Input.GetKeyDown("e"))
        {
            Destroy(this.gameObject);
            /*if (this.gameObject.name == "gold_key_searchArea")
            {
                goldKeyIcon.SetActive(true);            
                
            }*/
            if (this.gameObject.name == "gold_key_searchArea")
            {
                goldKeyIcon.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isNear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown("e"))
        {
            other.GetComponent<Animator>().SetTrigger("Steal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}
