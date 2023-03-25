using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossRespawn : MonoBehaviour
{
    public GameObject player,Boss;
    public GameObject Deadcon,respawnPointplayer,respawnPointBoss;
    public GameObject[] boxes;
    public playerpush playerPushScript; // reference to the playerpush script
    private Rigidbody2D[] boxRigidbodies;
    private Vector3[] boxPositions;

    private void Awake()
    {
        // Store the starting positions of the boxes
        boxPositions = new Vector3[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            boxPositions[i] = boxes[i].transform.position;
        }
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i].transform.position = boxPositions[i];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            player.transform.position = respawnPointplayer.transform.position;
            Boss.transform.position = respawnPointBoss.transform.position;

            Deadcon.SetActive(true);
            Time.timeScale = 0f;

            // Reset the positions of the boxes
            for (int i = 0; i < boxes.Length; i++)
            {
                boxpull boxPullScript = boxes[i].GetComponent<boxpull>();
                boxes[i].transform.position = boxPositions[i];
                boxPullScript.xPos = boxPositions[i].x;
            }
        }

    }

    public void DeadConB()
    {
        Deadcon.SetActive(false);
        Time.timeScale = 1f;
    }
}

