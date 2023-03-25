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
	public AudioSource audioSource;
    public AudioClip buttonSound;
	public AudioClip passSound;
    public AudioClip failSound;
	void Start(){
		Debug.Log(codeCP1OS);

	}
	
	// Update is called once per frame
	void Update () {
		codeText.text = codeTextValue;
		score = RandomGenText.sum;
		codeCP1OS = CodeText.codeCP1OS;
		codeCP3 = CodeText.codeCP3;
		
		if (SceneManager.GetActiveScene().name == "Test")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
			if (codeTextValue == score) {
			audioSource.PlayOneShot(passSound);
			PlayerCode.isSafeOpened = true;
            Time.timeScale = 1f;
			Debug.Log("Unlcok");
			}

			if (codeTextValue.Length >= 4)
				audioSource.PlayOneShot(failSound);
				codeTextValue = "";
        }

		if (SceneManager.GetActiveScene().name == "CP1")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
			if (codeTextValue == codeCP1OS) {
			PlayerCode.isSafeOpened = true;
            Time.timeScale = 1f;
			Debug.Log("Unlcok");
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
			Debug.Log("Unlcok");
			}

			if (codeTextValue.Length >= 4)
				codeTextValue = "";

        }
		
	}
   

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
		audioSource.PlayOneShot(buttonSound);
	}

}
