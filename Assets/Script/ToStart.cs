using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStart : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("R_stage_copy");
    }
}
