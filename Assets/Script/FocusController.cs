using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusController : MonoBehaviour
{
    public GameObject mainCamera;              //メインカメラ格納用
    public GameObject playerObject;            //回転の中心となるプレイヤー格納用
    public GameObject lookPoint;
    public float rotateSpeed = 2.0f;            //回転の速さ

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        //rotateCameraの呼び出し
        MoveFocus();
    }

    //カメラを回転させる関数
    private void MoveFocus()
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()をしようしてメインカメラを回転させる
        lookPoint.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        lookPoint.transform.RotateAround(playerObject.transform.position, Vector3.right, -angle.y);

        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.right, -angle.y);

        mainCamera.transform.LookAt(lookPoint.transform);
    
        //mainCamera.transform.eulerAngles += new Vector3(-angle.y, angle.x);
    }
}
