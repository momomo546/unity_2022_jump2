using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

	//minuteは分、secondsは秒を表します。
	//シリアライズ可能なフィールドはInspectorから操作が可能になる、
	
    // Start is called before the first frame update
    [SerializeField]
	static public int minute;
	[SerializeField]
	static public float seconds;
	//　前のUpdateの時の秒数
	public float oldSeconds;
	//　タイマー表示用テキスト
	public Text timerText;

	

    void Start()
    {
        minute = 0;
		seconds = 0f;
		oldSeconds = 0f;
		timerText = GetComponentInChildren<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
		if(seconds >= 60f) {
			minute++;
			seconds = seconds - 60;
		}
		//　値が変わった時だけテキストUIを更新
		if((int)seconds != (int)oldSeconds) {
			timerText.text = minute.ToString("00") + ":" + ((int) seconds).ToString ("00");
		}
		oldSeconds = seconds;
	}

	public static string getTime(){
		return minute + ":" + seconds.ToString("F2");
	}
}
