using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_charajump : MonoBehaviour
{
    public float upForce = 200f;
    public float speed = 0.005f;
    public float jumpmax = 500f;
    public float jumppower = 200f;
    public float jumpyoko = 200f;
    public float LimitSpeed = 200f;
    private bool isGround;
    private bool isGroundbefore;
    float dir = 0;
    public float f_power = 0;
    public GroundCheck ground;
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
        if(jumpTime < jumpmax)
        {
            if(Input.GetKey("a") && !Input.GetKey("d"))
            {
                rb.AddForce(new Vector3(-jumpyoko, upForce+jumpTime, 0));
            }
            else if(Input.GetKey("d") && !Input.GetKey("a"))
            {
                rb.AddForce(new Vector3(jumpyoko, upForce+jumpTime, 0));
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
                rb.AddForce(new Vector3(-jumpyoko, upForce+jumpmax, 0));
            }
            else if(Input.GetKey("d") && !Input.GetKey("a"))
            {
                rb.AddForce(new Vector3(jumpyoko, upForce+jumpmax, 0));
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

        if (Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey(KeyCode.Space))
        {
            dir = -1;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a") && !Input.GetKey(KeyCode.Space))
        {
            dir = 1;
        }
        else
        {
            dir = 0;
        }
        if(isGround == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jumpTime -= Time.time;
                StartCoroutine("jump");
            }
        }
    }
    void FixedUpdate()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 f = new Vector3 (f_power * dir, 0f, 0f);
        if (rb.velocity.magnitude > LimitSpeed)
        {
            rb.velocity = rb.velocity.normalized * LimitSpeed;
        }
        else
        {
            rb.AddForce(f, ForceMode2D.Force);
        }
    }
}
