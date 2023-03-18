using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLCK : MonoBehaviour
{
    [SerializeField]
	GameObject Key1,DL1;
    private GameObject keyObject;
    private GameObject DLObject;
    private bool enterAllowed;
    // Start is called before the first frame update

    private void Start (){
        keyObject = null;
        DLObject = null;
    }

    private void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.name.Equals("LCK") && SceneManager.GetActiveScene().name == "CP1"){
            DLObject = DL1;
            keyObject = Key1;
            enterAllowed = true;
        }
        if (col.gameObject.name.Equals("Bin") && SceneManager.GetActiveScene().name == "CP3"){
            keyObject = Key1;
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.name.Equals("LCK") && SceneManager.GetActiveScene().name == "CP1"){
            DLObject = null;
            keyObject = null;
            enterAllowed = false;
        }
        if (col.gameObject.name.Equals("Bin") && SceneManager.GetActiveScene().name == "CP3"){
            keyObject = null;
            enterAllowed = false;
        }
    }

    public void EnterLOCK()
    {
        if(enterAllowed){
            if(SceneManager.GetActiveScene().name == "CP1"){
                DLObject.SetActive(true);
            }
            
            keyObject.SetActive(true);
        }
    }
}
