using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	[SerializeField]float fireRate;
	[SerializeField]Bullet bullet;

	[HideInInspector]
	public Transform muzzle;

	bool canShoot;
	float nextShoot;

	void Awake(){
		muzzle = transform.Find("Muzzle");
	}

	public virtual void ShootIt(){
		print ("shooting");
		//canShoot = false;

		//if (Time.time < nextShoot)
		//	return;
		
		//nextShoot = Time.time + fireRate;

		Instantiate (bullet, muzzle.position, muzzle.rotation);

		canShoot = true;
	
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frames
	void Update () {
		
	}
}
