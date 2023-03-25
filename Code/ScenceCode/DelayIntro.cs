using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DelayIntro : MonoBehaviour
{
    public float delayTime = 3.0f; // กำหนดเวลา Delay ที่ต้องการ
    public Image fadeImage;
    public float fadeTime = 1.0f;
    [SerializeField]
    private string sceneNameToLoad;

    void Start()
    {
        StartCoroutine(DelayIntroCoroutine()); // เรียกใช้ Coroutine สำหรับ Delay 
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator DelayIntroCoroutine()
    {
        yield return new WaitForSeconds(delayTime); // รอจนกว่าจะผ่านเวลาที่กำหนด

        SceneManager.LoadScene(sceneNameToLoad); // โหลด Scene หลัก
    }
    IEnumerator FadeInCoroutine()
    {
        Color color = fadeImage.color;
        color.a = 1.0f;

        fadeImage.color = color;

        while (fadeImage.color.a > 0.0f)
        {
            color.a -= Time.deltaTime / fadeTime;
            fadeImage.color = color;

            yield return null;
        }

        fadeImage.enabled = false;
    }
}
