using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animcontroller : MonoBehaviour
{
    private CharacterController characterController;
	public GroundCheck_hard ground;
	[SerializeField]
	private Animator animator;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		characterController = GetComponent <CharacterController> ();
		animator = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool("isGround", ground.IsGround()); 
        if (Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("a");
        }
        else if(Input.GetKey("d") && !Input.GetKey("a") && !Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("d");
        }
        else
        {
            animator.SetTrigger("stop");
        }
        if(Input.GetKeyDown("space"))
        {
            animator.SetBool("Space", true); 
        }
        if (ground.IsGround()==false)
        {
            animator.SetBool("Space", false);
        }
	}
}