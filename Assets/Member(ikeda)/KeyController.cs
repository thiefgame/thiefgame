using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    bool isNear;

    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown("e"))
        {
            this.gameObject.SetActive(false);
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
        isNear = false;
    }
}
