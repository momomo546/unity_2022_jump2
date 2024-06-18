using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_lateralmovemwnt : MonoBehaviour
{
    float dir = 0;
    public float f_power = 0;
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            dir = -1;
        }
        else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.Space))
        {
            dir = 1;
        }
        else
        {
            dir = 0;
        }
    }

    void FixedUpdate()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 f = new Vector3 (f_power * dir, 0f, 0f);
        rb.AddForce(f, ForceMode2D.Force);
    }
}
