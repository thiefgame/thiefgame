using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public float shotSpeed = 25;
    bool fire = false;
    int fireCount = 0;

    GameObject pB;
    Transform gP;
    MiniGameLaser mgl;

    // Start is called before the first frame update
    void Start()
    {
        mgl = transform.parent.GetComponent<MiniGameLaser>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fire && fireCount < 100)
        {
            GameObject photonBall = (GameObject)Instantiate(pB, gP.position, gP.rotation);
            photonBall.GetComponent<Rigidbody>().AddForce(gP.forward * shotSpeed, ForceMode.Impulse);
            fireCount++;
        }
        else
        {
            fire = false;
            mgl.Firing = false;
        }
    }

    public void Fire(GameObject pb, Transform gp)
    {
        pB = pb;
        gP = gp;
        fireCount = 0;
        fire = true;
    }
}
