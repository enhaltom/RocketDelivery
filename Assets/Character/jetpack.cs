using UnityEngine;
using System.Collections;

public class jetpack : MonoBehaviour {

	CharacterController cc;
	public float jetpackForce = 75.0f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	
		cc = (CharacterController) GetComponent<CharacterController> ();
		rb = (Rigidbody2D)GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		/*
		 if(Input.GetKey(KeyCode.LeftShift)){
			Vector3 velocity = new Vector3 (0, 10, 0);

		}
		*/
	}

	void FixedUpdate () 
	{
		bool jetpackActive = Input.GetKey(KeyCode.LeftShift);

		if (jetpackActive)
		{
			rb.AddForce (new Vector2 (0, jetpackForce));
		}
	}
}
