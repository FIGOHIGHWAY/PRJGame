using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Dialogue : MonoBehaviour
{
    public Behaviour scriptenabled;
    public Button BB;
    public Button BA;
    public Button BL;
    public Button BR;
    public AudioSource audioSource;

    public Text text;
    public string[] lines;
    public float textSpeed;
    public Animator animator;
    float horizontalMove = 0f;


    private int index;
    
    
    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
        scriptenabled.enabled = false;
        BB.enabled = false;
        BA.enabled = false;
        audioSource.Stop();
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (SceneManager.GetActiveScene().name == "CP1")
        {
            BL.enabled = false;
            BR.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (text.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index =0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            scriptenabled.enabled = true;
            BB.enabled = true;
            BA.enabled = true;
             if (SceneManager.GetActiveScene().name == "CP1")
            {
                BL.enabled = true;
                BR.enabled = true;
            }
        }
    }
}
