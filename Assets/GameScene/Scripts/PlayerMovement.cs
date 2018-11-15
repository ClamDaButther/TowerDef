using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool isGrounded;
    public bool isCrouching;

    [SerializeField]
    private bool ff = false;
    private float speed;
    private float w_speed = 0.4f;
    private float r_speed = 0.6f;
    private float c_speed = 0.3f;
    public float rotSpeed;
    public float jumpHeight;
    Rigidbody rb;
    Animator anim;
    CapsuleCollider col_size;


	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col_size = GetComponent<CapsuleCollider>();
        isGrounded = true;
	}

    void Update() {


        //toggle crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching)
            {
                isCrouching = false;
                anim.SetBool("isCrouching", false);
                col_size.height = 0.5f;
                col_size.center = new Vector3(0, 0.225f, -0.01f);
            }
            else
            {
                isCrouching = true;
                anim.SetBool("isCrouching", true);
                speed = c_speed;
                col_size.height = 0.5f;
                col_size.center = new Vector3(0, 0.45f, -0.01f);
            }


            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isCrouching = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                isCrouching = false;
            }
        }
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;

        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {

            anim.SetTrigger("isJumping");
            isCrouching = false;
            if(ff == false) {
                StartCoroutine(Springen(0.3F));
                StartCoroutine(Wacht(1.1F));
            }

            
        }


        else if (isGrounded == true && anim.GetBool("isJumping") == true)
        {
            anim.SetBool("isJumping", false);
        }

        if (isCrouching)
        {
            //Crouching Controls
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);
            }

            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);
            }
        }

            else if (Input.GetKey(KeyCode.LeftShift))
            {
                 speed = r_speed;
                 //rennen controls
                 if(Input.GetKey(KeyCode.W))
                 {
                     anim.SetBool("isWalking", true);
                      anim.SetBool("isRunning", false);
                      anim.SetBool("isIdle", false);
                  }

                 else if (Input.GetKey(KeyCode.S))
                     {
                     anim.SetBool("isWalking", false);
                     anim.SetBool("isRunning", true);
                     anim.SetBool("isIdle", false);
                     }

                 else
                     {
                     anim.SetBool("isWalking", false);
                     anim.SetBool("isRunning", false);
                     anim.SetBool("isIdle", true);
                     }
            }

        else if (!isCrouching)
        {
            //staan Controls
            speed = w_speed;
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);
            }

            else
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);
            }
        }



    }

    void OnCollisionEnter()
    {
        isGrounded = true;
        ff = false;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }

    IEnumerator Springen(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        rb.AddForce(0, jumpHeight, 0);
        col_size.height = 0.5f;
        col_size.center = new Vector3(0, 0.8f, -0.01f);

        yield return new WaitForSeconds(0.7f);
        col_size.height = 1f;
        col_size.center = new Vector3(0, 0.45f, -0.01f);
    }

    IEnumerator Wacht(float waitTime3)
    {
        ff = true;
        yield return new WaitForSeconds(waitTime3);

    }

}
