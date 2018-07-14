using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveControl))]
public class Player : MonoBehaviour {


	[System.Serializable]
	public class mInput{
		public Vector2 Damping;
		public Vector2 Sensitivty;
	
	}
	[SerializeField]float speed;
	[SerializeField]mInput mouseControl;

	private MoveControl moveC;
	public MoveControl MoveControl {
		get{ 
			if (moveC == null) {
				moveC = GetComponent<MoveControl> ();
			}
				
			return moveC;
		}
	}

	Vector2 mouseIn;



	void Awake () {
		Manager.Instance.LocalPlayer = this;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 direction = new Vector2 (Manager.Instance.InputControl.Vertical * speed, Manager.Instance.InputControl.Horizontal);
		MoveControl.Move(direction);

		mouseIn.x = Mathf.Lerp (mouseIn.x, Manager.Instance.InputControl.Horizontal * speed, 1f / mouseControl.Damping.x);

		transform.Rotate (Vector3.up * mouseIn.x * mouseControl.Sensitivty.x);
	}

}
