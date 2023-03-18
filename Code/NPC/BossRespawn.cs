using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossRespawn : MonoBehaviour
{
    public GameObject player,Boss;
    public GameObject Deadcon,respawnPointplayer,respawnPointBoss;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.transform.position = respawnPointplayer.transform.position;
            Boss.transform.position = respawnPointBoss.transform.position;
            Deadcon.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
