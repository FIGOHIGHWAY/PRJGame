using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject DL1;
    private bool isActivated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isActivated)
        {
            isActivated = true;
            DL1.SetActive(true);
            
        }
    }
}
