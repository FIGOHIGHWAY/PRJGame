using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class CutScene : MonoBehaviour
{
    public GameObject Fade;

    public Image image; // ตัวแปรสำหรับเก็บ Component ของ Image
    public TextMeshProUGUI text; // ตัวแปรสำหรับเก็บ Component ของ Text

    public Sprite[] sprites; // ภาพที่จะใช้ใน Cutscene
    public string[] messages; // ข้อความที่จะใช้ใน Cutscene

    private int currentIndex = 0; // ตัวแปรเก็บค่า index ของภาพและข้อความปัจจุบัน

    public float textSpeed;

    void Start()
    {
        // กำหนดภาพและข้อความตัวแรกเมื่อเริ่มเกม
        text.text = string.Empty;
        StartDialogueC();
    }

    void Update()
    {
        // ตรวจสอบการคลิกบนหน้าจอ
        if (Input.GetMouseButtonDown(0))
        {
            if (text.text == messages[currentIndex])
            {
                NextLineC();
            }
            else
            {
                StopAllCoroutines();
                text.text = messages[currentIndex];
            }
        }
    }

    void StartDialogueC()
    {
        currentIndex =0;
        StartCoroutine(TypeLineC());
    }

    IEnumerator TypeLineC()
    {
        foreach (char c in messages[currentIndex].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLineC()
    {
        if (currentIndex < messages.Length - 1)
        {
            currentIndex++;
            text.text = string.Empty;
            image.sprite = sprites[currentIndex];
            StartCoroutine(TypeLineC());
        }
        else
        {
            gameObject.SetActive(false);
            Fade.SetActive(true);
        }
    }
}
