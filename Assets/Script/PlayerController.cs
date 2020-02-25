using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    Rigidbody rb;
    //移動速度
    public float speed = 4f;
    //ジャンプ力
    public float thrust = 6f;
    public GameObject footPosition;
    //Animatorを入れる変数
    private Animator animator;
    //コライダー
    private CapsuleCollider collider;
    //メインカメラ
    public GameObject mainCamera;
    //unityちゃんの位置を入れる
    Vector3 playerPos;
    //その他ローカル変数
    Vector3 velocity;
    Vector3 direction;
    private bool walk = false;
    //歩き、走りをやめるまでの猶予フレーム数
    public int chgFrame = 3;
    private int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //unityちゃんのAnimatorにアクセスする
        animator = GetComponent<Animator>();
        //colliderを取得
        collider = GetComponent<CapsuleCollider>();
        //unityちゃんの現在より少し前の位置を保存
        playerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) { walk = !walk; }
        //方向キーでの入力をうけつけ
        //AD←→で横移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        //WS↑↓で前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //入力内容に沿って移動方向を決定、その方向を向かせる
        direction = mainCamera.transform.right.normalized * x + mainCamera.transform.forward * z;
        //カメラが上下に傾いていることもあるので軸合わせ
        direction = new Vector3(direction.x, 0, direction.z);
        if (direction.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        }

        //アニメーターの状態で処理を変える
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (Input.GetButtonDown("Jump"))
            {//スペースキーやパッドの３ボタンでジャンプ
                if (!animator.GetBool("Jumping"))
                {
                    animator.SetBool("Jumping", true);
                    rb.AddForce(transform.up * thrust + direction * thrust / 4, ForceMode.Impulse);
                }
            }
            else if (direction.magnitude != 0)
            {
                if (walk)
                {
                    animator.SetBool("Walking", true);
                    rb.MovePosition(transform.position + direction / 2);
                }
                else
                {
                    animator.SetBool("Running", true);
                    rb.MovePosition(transform.position + direction);
                }
            }
            else if (Input.GetKeyDown("c"))
            {
                animator.SetBool("Crouch", true);
                //しゃがみに合わせてコライダーの調整
                collider.center = new Vector3(0, 0.6f, 0);
                collider.height = 1.2f;
                //キャラクターの調整(モデルで対応する場合不要)
                //transform.position = Vector3.SmoothDamp(transform.position, transform.position + new Vector3(0, -0.25f, 0), ref velocity, 0.45f);
                //footPositionがずれるので調整
                //transform.Find("FootPosition").transform.localPosition += new Vector3(0, 0.25f, 0);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if(direction.magnitude != 0)
            {
                if (walk)
                {
                    rb.MovePosition(transform.position + direction / 2);
                }
                else
                {
                    animator.SetBool("Walking", false);
                    animator.SetBool("Running", true);
                }
            }
            else
            {
                if (frameCount >= chgFrame)
                {//入力がなくなってから一定フレーム経過後に止まる
                    animator.SetBool("Walking", false);
                    animator.SetBool("Running", false);
                    frameCount = 0;
                }
                else
                {
                    rb.MovePosition(transform.position + direction / 2);
                    frameCount++;
                }
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            if (Input.GetButtonDown("Jump"))
            {//スペースキーやパッドの３ボタンでジャンプ
                if (!animator.GetBool("Jumping"))
                {
                    animator.SetBool("Jumping", true);
                    rb.AddForce(transform.up * thrust + direction * thrust / 2, ForceMode.Impulse);
                }
            }
            else if (direction.magnitude != 0)
            {
                if (walk)
                {
                    //animator.SetBool("Running", false);
                    animator.SetBool("Walking", true);
                    rb.MovePosition(transform.position + direction / 2);
                }
                else
                {//Run継続
                    rb.MovePosition(transform.position + direction);
                }
            }
            else
            {//Run中止→Idle移行
                if (frameCount >= chgFrame)
                {
                    animator.SetBool("Running", false);
                    animator.SetBool("Walking", false);
                    frameCount = 0;
                }
                else
                {
                    rb.MovePosition(transform.position + direction);
                    frameCount++;
                }
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crouch"))
        {
            if (direction.magnitude != 0)
            {
                animator.SetBool("CrouchWalk", true);
                rb.MovePosition(transform.position + direction / 3);
                //CrouchWalkへの移行&移動処理
            }
            if (Input.GetKeyDown("c"))
            {
                animator.SetBool("Crouch", false);
                //しゃがみに合わせてコライダーの調整
                collider.center = new Vector3(0, 0.8f, 0);
                collider.height = 1.6f;
                //キャラクターの調整(モデルで対応する場合不要)
                //transform.position = Vector3.SmoothDamp(transform.position, transform.position + new Vector3(0, 0.25f, 0), ref velocity, 1.5f);
                //footPositionがずれるので調整
                //transform.Find("FootPosition").transform.localPosition += new Vector3(0, -0.25f, 0);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("CrouchWalk"))
        {
            if(direction.magnitude != 0)
            {
                rb.MovePosition(transform.position + direction / 3);
            }
            else
            {
                animator.SetBool("CrouchWalk", false);
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            //接地判定
            if (Physics.CheckSphere(footPosition.transform.position, 0.2f, 1))
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
    /*IEnumerator Crouch()
    {
        //0.1秒待ったあと、0.4秒かけてしゃがむ

    }*/
}
