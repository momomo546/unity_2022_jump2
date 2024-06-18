using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kari : MonoBehaviour
{
    [SerializeField]
    public string scene = "R_stage_hard10_28";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
