using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToShowInstraction : MonoBehaviour
{
    public GameObject ball;
 
    void Start()
    {
        ball = GameObject.Find("setumei");
        ball.SetActive (false);
    }

    public void OnClick()
    {
        ball.SetActive (true);
        
    }
}
