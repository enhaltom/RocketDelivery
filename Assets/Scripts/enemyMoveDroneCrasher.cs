using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class enemyMoveDroneCrasher : MonoBehaviour {

	private PlatformerCharacter2D thePlayer;

	public float moveSpeed;

	public float playerRange;

	public LayerMask playerLayer;

	public bool playerInRange;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlatformerCharacter2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerLayer);
		if (playerInRange) 
			transform.position = Vector3.MoveTowards (transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
	
	}

	void OnDrawGizmosSelected () {
		Gizmos.DrawWireSphere (transform.position, playerRange);
	}
}
