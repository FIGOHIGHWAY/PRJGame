using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrap : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    public float timeTillDestroy;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeTillDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
