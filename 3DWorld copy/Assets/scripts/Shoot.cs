using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour {

	[SerializeField]float fireRate;
	//[SerializeField]Bullet bullet;

	[HideInInspector]
	public Transform muzzle;
	[SerializeField]AudioClip destroy;
	[SerializeField]AudioSource sourceOther;
	[SerializeField]AudioClip shoot;
	[SerializeField]AudioSource source;
	[SerializeField]AudioClip background;
	[SerializeField]AudioSource sourceSecondOther;

	bool canShoot;
	float nextShoot;
	public int range = 100;

	void Awake(){
		muzzle = transform.Find("Muzzle");
	}

	public virtual void ShootIt(){
		print ("shooting");
		source.PlayOneShot (shoot);
		//canShoot = false;

		//if (Time.time < nextShoot)
		//	return;
		
		//nextShoot = Time.time + fireRate;

		//Instantiate (bullet, muzzle.position, muzzle.rotation);

		RaycastHit hit;

		if (Physics.Raycast (muzzle.position, muzzle.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name + " found!");
			Destroy (hit.collider.gameObject);
			sourceOther.PlayOneShot (destroy);
		}

		canShoot = true;
	
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frames
	void Update () {
		
	}
}
