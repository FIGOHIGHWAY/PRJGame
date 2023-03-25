using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class QTESys : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    public float decreaseSpeed;
    bool freeze;//Stops slider from moving

    public Behaviour scriptenabled;
    public Animator animator;
    public event EventHandler OnKeysChanged;

    public GameObject player;
    public GameObject respawnPoint,Deadcon;
    public GameObject DisableOBJ;
    public GameObject DisplayBox;
    public GameObject PassBox;
    public GameObject Trigger;
    public GameObject OBJKey,Door,DoorLCK;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    float horizontalMove = 0f;

    public int loopCount = 0;

    void Start()
    {
        audioSource.Stop();
        scriptenabled.enabled = false;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    void Update(){

        if (!freeze)
        {
            slider.value = Mathf.MoveTowards(slider.value, 0, decreaseSpeed * Time.deltaTime);
        }
        if(WaitingForKey == 0){
            QTEGen = Random.Range (1,4);
            CountingDown = 1;
            StartCoroutine(CountDown());
            if(QTEGen == 1){
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text> ().text = "A";
            }

            if(QTEGen == 2){
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text> ().text = "B";
            }
        }
        // Check if new button is pressed
        if (Input.anyKeyDown){
            if (Input.GetButtonDown ("Z")){
                Button1Pressed();
            }else if (Input.GetButtonDown ("X")) {
                Button2Pressed();
            }
        }
    }

    void CheckInput(string button)
    {
        if (WaitingForKey == 1 && QTEGen == 1 && button == "Z"){
            CorrectKey = 1; 
            StartCoroutine (KeyPressing ());
        }
        else if (WaitingForKey == 1 && QTEGen == 2 && button == "X"){
            CorrectKey = 1;
            StartCoroutine (KeyPressing ());
        }
        else
        {
            CorrectKey = 2;
            StartCoroutine (KeyPressing ());
        }
    }

    public void Button1Pressed()
    {
        if(DisableOBJ){
            CheckInput("Z");
        } 
        else{
            Debug.Log("Dis");
        }
    }

    public void Button2Pressed()
    {
        if(DisableOBJ){
            CheckInput("X");
        }
        else{
            Debug.Log("Dis");
        }
    }
    
    IEnumerator KeyPressing(){
        QTEGen = 4;
        if (CorrectKey == 1 && slider.value > 0){
            CountingDown = 2;
            PassBox.GetComponent<Text> ().text = "PASS";
            freeze = true;
            yield return new WaitForSeconds (1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text> ().text = "";
            DisplayBox.GetComponent<Text> ().text = "";
            yield return new WaitForSeconds (1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
            freeze = false;
            ResetSliderValue();

            
            loopCount++;
            if (loopCount >= 2) {
                Debug.Log("Looping stopped.");
                // Stop looping here
                DisableOBJ.SetActive(false);
                scriptenabled.enabled = true;
                Trigger.SetActive(false);
                if (SceneManager.GetActiveScene().name == "CP2")
                {
                    OBJKey.SetActive(true);
                    Door.SetActive(true);
                    DoorLCK.SetActive(false);
                }
            }
        }
        if (CorrectKey == 2 || slider.value == 0){
            CountingDown = 2;
            PassBox.GetComponent<Text> ().text = "Fail!!!";
            freeze = true;
            yield return new WaitForSeconds (1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text> ().text = "";
            DisplayBox.GetComponent<Text> ().text = "";
            DisableOBJ.SetActive(false);
            Time.timeScale = 0f;
            Deadcon.SetActive (true);
            scriptenabled.enabled = true;
            player.transform.position = respawnPoint.transform.position;
            Trigger.SetActive (true);
        }
    }
    IEnumerator CountDown(){
        yield return new WaitForSeconds (3.5f);
        if(CountingDown == 1){
            QTEGen = 4;
            CountingDown = 2;
            PassBox.GetComponent<Text> ().text = "Fail!!!";
            freeze = true;
            yield return new WaitForSeconds (1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text> ().text = "";
            DisplayBox.GetComponent<Text> ().text = "";
            DisableOBJ.SetActive(false);
            Time.timeScale = 0f;
            Deadcon.SetActive (true);
            scriptenabled.enabled = true;
            player.transform.position = respawnPoint.transform.position;
            Trigger.SetActive (true);
        }
    }
    public void ResetSliderValue()
    {
        slider.value = 10;
    }
}
