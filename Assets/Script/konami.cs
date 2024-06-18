using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class konami : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
                                                FadeManager.Instance.LoadScene ("R_stage_hard10_28", 1.0f);
        }
    }
}
