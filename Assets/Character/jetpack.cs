using UnityEngine;
using System.Collections;

public class jetpack : MonoBehaviour {

	CharacterController cc;
	public GameObject fuel4;
	public GameObject fuel3;
	public GameObject fuel2;
	public GameObject fuel1;
	public GameObject fuel0;

	public float jetpackForce = 75.0f;
	public float secOfFlight = 2f;
	public static float fuel;
	float timer = 0;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	
		cc = (CharacterController) GetComponent<CharacterController> ();
		rb = (Rigidbody2D)GetComponent<Rigidbody2D> ();
		fuel = 4;
	}
	
	// Update is called once per frame
	void Update () {
	
		/*
		 if(Input.GetKey(KeyCode.LeftShift)){
			Vector3 velocity = new Vector3 (0, 10, 0);

		}
		*/

		if (fuel > 4) {
			fuel = 4;
		}


		if(fuel == 4) {
			fuel4.SetActive(true);
			fuel3.SetActive(false);
		}
		else if (fuel == 3){
			fuel4.SetActive(false);
			fuel3.SetActive(true);
			fuel2.SetActive(false);
		}else if (fuel == 2){
			fuel3.SetActive(false);
			fuel2.SetActive(true);
			fuel1.SetActive(false);
		}else if (fuel == 1){
			fuel2.SetActive(false);
			fuel1.SetActive(true);
			fuel0.SetActive(false);
		}else if (fuel == 0){
			fuel1.SetActive(false);
			fuel0.SetActive(true);
		}
	}

	void FixedUpdate () 
	{
		bool jetpackActive = Input.GetKey(KeyCode.LeftShift);

		if (jetpackActive && timer < secOfFlight && fuel > 0)
		{
			rb.AddForce (new Vector2 (0, jetpackForce));
			timer += Time.deltaTime;
		}

		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			timer = 0;
			fuel--;
			if (fuel < 0){
				fuel = 0;
			}
		}
	}
}
