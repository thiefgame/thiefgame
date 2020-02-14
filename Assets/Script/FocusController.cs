using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusController : MonoBehaviour
{
    public GameObject mainCamera;              //メインカメラ
    public GameObject toggle;                  //カメラと注視点の回転軸
    public GameObject lookPoint;               //注視点
    public GameObject player;                  //プレイヤー
    public float rotateSpeed = 2.0f;           //回転の速さ
    public float lookUpLimit = 40;             //見上げる角度制限(度)
    public float lookDownLimit = 30;           //見下ろす角度制限(度)

    private Vector3 firstCamPos;
    private Vector3 firstLookPos;
    private Vector3 lastTogglePos;
    private Vector3 CameraWantToBe;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        lastTogglePos = toggle.transform.position;
        firstCamPos = lastTogglePos - mainCamera.transform.position;
        firstLookPos = lastTogglePos - lookPoint.transform.position;
        CameraWantToBe = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //トグルが動いた場合、注視点とカメラも同じだけ動かす
        Vector3 toggleMovement = toggle.transform.position - lastTogglePos;
        if (toggleMovement != Vector3.zero)
        {
            mainCamera.transform.position += toggleMovement;
            lookPoint.transform.position += toggleMovement;
        }

        //右クリック時のみカメラの操作
        if (Input.GetMouseButton(1))
        {
            MoveFocus();
        }

        if (Input.GetKeyDown(KeyCode.R)) { ResetFocus(); }

        //カメラとトグルの間に障害物があるか検出
        RaycastHit hit;
        if(Physics.Raycast(mainCamera.transform.position,mainCamera.transform.forward,out hit, Mathf.Infinity))
        {
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * hit.distance, Color.green);
            //Debug.Log("HIT:" + hit.collider.ToString());
        }
        else { Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 1000, Color.red); }

        //トグルの位置履歴を更新
        lastTogglePos = toggle.transform.position;
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

        mainCamera.transform.LookAt(lookPoint.transform);
    
        //mainCamera.transform.eulerAngles += new Vector3(-angle.y, angle.x);
    }

    //視点リセット
    private void ResetFocus()
    {
        lookPoint.transform.position = toggle.transform.position - firstLookPos.magnitude * -player.transform.forward.normalized;
        lookPoint.transform.rotation = Quaternion.identity;
        mainCamera.transform.position = toggle.transform.position - firstCamPos.magnitude * player.transform.forward.normalized;
        mainCamera.transform.LookAt(lookPoint.transform);
    }
}
