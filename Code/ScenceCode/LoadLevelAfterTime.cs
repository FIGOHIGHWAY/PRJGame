using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField]
    private float dealyBeforeLoading = 10f;
    [SerializeField]
    private string sceneNameToLoad;

    private IEnumerator WaitForSceneLoad() 
    {
        yield return new WaitForSeconds(dealyBeforeLoading);
        SceneManager.LoadScene(sceneNameToLoad);

    }

    private void OnTriggerEnter2D(Collider2D other){

        StartCoroutine(WaitForSceneLoad());
    }
}
