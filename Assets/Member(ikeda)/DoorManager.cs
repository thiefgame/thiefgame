using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public AudioClip openclip;
    public AudioClip closeclip;

    //ドアのサーチエリアに入っているかどうか
     bool isNear;

    //ドアのアニメーター
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && isNear)
        {
            animator.SetBool("Open", !animator.GetBool("Open"));
            if (animator.GetBool("Open"))
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(openclip);
                //
                //if (other.TryGetComponent<Animator>(out Animator anim)) { anim.SetTrigger("Steal"); }
            }
            else
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(closeclip);
                //if (other.TryGetComponent<Animator>(out Animator anim)) { anim.SetTrigger("Steal"); }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isNear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown("f"))
        {
            other.GetComponent<Animator>().SetTrigger("Steal");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}