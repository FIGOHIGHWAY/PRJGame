using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;
    
    private List<Key.KeyType> keyList;

    public GameObject blackScreen;
    public GameObject canvas;
    private bool enterAllowed;
    private bool enterAllowedIn;
    private string sceneToLoad;
    public GameObject player;
    public GameObject respawnPoint,Door1,Door2,Door3,Door4,Door5,Door6,Door7,Door8,Door9,Door10,Door11,Door12,Door13,Door14,Door15,Door16,Door17,Door18;
    private GameObject RSP;

    private void Awake() {
        keyList = new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeyList(){
        return keyList;
    }

    public void AddKey(Key.KeyType keyType){
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType){
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType){
        return keyList.Contains(keyType);
    }

    private void OnTriggerStay2D(Collider2D collider){
        Key key = collider.GetComponent<Key>();

        if (key != null){
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        
        //Test
        if (keyDoor != null && collider.GetComponent<SCDoor>()){
            if (ContainsKey(keyDoor.GetKeyType())){
                RemoveKey(keyDoor.GetKeyType());
                sceneToLoad = "CP1 OutSideJail";
                enterAllowed = true;
            }  
        }
        //CP0
        if (SceneManager.GetActiveScene().name == "CP0")
        {
            if (collider.GetComponent<BlueDoor>())
            {
                RSP = Door1;
                enterAllowedIn = true;
            }
            else if (collider.GetComponent<BrownDoor>())
            {
                RSP = Door2;
                enterAllowedIn = true;
            }
            else if (collider.GetComponent<CofInDoor>())
            {
                RSP = Door3;
                enterAllowedIn = true;
            }
        } 
        //CP1
        if (SceneManager.GetActiveScene().name == "CP1")
        {
            //CP1 INS
            if (keyDoor != null && collider.GetComponent<JailDoor>()){
                if (ContainsKey(keyDoor.GetKeyType())){
                    RSP = respawnPoint;
                    enterAllowedIn = true;
                }  
            }
            //CP1 OS TO CP2 OS
            else if (keyDoor != null && collider.GetComponent<CP1TOCP2>()){
                if (ContainsKey(keyDoor.GetKeyType())){
                    sceneToLoad = "LD CP2";
                    enterAllowed = true;
            }  
            }
            if (collider.GetComponent<DoorInSc>())
            {
                RSP = Door2;
                enterAllowedIn = true;
            
            } 
            else if (collider.GetComponent<DoorBack>())
            {
                RSP = Door1;
                enterAllowedIn = true;
            }
            else if (collider.GetComponent<DoorInOS2A3>())
            {
                RSP = Door5;
                enterAllowedIn = true;
            }
            else if (collider.GetComponent<DoorInOS3A4>())
            {
                RSP = Door4;
                enterAllowedIn = true;
            } 
            else if (collider.GetComponent<DoorInOS2A5>())
            {
                RSP = Door7;
                enterAllowedIn = true;
            }
            else if (collider.GetComponent<DoorInIN2A6>())
            {
                RSP = Door6;
                enterAllowedIn = true;
            }
            else if (collider.GetComponent<DoorInOS3A7>())
            {
                RSP = Door9;
                enterAllowedIn = true;
            }
            else if (collider.GetComponent<DoorInIN3A8>())
            {
                RSP = Door8;
                enterAllowedIn = true;
            }
        }
        //CP2
        if (SceneManager.GetActiveScene().name == "CP2")
        {
            if (collider.gameObject.name.Equals("Door1"))
            {
                RSP = Door2;
                enterAllowedIn = true;
            
            } 
            else if (collider.gameObject.name.Equals("Door2"))
            {
                RSP = Door1;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door3"))
            {
                RSP = Door4;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door4"))
            {
                RSP = Door3;
                enterAllowedIn = true;
            } 
            else if (collider.gameObject.name.Equals("Door5"))
            {
                RSP = Door6;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door6"))
            {
                RSP = Door5;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door7"))
            {
                RSP = Door8;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door8"))
            {
                RSP = Door7;
                enterAllowedIn = true;
            }
            else if (keyDoor != null && collider.gameObject.name.Equals("Door9"))
            {
                if (ContainsKey(keyDoor.GetKeyType())){
                    RSP = Door10;
                    enterAllowedIn = true;
                }
            }
            else if (collider.gameObject.name.Equals("Door10"))
            {
                RSP = Door9;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door11"))
            {
                RSP = Door12;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door12"))
            {
                RSP = Door11;
                enterAllowedIn = true;
            }
            else if (keyDoor != null && collider.gameObject.name.Equals("Door13"))
            {
                if (ContainsKey(keyDoor.GetKeyType())){
                    RSP = Door14;
                    enterAllowedIn = true;
                }
            }
            else if (collider.gameObject.name.Equals("Door14"))
            {
                RSP = Door13;
                enterAllowedIn = true;
            }
        } 
        //CP3
        if (SceneManager.GetActiveScene().name == "CP3")
        {
            if (collider.gameObject.name.Equals("Door1"))
            {
                RSP = Door2;
                enterAllowedIn = true;
            
            } 
            else if (collider.gameObject.name.Equals("Door2"))
            {
                RSP = Door1;
                enterAllowedIn = true;
            }
            //CP3 TO CP4
            else if (keyDoor != null && collider.GetComponent<CP1TOCP2>()){
                if (ContainsKey(keyDoor.GetKeyType())){
                    sceneToLoad = "LD CP4";
                    enterAllowed = true;
                }  
            }
            else if (collider.gameObject.name.Equals("Door4"))
            {
                RSP = Door3;
                enterAllowedIn = true;
            } 
            else if (collider.gameObject.name.Equals("Door5"))
            {
                RSP = Door6;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door6"))
            {
                RSP = Door5;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door7"))
            {
                RSP = Door8;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door8"))
            {
                RSP = Door7;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door9"))
            {
                RSP = Door10;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door10"))
            {
                RSP = Door9;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door11"))
            {
                RSP = Door12;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door12"))
            {
                RSP = Door11;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door13"))
            {
                RSP = Door14;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door14"))
            {
                RSP = Door13;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door15"))
            {
                RSP = Door16;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door16"))
            {
                RSP = Door15;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door17"))
            {
                RSP = Door18;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door18"))
            {
                RSP = Door17;
                enterAllowedIn = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "CP4")
        {
            if (collider.gameObject.name.Equals("Door1"))
            {
                RSP = Door2;
                enterAllowedIn = true;
            
            } 
            else if (collider.gameObject.name.Equals("Door2"))
            {
                RSP = Door1;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door3"))
            {
                RSP = Door4;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door4"))
            {
                RSP = Door3;
                enterAllowedIn = true;
            } 
            else if (collider.gameObject.name.Equals("Door5"))
            {
                RSP = Door6;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door6"))
            {
                RSP = Door5;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door7"))
            {
                RSP = Door8;
                enterAllowedIn = true;
            }
            else if (collider.gameObject.name.Equals("Door8"))
            {
                RSP = Door7;
                enterAllowedIn = true;
            }
        }          
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        //CP0
        if (SceneManager.GetActiveScene().name == "CP0")
        {
            if (collider.GetComponent<BlueDoor>())
            {
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<BrownDoor>())
            {
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<CofInDoor>())
            {
                enterAllowedIn = false;
            }
        }
        if (SceneManager.GetActiveScene().name == "CP1")
        {
            if (collider.GetComponent<JailDoor>()){
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<CP1TOCP2>())
            {
                enterAllowed = false;
            }
            else if (collider.GetComponent<SCDoor>())
            {
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<DoorInSc>())
            {
                enterAllowedIn = false;
            }  
            else if (collider.GetComponent<DoorBack>())
            {
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<DoorInOS2A3>())
            {
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<DoorInOS3A4>())
            {
                enterAllowedIn = false;
            } 
            else if (collider.GetComponent<DoorInOS2A5>())
            {
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<DoorInIN2A6>())
            {
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<DoorInOS3A7>())
            {
                enterAllowedIn = false;
            }
            else if (collider.GetComponent<DoorInIN3A8>())
            {
                enterAllowedIn = false;
            }
        }
        //CP2
        if (SceneManager.GetActiveScene().name == "CP2")
        {
            if (collider.gameObject.name.Equals("Door1"))
            {
                enterAllowedIn = false;
            } 
            else if (collider.gameObject.name.Equals("Door2"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door3"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door4"))
            {
                enterAllowedIn = false;

            } 
            else if (collider.gameObject.name.Equals("Door5"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door6"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door7"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door8"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door9"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door10"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door11"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door12"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door13"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door14"))
            {
                enterAllowedIn = false;
            }
        }  
        //CP3
        if (SceneManager.GetActiveScene().name == "CP3")
        {
            if (collider.gameObject.name.Equals("Door1"))
            {
                enterAllowedIn = false;
            
            } 
            else if (collider.gameObject.name.Equals("Door2"))
            {
                enterAllowedIn = false;
            }
            //CP3 TO CP4
            else if (collider.GetComponent<CP1TOCP2>()){
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door4"))
            {
                enterAllowedIn = false;
            } 
            else if (collider.gameObject.name.Equals("Door5"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door6"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door7"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door8"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door9"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door10"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door11"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door12"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door13"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door14"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door15"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door16"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door17"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door18"))
            {
                enterAllowedIn = false;
            }
        } 
        //CP4
        if (SceneManager.GetActiveScene().name == "CP4")
        {
            if (collider.gameObject.name.Equals("Door1"))
            {
                enterAllowedIn = false;
            } 
            else if (collider.gameObject.name.Equals("Door2"))
            {
                enterAllowedIn = false;
            }
            else if (collider.gameObject.name.Equals("Door3"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door4"))
            {
                enterAllowedIn = false;

            } 
            else if (collider.gameObject.name.Equals("Door5"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door6"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door7"))
            {
                enterAllowedIn = false;

            }
            else if (collider.gameObject.name.Equals("Door8"))
            {
                enterAllowedIn = false;

            }  
        }  
    }
    
    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
            sceneToLoad = " ";
        }
        else if(enterAllowedIn && Input.GetKey(KeyCode.Return))
        {
            player.transform.position = RSP.transform.position;
            RSP = null;
            blackScreen.SetActive(true);
            canvas.SetActive(false);
            StartCoroutine (CountDown());
        }
    }

    public void EnterDoor()
    {
        if (enterAllowed)
        {
            SceneManager.LoadScene(sceneToLoad);
            blackScreen.SetActive(true);
        }
        else if(enterAllowedIn)
        {
            player.transform.position = RSP.transform.position;
            RSP = null;
            blackScreen.SetActive(true);
            canvas.SetActive(false);
            StartCoroutine (CountDown());
            
        }
        else{
            Debug.Log("No door");
        }
    }
    IEnumerator CountDown(){
        yield return new WaitForSeconds (1.5f);
        blackScreen.SetActive(false);
        canvas.SetActive(true);
    }
}
