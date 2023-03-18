using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [Header("Cameratrap time")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private bool active;

    public GameObject player;
    public GameObject respawnPoint,Deadcon;

    

    

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
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
            active = true;

            yield return new WaitForSeconds(activeTime);
            active = false;
        }
    }
}
