using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    Rigidbody rb;
    //移動速度
    public float speed = 3f;
    //ジャンプ力
    public float thrust = 200;
    //Animatorを入れる変数
    private Animator animator;
    //unityちゃんの位置を入れる
    Vector3 playerPos;
    //接地しているか否か
    bool ground;

    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //unityちゃんのAnimatorにアクセスする
        animator = GetComponent<Animator>();
        //unityちゃんの現在より少し前の位置を保存
        playerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ground)
        {
            //AD←→で横移動
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
            //WS↑↓で前後移動
            float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

            //unityちゃんの最新の位置＋入力した数値の場所に移動する
            rb.MovePosition(transform.position + new Vector3(x, 0, z));

            //unityちゃんの最新の位置から少し前の位置を引いて方向を割り出す
            Vector3 direction = transform.position - playerPos;

            //移動距離が少しでもあった場合に方向転換
            if(direction.magnitude > 0.01f)
            {
                //directionのx軸とz軸の方向に向かわせる
                transform.rotation = Quaternion.LookRotation(new Vector3
                    (direction.x, 0, direction.z));
                //走るアニメーションを再生
                animator.SetBool("Running", true);
            }
            else
            {
                //ベクトルの長さがない＝移動していないときは走るアニメーションはオフ
                animator.SetBool("Running", false);
            }

            //unityちゃんの位置を更新する
            playerPos = transform.position;

            //スペースキーやパッドの３ボタンでジャンプ
            if (Input.GetButton("Jump"))
            {
                //thrustの分だけ上方に力がかかる
                rb.AddForce(transform.up * thrust);
                //速度が出ていたら前方と上方に力がかかる
                if (rb.velocity.magnitude > 0)
                    rb.AddForce(transform.forward * thrust + transform.up * thrust);
            }

            if (Input.GetKeyDown("c"))
            {
                animator.SetBool("Crouch", true);
            }
            if (Input.GetKeyUp("c"))
            {
                animator.SetBool("Crouch", false);
            }
        }
    }

    //接地している間作動
    private void OnCollisionStay(Collision collision)
    {
        ground = true;
        //ジャンプのアニメーションをオフにする
        animator.SetBool("Jumping", false);
    }
    //接地していないと作動
    private void OnCollisionExit(Collision collision)
    {
        ground = false;
        //ジャンプのアニメーションをonにする
        animator.SetBool("Jumping", true);
    }
}
