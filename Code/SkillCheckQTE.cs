using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckQTE : MonoBehaviour
{
    public GameObject promptText;
    public GameObject successText;
    public GameObject failText;
    public float promptDuration = 1f;
    public KeyCode keyCode;
    public float successThreshold = 0.5f;

    private bool isActive = false;
    private bool success = false;

    void Start()
    {
        promptText.SetActive(false);
        successText.SetActive(false);
        failText.SetActive(false);
    }

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(keyCode))
            {
                success = (Random.value < successThreshold);
                isActive = false;
                promptText.SetActive(false);
                if (success)
                {
                    successText.SetActive(true);
                }
                else
                {
                    failText.SetActive(true);
                }
            }
        }
    }

    public void StartQTE()
    {
        if (!isActive)
        {
            isActive = true;
            success = false;
            promptText.SetActive(true);
            Invoke("EndQTE", promptDuration);
        }
    }

    void EndQTE()
    {
        if (isActive)
        {
            isActive = false;
            promptText.SetActive(false);
            if (!success)
            {
                failText.SetActive(true);
            }
        }
    }
}
