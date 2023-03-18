using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawnNPC : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint,Deadcon;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.transform.position = respawnPoint.transform.position;
            Time.timeScale = 0f;
            Deadcon.SetActive (true);
        }
    }
}
