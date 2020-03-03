using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameLaser : MonoBehaviour
{
    GameObject player;
    GameObject mainCamera;
    LaserPointer laserPointer;
    public GameObject PhotonBall;
    Transform generatePoint;
    bool firing = false;

    // Start is called before the first frame update
    void Start()
    {
        laserPointer = transform.Find("LaserPointer").GetComponent<LaserPointer>();
        generatePoint = transform.Find("LaserPointer").Find("GeneratePoint");
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //光線を発射
        if (Input.GetKeyDown(KeyCode.Space) && !firing)
        {
            firing = true;
            laserPointer.Fire(PhotonBall, generatePoint);
        }

        //ミニゲームを終了する
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            player.SetActive(true);
            mainCamera.SetActive(true);
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        //デバッグ用
        if (Input.anyKeyDown)
        {
            //Debug.Log("" + generatePoint.name);
        }
    }

    public void SetMainObjects(GameObject p,GameObject cam)
    {
        this.player = p;
        this.mainCamera = cam;
    }

    public bool Firing
    {
        set { this.firing = value; }
        get { return this.firing; }
    } 
}
