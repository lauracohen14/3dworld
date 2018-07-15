using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField]float speed;
	[SerializeField]float timeToLive;
	[SerializeField]float damage;

	void Update(){

		transform.Translate (Vector3.forward * speed * Time.deltaTime);

	}

	void Start(){
		Destroy (gameObject, timeToLive);
	}


		
	void onTriggerEnter(Collider other){
		print ("Hit something" + other.name);
	}
}
