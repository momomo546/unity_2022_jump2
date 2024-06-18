using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M_goal : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    public string goal_scene = "M_goal";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator changeScene() 
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        yield return new WaitForSeconds(1);
        rb.isKinematic = false;
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Goal")
        {
            FadeManager.Instance.LoadScene (goal_scene, 1.0f);
            StartCoroutine(changeScene());
        }
    }
}
