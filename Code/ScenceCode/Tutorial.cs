using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{
    public GameObject tutorialMenu;
    public static bool isPauseds;

    public Image image;  // อินสแตนซ์ของ Image

    public List<Sprite> imagesList;  // รายการภาพ UI

    private int currentImage = 0;  // ภาพปัจจุบัน

    // Start is called before the first frame update
    void Start()
    {
        tutorialMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ตรวจสอบการกดปุ่มเมาส์ซ้าย
        {
            currentImage++;  // เปลี่ยนภาพ UI

            if (currentImage >= imagesList.Count)  // ถ้าเปลี่ยนภาพ UI ครบทุกภาพแล้ว ให้กลับมาที่ภาพแรก
            {
                currentImage = 0;
            }

            image.sprite = imagesList[currentImage];  // กำหนดภาพ UI ใน Image
        }
    }

    public void TutorialGame()
    {
        tutorialMenu.SetActive(true);
        Time.timeScale = 0f;
        isPauseds = true;
    }
    public void TutorialGameBack()
    {
        tutorialMenu.SetActive(false);
        Time.timeScale = 1f;
        isPauseds = false;
    }
}
