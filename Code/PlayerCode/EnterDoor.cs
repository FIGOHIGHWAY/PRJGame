using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlueDoor>())
        {
            sceneToLoad = "Chater 0 Outside";
            enterAllowed = true;
        }
        else if (collision.GetComponent<BrownDoor>())
        {
            sceneToLoad = "CP0 Inside Coffee";
            enterAllowed = true;
        }
        else if (collision.GetComponent<CofInDoor>())
        {
            sceneToLoad = "CP0 Outside 2";
            enterAllowed = true;
        }
        else if (collision.GetComponent<JailDoor>())
        {
            sceneToLoad = "CP0 Outside 2";
            enterAllowed = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BlueDoor>() || collision.GetComponent<BrownDoor>())
        {
            enterAllowed = false;
        }
        else if (collision.GetComponent<CofInDoor>() || collision.GetComponent<BrownDoor>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
