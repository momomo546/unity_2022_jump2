using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_charajump_hard : MonoBehaviour
{
    public float upForce = -50f;
    public float speed = 0.005f;
    public float jumpmax = 450f;
    public float jumppower = 900f;
    private bool isGround;
    private bool isGroundbefore = true;
    float dir = 0;
    public float f_power = 0;
    public GroundCheck_hard ground;
    private Rigidbody2D rb;

    public float jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator jump()
    {
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        jumpTime += Time.time;
        jumpTime *= jumppower;
        isGround=false;
        if(jumpTime < jumpmax)
        {
            if(Input.GetKey("a") && !Input.GetKey("d"))
            {
                rb.AddForce(new Vector3(-jumpTime/2, upForce+jumpTime, 0));
            }
            else if(Input.GetKey("d") && !Input.GetKey("a"))
            {
                rb.AddForce(new Vector3(jumpTime/2, upForce+jumpTime, 0));
            }
            else
            {
                rb.AddForce(new Vector3(0, upForce+jumpTime, 0));
            }  
        }
        else if(jumpTime >= jumpmax)
        {
            if(Input.GetKey("a") && !Input.GetKey("d"))
            {
                rb.AddForce(new Vector3(-jumpmax/2, upForce+jumpmax, 0));
            }
            else if(Input.GetKey("d") && !Input.GetKey("a"))
            {
                rb.AddForce(new Vector3(jumpmax/2, upForce+jumpmax, 0));
            }
            else
            {
                rb.AddForce(new Vector3(0, upForce+jumpmax, 0));
            }
        }
        jumpTime =0;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = ground.IsGround();
        if(isGroundbefore == false)
        {
            if(isGroundbefore!=isGround)
            {
                rb.velocity = Vector3.zero;
            }
        }
        
        isGroundbefore = isGround;

        if(isGround == true)
        {
            if (Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey(KeyCode.Space))
            {
                if(dir!=-1){
                    rb.velocity = Vector3.zero;
                }
                dir = -1;
            }
            else if (Input.GetKey("d") && !Input.GetKey("a") && !Input.GetKey(KeyCode.Space))
            {
                if(dir!=1){
                    rb.velocity = Vector3.zero;
                }
                dir = 1;
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                dir = 0;
                rb.velocity = Vector3.zero;
                jumpTime -= Time.time;
                StartCoroutine("jump");
            }
            else
            {
                rb.velocity = rb.velocity/2;
                dir = 0;
            }
        }
    }
    void FixedUpdate()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 f = new Vector3 (f_power * dir, 0f, 0f);
        if(isGround == true)
        {  
            rb.AddForce(f);
        }
    }

}
