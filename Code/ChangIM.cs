using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ChangIM : MonoBehaviour
{
    public GameObject Cctv;

    public Image image;  // อินสแตนซ์ของ Image

    public List<Sprite> imagesList;  // รายการภาพ UI

    private int currentImage = 0;  // ภาพปัจจุบัน

    void Start()
    {
        image.sprite = imagesList[currentImage];  // กำหนดภาพ UI ใน Image
    }

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

    public void ExitCCTV()
    {
        if(currentImage == 2){
            Cctv.SetActive(false);
            Time.timeScale = 1f;
        } 
    }
}
