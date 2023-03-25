using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss,Alert;

    void Start()
    {
        Boss.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            Boss.SetActive(true);
            Alert.SetActive(false);
        }
    }
}
