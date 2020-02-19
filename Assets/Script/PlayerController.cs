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
    public float thrust = 6f;
    public GameObject footPosition;
    //Animatorを入れる変数
    private Animator animator;
    //メインカメラ
    public GameObject mainCamera;
    //unityちゃんの位置を入れる
    Vector3 playerPos;
    //その他ローカル変数
    Vector3 velocity;
    Vector3 direction;

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
        //方向キーでの入力をうけつけ
        //AD←→で横移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //WS↑↓で前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //入力内容に沿って移動方向を決定、その方向を向かせる
        direction = mainCamera.transform.right.normalized * x + mainCamera.transform.forward * z;
        if (direction.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        }

        //アニメーターの状態で処理を変える
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (Input.GetButtonDown("Jump"))
            {//スペースキーやパッドの３ボタンでジャンプ
                animator.SetBool("Jumping", true);
                rb.AddForce(transform.up * thrust + direction * thrust / 4, ForceMode.Impulse);
            }
            else if (direction.magnitude != 0)
            {
                animator.SetBool("Running", true);
                rb.MovePosition(transform.position + direction);
            }
            else if (Input.GetKeyDown("c"))
            {
                animator.SetBool("Crouch", true);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {

        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            if (Input.GetButtonDown("Jump"))
            {//スペースキーやパッドの３ボタンでジャンプ
                animator.SetBool("Jumping", true);
                rb.AddForce(transform.up * thrust + direction * thrust / 2, ForceMode.Impulse);
            }
            else if (direction.magnitude != 0)
            {//Run継続
                rb.MovePosition(transform.position + direction);
            }
            else
            {//Run中止→Idle移行
                animator.SetBool("Running", false);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crouch"))
        {
            if (direction.magnitude != 0)
            {
                //CrouchWalkへの移行&移動処理
            }
            if (Input.GetKeyUp("c"))
            {
                animator.SetBool("Crouch", false);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("CrouchWalk"))
        {

        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            //接地判定
            if (Physics.CheckSphere(footPosition.transform.position, 0.1f, 1))
            {
                animator.SetBool("Jumping", false);
                if (direction.magnitude != 0)
                {
                    animator.SetBool("Running", true);
                    rb.MovePosition(transform.position + direction);
                }
                else
                {
                    animator.SetBool("Running", false);
                }
            }
            else
            {//滞空中
                rb.MovePosition(transform.position + direction / 2);
            }
        }
        
    }
}
