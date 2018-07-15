using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {

	public void Move(Vector2 dir){
		//transform.position = new Vector2 (dir.x, dir.y);
		transform.position += transform.forward * dir.x * Time.deltaTime + transform.right * dir.y * Time.deltaTime;
	}
}
