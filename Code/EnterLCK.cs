using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLCK : MonoBehaviour
{
    [SerializeField]
	GameObject Key1,DL1,DL2,DoorLCK,Door;
    private GameObject keyObject;
    private GameObject DLObject;
    private GameObject DLObject2;
    private GameObject DLCK;
    private GameObject DR;
    private bool enterAllowed;
    // Start is called before the first frame update

    private void Start (){
        keyObject = null;
        DLObject = null;
        DLObject2 = null;
        DLCK = null;
        DR = null;
    }

    private void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.name.Equals("LCK") && SceneManager.GetActiveScene().name == "CP1"){
            DLObject = DL1;
            DLObject2 = DL2;
            keyObject = Key1;
            enterAllowed = true;
            DLCK = DoorLCK;
            DR = Door;
        }
        if (col.gameObject.name.Equals("Note") && SceneManager.GetActiveScene().name == "CP2"){
            DLObject = DL1;
            keyObject = Key1;
            enterAllowed = true;
            DLCK = DoorLCK;
            DR = Door;
        }
        if (col.gameObject.name.Equals("Bin") && SceneManager.GetActiveScene().name == "CP3"){
            keyObject = Key1;
            enterAllowed = true;
            DLObject = DL1;
            DLCK = DoorLCK;
        }  
    }

    private void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.name.Equals("LCK") && SceneManager.GetActiveScene().name == "CP1"){
            DLObject = null;
            DLObject2 = null;
            keyObject = null;
            enterAllowed = false;
            DLCK = null;
            DR = null;
        }
        if (col.gameObject.name.Equals("Note") && SceneManager.GetActiveScene().name == "CP2"){
            DLObject = null;
            keyObject = null;
            enterAllowed = false;
            DLCK = null;
            DR = null;
        }
        if (col.gameObject.name.Equals("Bin") && SceneManager.GetActiveScene().name == "CP3"){
            keyObject = null;
            enterAllowed = false;
            DLObject = null;
            DLCK = null;
        } 
    }

    public void EnterLOCK()
    {
        if(enterAllowed){
            if(SceneManager.GetActiveScene().name == "CP1" && SceneManager.GetActiveScene().name == "CP4" && SceneManager.GetActiveScene().name == "CP2"){
            }
            DLObject.SetActive(true);
            keyObject.SetActive(true);
            DLCK.SetActive(false);
            DR.SetActive(true);
            if(SceneManager.GetActiveScene().name == "CP1"){
                DLObject2.SetActive(true);
            }
        }
    }
}
