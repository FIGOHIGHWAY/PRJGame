using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RS2 : MonoBehaviour
{
    [Header("Cameratrap time")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private bool active;

    public GameObject player;
    public GameObject respawnPoint,Deadcon;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(active){
                player.transform.position = respawnPoint.transform.position;
                Time.timeScale = 0f;
                Deadcon.SetActive (true);
            }
        }
    }
    
    private IEnumerator Start(){
        while (true){
            yield return new WaitForSeconds(activationDelay);
            active = false;

            yield return new WaitForSeconds(activeTime);
            active = true;
        }
    }
}
