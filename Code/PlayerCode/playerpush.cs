using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class playerpush : MonoBehaviour
{
    public float distance=1f;
	public LayerMask boxMask;
	public Button BB;
    public Button BA;

	GameObject box;
	public bool isPushing = false;
	private bool isHolding = false;

	
	// Update is called once per frame
	void Update () {
	
		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit= Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
	
		if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown (KeyCode.E)) {


			box = hit.collider.gameObject;
			box.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();
			box.GetComponent<FixedJoint2D> ().enabled = true;
			box.GetComponent<boxpull> ().beingPushed = true;

		} else if (Input.GetKeyUp (KeyCode.E)) {
			box.GetComponent<FixedJoint2D> ().enabled = false;
			box.GetComponent<boxpull> ().beingPushed = false;
		}
		

		if (isPushing && !isHolding)
        {
            drop();
        }
		
	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
	}
		
	public void push()
	{
		isPushing = true;
		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit= Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
		if (hit.collider != null && hit.collider.gameObject.tag == "pushable"){
			box = hit.collider.gameObject;
			box.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();
			box.GetComponent<FixedJoint2D> ().enabled = true;
			box.GetComponent<boxpull> ().beingPushed = true;
			BB.enabled = false;
       	 	BA.enabled = false;
		}
	}

	public void drop()
    {
        isPushing = false;
        if (box != null)
        {
            box.GetComponent<FixedJoint2D> ().enabled = false;
            box.GetComponent<boxpull> ().beingPushed = false;
			BB.enabled = true;
        	BA.enabled = true;
            box = null;
        }
    }

	public void ButtonPush()
    {
        isHolding = true;
        push();
    }

    public void ButtonRelease()
    {
        isHolding = false;
        drop();
		
    }
}
