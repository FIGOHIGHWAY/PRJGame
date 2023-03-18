using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFlip : MonoBehaviour
{
    [Header("Cameratrap time")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    
    private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    private IEnumerator Start(){
        while (true){
            yield return new WaitForSeconds(activationDelay);
            Flip();

            yield return new WaitForSeconds(activeTime);
            Flip();
        }
        
    }
}
