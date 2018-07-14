using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	[SerializeField]float fireRate;

	[HideInInspector]
	public Transform end;

	bool canShoot;
	float nextShoot;

	void Awake(){
		end = transform.Find ("End");
	}

	public virtual void ShootIt(){
		canShoot = false;

		if (Time.time < nextShoot)
			return;

		canShoot = true;
	
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
