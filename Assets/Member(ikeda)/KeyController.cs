using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    bool isNear;
    Animator animator;
    //private GameObject goldKeyIcon;
    private GameObject silverKeyIcon;

    private void Awake()
    {
        //goldKeyIcon = GameObject.Find("GoldKeyIcon");
        
        silverKeyIcon = GameObject.Find("SilverKeyIcon");
        //goldKeyIcon = GameObject.Find("GoldKeyIcon");
        silverKeyIcon.SetActive(false);
        //goldKeyIcon.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown("e"))
        {
            this.gameObject.SetActive(false);
            /*if (this.gameObject.name == "gold_key_searchArea")
            {
                goldKeyIcon.SetActive(true);
                
            }*/
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
