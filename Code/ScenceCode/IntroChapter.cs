using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroChapter : MonoBehaviour
{
    public string introSceneName; // ชื่อ Scene ของ Intro Chapter

    public void ChangeScene(string sceneName)
    {
        // โหลด Scene ของ Intro Chapter และรอจนกว่าจะโหลดเสร็จ
        SceneManager.LoadSceneAsync(introSceneName, LoadSceneMode.Additive).completed += (AsyncOperation op) =>
        {
            // เมื่อโหลดเสร็จ ให้เรียกฟังก์ชั่น ChangeChapterScene()
            ChangeChapterScene(sceneName);
        };
    }

    public void ChangeChapterScene(string sceneName)
    {
        // ลบ Scene ของ Intro Chapter ทิ้ง
        SceneManager.UnloadSceneAsync(introSceneName);

        // โหลด Chapter Scene ใหม่แทน Scene เดิม
        SceneManager.LoadScene(sceneName);
    }
}
