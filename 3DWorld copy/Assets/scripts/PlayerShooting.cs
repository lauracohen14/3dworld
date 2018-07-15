using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	[SerializeField]Shoot Gun;

	void Update(){
		if (Manager.Instance.InputControl.ShootFirst) {
			print ("shoot");
			Gun.ShootIt ();
		}
	}
}
