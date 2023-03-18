using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCode : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    public Behaviour scriptenabled;
    public Animator animator;
    public AudioSource audioSource;
    
    float horizontalMove = 0f;

	[SerializeField]
	GameObject JailDoor, codePanel ,DigitCodeSw, DoorSwitch, Note1,DeadCon,KeyOPDoor,DL1,DL2;
    private bool enterAllowed;
    private bool enterAllowedSw;
    private bool enterAllowedSNote;
    private bool set;
    private bool canHide = false;
    private bool hiding = false; 
    public int loopCount = 0;
    

	public static bool isSafeOpened = false;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
        rend = GetComponent<SpriteRenderer> ();
		
        if (SceneManager.GetActiveScene().name == "Test" && SceneManager.GetActiveScene().name == "CP1")
        {
            JailDoor.SetActive (false);
            codePanel.SetActive (false);
            Note1.SetActive(false);
            DeadCon.SetActive(false);
            DigitCodeSw.SetActive (true);
            DL1.SetActive(false);
            DL2.SetActive(false);
            if(SceneManager.GetActiveScene().name == "Test"){
                 DoorSwitch.SetActive(false); 
            }
        }
        if (SceneManager.GetActiveScene().name == "CP3")
        {
            JailDoor.SetActive (false);
            codePanel.SetActive (false);
            Note1.SetActive(false);
            DeadCon.SetActive(false);
            DigitCodeSw.SetActive (true);
            
        }
        
	}
	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("Safe") && !isSafeOpened) {
			codePanel.SetActive (true);
		}
        else if (col.GetComponent<DigitCode>())
        {
            enterAllowed = true;
            set = true;
        } 
        else if (col.GetComponent<SwitchDoor>())
        {
            enterAllowedSw = true;
            set = true;
        }
        else if (col.GetComponent<Note>())
        {
            enterAllowedSNote = true;
            set = true;
        }
        else if (col.gameObject.name.Equals("Locker")){
            
            canHide = true;
        }
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("Safe")) {
			codePanel.SetActive (false);
		}
        else if (col.GetComponent<DigitCode>())
        {
            enterAllowed = false;
            set = false;
        } 
        else if (col.GetComponent<SwitchDoor>())
        {
            enterAllowedSw = false;
            set = false;
        }
        else if (col.GetComponent<Note>())
        {
            enterAllowedSNote = false;
            set = false;
        }
        else if (col.gameObject.name.Equals("Locker")){
            
            canHide = false;
        }
	}
    

    void Update () {
        if (SceneManager.GetActiveScene().name == "Test")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
            if (isSafeOpened) {
			    JailDoor.SetActive (true);
                codePanel.SetActive (false);
                DigitCodeSw.SetActive (false);
                
		    }
        }
        if (SceneManager.GetActiveScene().name == "CP1")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
            if (isSafeOpened) {
                loopCount++;
                if (loopCount == 1) {
                    JailDoor.SetActive (true);
                    codePanel.SetActive (false);
                    DigitCodeSw.SetActive (false);
                    DL1.SetActive(true);
                    DL2.SetActive(true);
                    scriptenabled.enabled = true;
                    if(KeyOPDoor != null) {
                        KeyOPDoor.SetActive (true);
                    } 
                } 
		    }
        }
        if (SceneManager.GetActiveScene().name == "CP3")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
            if (isSafeOpened) {
                loopCount++;
                if (loopCount == 1) {
                    JailDoor.SetActive (true);
                    codePanel.SetActive (false);
                    DigitCodeSw.SetActive (false);
                    scriptenabled.enabled = true;
                    DL1.SetActive(true);
                } 
		    }
        }
		
        //keyboard
        else if(enterAllowed && Input.GetKeyDown(KeyCode.Q)){
            
            codePanel.SetActive(set);
            Time.timeScale = 0f;
        }

        else if(enterAllowedSw && Input.GetKeyDown(KeyCode.Q)){
            DoorSwitch.SetActive(set);
            
        }
        else if(enterAllowedSNote && Input.GetKeyDown(KeyCode.Q)){
            Note1.SetActive(set); 
        }

	}


    public void EnterLocker(){
        if (canHide && hiding)
        {
            Physics2D.IgnoreLayerCollision(6, 8, false);
            rend.sortingOrder = 2;
            hiding = false;
            scriptenabled.enabled = true;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            
        }else if (canHide){
            
            Physics2D.IgnoreLayerCollision(6, 8, true);
            rend.sortingOrder = 0;
            hiding = true;
            scriptenabled.enabled = false;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
    }

    public void EnterCode()
    {
        if(enterAllowed){
            
            codePanel.SetActive(set);
            audioSource.Stop();
            scriptenabled.enabled = false;
            Time.timeScale = 0f;
        }
    }
    public void EnterNote()
    {
        if(enterAllowedSNote){
            Note1.SetActive(set);   
            audioSource.Stop();
            scriptenabled.enabled = false;
            Time.timeScale = 0f; 
        }
    }
     public void ExitCode()
    {
        codePanel.SetActive(false);
        Time.timeScale = 1f;
        scriptenabled.enabled = true;
    }

    public void ExitNote()
    {
        Note1.SetActive(false);
        Time.timeScale = 1f;
        scriptenabled.enabled = true;    
    }

    public void DeadCn()
    {
        DeadCon.SetActive(false);
        Time.timeScale = 1f;
    }
}
