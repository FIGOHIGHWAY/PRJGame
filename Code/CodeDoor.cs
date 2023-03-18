using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CodeDoor : MonoBehaviour
{
    [SerializeField]
	Text codeText;
	string codeTextValue = "";
	private static string score;
	public int lth;
	private string codeCP1OS;
	private string codeCP3;
	
	// Update is called once per frame
	void Update () {
		codeText.text = codeTextValue;
		score = RandomGenText.sum;
		codeCP1OS = "123456";
		codeCP3 = "654321";
		
		
		if (SceneManager.GetActiveScene().name == "Test")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
			if (codeTextValue == score) {
			PlayerCode.isSafeOpened = true;
            Time.timeScale = 1f;
			}

			if (codeTextValue.Length >= 4)
				codeTextValue = "";
        }

		if (SceneManager.GetActiveScene().name == "CP1")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
			if (codeTextValue == codeCP1OS) {
			PlayerCode.isSafeOpened = true;
            Time.timeScale = 1f;
			}

			if (codeTextValue.Length >= 6)
				codeTextValue = "";
        }
		if (SceneManager.GetActiveScene().name == "CP3")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
			if (codeTextValue == codeCP3) {
			PlayerCode.isSafeOpened = true;
            Time.timeScale = 1f;
			}

			if (codeTextValue.Length >= 6)
				codeTextValue = "";
        }
		
	}
   

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
	}

}
