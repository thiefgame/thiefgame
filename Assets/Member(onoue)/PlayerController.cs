using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    Rigidbody rb;
    //移動速度
    public float speed = 3f;
    //ジャンプ力
    public float thrust = 7f;
    public GameObject footPosition;
    //Animatorを入れる変数
    private Animator animator;
    //unityちゃんの位置を入れる
    Vector3 playerPos;
    //接地しているか否か
    bool ground;
    Vector3 velocity;
    Vector3 direction;

    /*///////////*/
    public GameObject mainCamera;
    /*///////////*/

    // Start is called before the first frame update
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
        if (Physics.CheckSphere(footPosition.transform.position, 0.1f, 1)) { ground = true; animator.SetBool("Jumping", false); }
        else { ground = false; }
        if (ground)
        {
            //AD←→で横移動
            float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
            //WS↑↓で前後移動
            float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

            if (x != 0 || z != 0)
            {
                //入力に応じてunityちゃんを動かす
                rb.MovePosition(transform.position + mainCamera.transform.right.normalized * x + mainCamera.transform.forward * z);

                //unityちゃんの最新の位置から少し前の位置を引いて方向を割り出す
                direction = transform.position - playerPos;
                direction = new Vector3(direction.x, 0, direction.z);

                //移動距離が少しでもあった場合に方向転換
                if (direction.magnitude > 0.01f)
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
            }
            else { animator.SetBool("Running", false); }

            //スペースキーやパッドの３ボタンでジャンプ
            if (Input.GetButtonDown("Jump") && !(animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping")))
            {
                Debug.Log("" + Input.GetButton("Jump") + ":" + Input.GetButtonDown("Jump"));
                //thrustの分だけ上方に力がかかる
                rb.AddForce(transform.up * thrust + direction * thrust,ForceMode.Impulse);
                /*/////////////////*/
                animator.SetBool("Jumping", true);
                ground = false;
                /*/////////////////*/
                //速度が出ていたら前方と上方に力がかかる
                //if (rb.velocity.magnitude > 0)
                //    rb.AddForce(transform.forward * thrust + transform.up * thrust);
                /*/////////////////*/
                //if(rb.velocity.magnitude > 0) { rb.AddForce(rb.velocity.normalized * thrust * 2); }
                //rb.gameObject.transform.position = Vector3.SmoothDamp(playerPos, playerPos + new Vector3(direction.x, 10, direction.z), ref velocity, 285 * Time.deltaTime);
                /*/////////////////*/
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
        /*else
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping")) { ground = true; }
        }*/
    }

    //接地している間作動
  /*  private void OnCollisionStay(Collision collision)
    {
        ground = true;Debug.Log("" + collision.gameObject.name);
        //ジャンプのアニメーションをオフにする
        animator.SetBool("Jumping", false);
    }
    //接地していないと作動
    private void OnCollisionExit(Collision collision)
    {
        ground = false;Debug.Log("Jumping");
        //ジャンプのアニメーションをonにする
        //animator.SetBool("Jumping", true);
    }*/
}
