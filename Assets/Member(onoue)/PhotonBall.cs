using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonBall : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reflector")
        {
            rb.velocity = -Vector3.Reflect(rb.velocity, other.transform.forward);
        }
        else if (other.gameObject.tag == "nonReflector")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "TargetBulb")
        {
            other.gameObject.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
            Destroy(this.gameObject);
        }
    }
}
