using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	void Update() {
		Debug.Log ("In the updated function");
		Debug.Log (playerStats.Health);

		if (transform.position.y <= ydeath) {
			DamagePlayer (99999);
			Debug.Log ("Kill PLayer in the updated function");
		}
	}


	void Start (){
		
	}

	[System.Serializable]
	public class PlayerStats {
	public int Health = 100;
	};

	public PlayerStats playerStats = new PlayerStats ();
	public int ydeath = -20;



	public void DamagePlayer(int damage) {
		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			Debug.Log ("Kill PLayer");
			Gamemaster.KillPlayer (this);
		}
	}


}