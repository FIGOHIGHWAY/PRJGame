using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class CodeText : MonoBehaviour
{
    [SerializeField]
    public TMP_Text text;
    public static string codeCP3;
    private string randomBirthday;
    public static string codeCP1OS;
    private int randomNumberOne;
    private int randomNumberTwo;
    private int randomNumberThree;
    private int randomNumberFour;
    public static string sum;
    private string One;
    private string Two;
    private string Three;
    private string Four;
    public TMP_Text textOne;
    public TMP_Text textTwo;
    public TMP_Text textThree;
    public TMP_Text textFour;   
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "CP1")
        {
        RandomGenText randomizer = new RandomGenText();
        randomBirthday = randomizer.GetRandomBirthday();
        codeCP1OS = randomBirthday;
        codeCP1OS = codeCP1OS.Remove(7, 1).Remove(6, 1).Remove(5, 1).Remove(2, 1);
        Debug.Log(codeCP1OS);
        }
        if (SceneManager.GetActiveScene().name == "CP3")
        {
        randomNumberOne = UnityEngine.Random.Range(0,9);
        randomNumberTwo = UnityEngine.Random.Range(0,9);
        randomNumberThree = UnityEngine.Random.Range(0,9);
        randomNumberFour = UnityEngine.Random.Range(0,9);

        One = randomNumberOne.ToString();
        Two = randomNumberTwo.ToString();
        Three = randomNumberThree.ToString();
        Four = randomNumberFour.ToString();

        sum = randomNumberOne.ToString() + randomNumberTwo.ToString() + randomNumberThree.ToString() + randomNumberFour.ToString();
        codeCP3 = sum;
        Debug.Log("codeCP3 = " + codeCP3);
        }
        if (SceneManager.GetActiveScene().name == "CP1")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
            text.text = randomBirthday;
        }
        if (SceneManager.GetActiveScene().name == "CP3")
        {
            // ต้องอยู่ใน GameplayScene ก่อนทำอะไรต่อ
                textOne.text = One;
                textTwo.text = Two;
                textThree.text = Three;
                textFour.text = Four;
            
        } 
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
    
}
