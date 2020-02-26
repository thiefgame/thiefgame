using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLight : MonoBehaviour
{
    public float rotLimitX = 45.0f;
    public float rotLimitZ = 45.0f;
    public float rotSpeedX = 20.0f;
    public float rotSpeedZ = 20.0f;
    bool rotDirectionX = true;
    bool rotDirectionZ = true;
    bool searching = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (searching)
        {
            float rotAngleX = Time.deltaTime * rotSpeedX;
            float rotAngleZ = Time.deltaTime * rotSpeedZ;
            if(transform.rotation.eulerAngles.x > 135 || transform.rotation.eulerAngles.x < 45)
            {
                rotDirectionX = !rotDirectionX;
            }
            if(transform.rotation.eulerAngles.z >45 && transform.rotation.eulerAngles.z < 215)
            {
                rotDirectionZ = !rotDirectionZ;
            }

            if (rotDirectionX)
            {
                transform.rotation *= Quaternion.Euler(new Vector3(rotAngleX, 0, 0));
            }
            else
            {
                transform.rotation *= Quaternion.Euler(new Vector3(-rotAngleX, 0, 0));
            }
            if (rotDirectionZ) { transform.rotation *= Quaternion.Euler(new Vector3(0, 0, rotAngleZ)); }
            else { transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -rotAngleZ)); }
        }
    }
}
