using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusController : MonoBehaviour
{
    public GameObject mainCamera;              //メインカメラ格納用
    public GameObject toggle;            //回転の中心となるプレイヤー格納用
    public GameObject lookPoint;
    public float rotateSpeed = 2.0f;            //回転の速さ
    public float lookUpLimit = 40;
    public float lookDownLimit = 30;

    private Vector3 firstCamPos;
    private Vector3 firstLookPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        firstCamPos = mainCamera.transform.position;
        firstLookPos = lookPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rotateCameraの呼び出し
        if (Input.GetMouseButton(1))
        {
            MoveFocus();
        }

        if (Input.GetKeyDown(KeyCode.R)) { ResetFocus(); }
    }

    //カメラを回転させる関数
    private void MoveFocus()
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        
        //視点とカメラを回転させる(横)
        lookPoint.transform.RotateAround(toggle.transform.position, mainCamera.transform.up, angle.x);
        mainCamera.transform.RotateAround(toggle.transform.position, mainCamera.transform.up, angle.x);

        //視点とカメラを回転させる(縦)
        if (mainCamera.transform.eulerAngles.x <= lookDownLimit || mainCamera.transform.eulerAngles.x >= 360 - lookUpLimit)
        {
            lookPoint.transform.RotateAround(toggle.transform.position, mainCamera.transform.right, -angle.y);
            mainCamera.transform.RotateAround(toggle.transform.position, mainCamera.transform.right, -angle.y);
        }
        else
        {
            if(mainCamera.transform.eulerAngles.x > lookDownLimit && mainCamera.transform.eulerAngles.x < 180 && angle.y > 0)
            {
                lookPoint.transform.RotateAround(toggle.transform.position, mainCamera.transform.right, -angle.y);
                mainCamera.transform.RotateAround(toggle.transform.position, mainCamera.transform.right, -angle.y);
            }
            if (mainCamera.transform.eulerAngles.x < 360 - lookUpLimit && mainCamera.transform.eulerAngles.x >= 180 && angle.y < 0)
            {
                lookPoint.transform.RotateAround(toggle.transform.position, mainCamera.transform.right, -angle.y);
                mainCamera.transform.RotateAround(toggle.transform.position, mainCamera.transform.right, -angle.y);
            }
        }
        Debug.Log("" + mainCamera.transform.eulerAngles.x);

        mainCamera.transform.LookAt(lookPoint.transform);
    
        //mainCamera.transform.eulerAngles += new Vector3(-angle.y, angle.x);
    }

    //視点リセット
    private void ResetFocus()
    {
        lookPoint.transform.position = firstLookPos;
        lookPoint.transform.rotation = Quaternion.identity;
        mainCamera.transform.position = firstCamPos;
        mainCamera.transform.LookAt(lookPoint.transform);
    }
}
