using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFall : MonoBehaviour
{
    bool isFall;

    public AudioClip fallClip;
    // Start is called before the first frame update
    void Start()
    {
        isFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFall) 
        {
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(fallClip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isFall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isFall = false;
    }
}
