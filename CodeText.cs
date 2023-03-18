using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CodeText : MonoBehaviour
{
    [SerializeField]
	Text TextBox;
    private string codeCP1OS = "123456";
    private string codeCP3 = "654321";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "CP1")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
            TextBox.text = codeCP1OS;
        }

        if (SceneManager.GetActiveScene().name == "CP3")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
            TextBox.text = codeCP3;
        }
        
    }
}
