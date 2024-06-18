using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M_click2 : MonoBehaviour
{
    public GameObject ball;
 
    void Start()
    {
        ball = GameObject.Find("setumei");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ball.SetActive (false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("R_stage_hard10_28");
        }
    }
}
