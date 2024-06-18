using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Azisio_displayTim : MonoBehaviour
{
    string time;
    // Start is called before the first frame update
    void Start()
    {
        time = TimerScript.getTime();
        GameObject ob = GameObject.Find("claertime");
        Text tx = ob.GetComponent<Text>(); 
        tx.text = time;
    }

}
