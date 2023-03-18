using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomGenText : MonoBehaviour
{
    [SerializeField]
	Text TextBox;
    int randomNumberOne;
    int randomNumberTwo;
    int randomNumberThree;
    int randomNumberFour;
    public static string sum;
    
    void Start(){
        
        randomFirstText();
        
    }

    void Update () 
    {

        TextBox.text = sum;

	}
    
    public void randomFirstText(){
        
        randomNumberOne = Random.Range(0,9);
        randomNumberTwo = Random.Range(0,9);
        randomNumberThree = Random.Range(0,9);
        randomNumberFour = Random.Range(0,9);

        string[] intArray = new string[] 
        {
            randomNumberOne.ToString(),
            randomNumberTwo.ToString(),
            randomNumberThree.ToString(),
            randomNumberFour.ToString()
        };

        foreach(var i in intArray) {
            
            sum += i;
        }
    } 


    

}
    
