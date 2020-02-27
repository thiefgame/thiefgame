using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFall : MonoBehaviour
{
    bool isFall;

    public AudioClip fallClip;
    public AudioClip screamClip;
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
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(screamClip);
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
