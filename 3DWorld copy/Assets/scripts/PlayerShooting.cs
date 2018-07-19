using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	[SerializeField]Shoot Gun;

	void Update(){
		if (Manager.Instance.InputControl.ShootFirst || Manager.Instance.InputControl.ShootFPS) {
			print ("shoot");
			Gun.ShootIt ();
		}
	}
}
