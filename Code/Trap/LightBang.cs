using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBang : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    public GameObject lightCamera;

    private void True()
	{
		lightCamera.GetComponent<Renderer>().enabled = true;
	}
    
    private void False()
	{
		lightCamera.GetComponent<Renderer>().enabled = false;
	}

    // Start is called before the first frame update
    private IEnumerator Start(){
        while (true){
  
            yield return new WaitForSeconds(activationDelay);
            True();

            yield return new WaitForSeconds(activeTime);
            False();
        }
        
    }
    
}
