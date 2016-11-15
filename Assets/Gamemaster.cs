using UnityEngine;
using System.Collections;

public class Gamemaster : MonoBehaviour {

	public static Gamemaster gm;
	public Transform playerPrefab;
	public Transform spawnPoint;
	public GameObject lives5;
	public GameObject lives4;
	public GameObject lives3;
	public GameObject lives2;
	public GameObject lives1;

	int lives;


	public static void KillPlayer (Player player){
		Destroy (player.gameObject);
		gm.decrementLives ();
		if (gm.lives > 0)
			gm.RespawnPlayer ();
		

	}
	void Start () {

		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<Gamemaster>();
		}
		lives = 5;
	}

	void Update () {

		if(lives == 5) {
			lives5.SetActive(true);
		}
		else if (lives == 4){
			lives5.SetActive(false);
			lives4.SetActive(true);
		}else if (lives == 3){
			lives4.SetActive(false);
			lives3.SetActive(true);
		}else if (lives == 2){
			lives3.SetActive(false);
			lives2.SetActive(true);
		}else if (lives == 1){
			lives2.SetActive(false);
			lives1.SetActive(true);
		}


	}


	public void decrementLives (){
		lives--;
	}

	public void RespawnPlayer(){
		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		Debug.Log ("TODO: Add Spawn Particles");

	}
}
