using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public float[] otherAngles;
    private float[] allAngles;

    // Start is called before the first frame update
    void Start()
    {
        allAngles = new float[otherAngles.Length + 1];
        float rotY = gameObject.transform.rotation.eulerAngles.y;
        if (rotY > 0) { allAngles[0] = rotY; }
        else { allAngles[0] = 360 + rotY; }
        int i = 1;
        foreach(float f in otherAngles)
        {
            if (f > 0) { allAngles[i] = f; }
            else { allAngles[i] = 360 + f; }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spin()
    {
        for(int i = 0; i < allAngles.Length; i++)
        {
            if(allAngles[i] == gameObject.transform.rotation.eulerAngles.y)
            {
                int j = i;
                if (i == allAngles.Length - 1) { j = -1; }
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, allAngles[j + 1], 0));
                break;
            }
        }
    }
}
