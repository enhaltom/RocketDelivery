using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 1;
    public LayerMask notToHit;
    public Transform BulletTrailPrefab;
    public Transform muzzleFlash;
    float timeToSpawnEffect;
    float effectSpawmRate = 10;
    float timeToFire = 0;

    
    Transform firePoint;

    void Awake()
    {
        firePoint = transform.FindChild("Firepoint");
        if (firePoint == null)
        {
            Debug.LogError("Why you know have a fire point");
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
        if (fireRate == 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}
    void Shoot ()
    {
        // Debug.Log("Shoot");
        Vector2 mousePostion = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePostion-firePointPosition, 100, notToHit);
        if(Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawmRate;
        }
        Debug.DrawLine(firePointPosition, (mousePostion - firePointPosition) * 100, Color.cyan);
        if (hit.collider != null)
        {
            Debug.Log("I hit something");
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");

        }

    }
    void Effect ()
    {
        Instantiate(BulletTrailPrefab,firePoint.position, firePoint.rotation);
        Transform clone = (Transform)Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        clone.parent = firePoint;
        float size = Random.Range(0.06f, 0.09f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.03f);


    }
}
