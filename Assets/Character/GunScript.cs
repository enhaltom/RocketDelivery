using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
    public float rotOffest = 90;

	// Update is called once per frame
	void Update () {
        //Positon the player mouse as gun
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize(); // Normailize the vector. Meaning the vector will be equal to 1
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Find the angle in degrees 
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotOffest);

    }
}
