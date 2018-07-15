using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPerson : MonoBehaviour {

	[SerializeField]Vector3 cameraOffset;
	[SerializeField]float damping;


	Transform Ahead;
	GameObject cam;

	public Player localPlayer;
	// Use this for initialization
	void Awake () {
		Manager.Instance.playerJoined += HandleOnPlayerJoined;;
		cam = GameObject.Find ("ThirdPerson");
	}

	void HandleOnPlayerJoined(Player player){
		localPlayer = player;
		Ahead = localPlayer.transform.Find ("Ahead");
		cam = GameObject.Find("ThirdPerson");
		//cam = localPlayer.transform.Find ("Main Camera");


		if (Ahead == null)
			Ahead = localPlayer.transform;
	}

	// Update is called once per frame
	//Sets target position and adds transforms in front of player then moves camera behind player
	void Update () {
		Vector3 targPos = Ahead.position + localPlayer.transform.forward * cameraOffset.z
			+ localPlayer.transform.up * cameraOffset.y +
			localPlayer.transform.right * cameraOffset.x;

		if (Input.GetKey(KeyCode.O)) {
			float holder = cam.transform.position.y;
			holder += 0.5f;

			cam.transform.position = new Vector3 (cam.transform.position.x, holder, cam.transform.position.z);
			//Ahead.transform.position.y += 1;
		}
		if (Input.GetKey(KeyCode.I)) {
			float holder = cam.transform.position.y;
			holder -= 0.5f;

			cam.transform.position = new Vector3 (cam.transform.position.x, holder, cam.transform.position.z);
			//Ahead.transform.position.y += 1;
		}

		if (Input.GetKey(KeyCode.L)) {
			float holder = cam.transform.position.z;
			holder += 0.5f;
			cam.transform.position = new Vector3 (cam.transform.position.x, cam.transform.position.y, holder);
		}
		if (Input.GetKey(KeyCode.K)) {
			float holder = cam.transform.position.z;
			holder -= 0.5f;
			cam.transform.position = new Vector3 (cam.transform.position.x, cam.transform.position.y, holder);
		}

		Quaternion tRot = Quaternion.LookRotation (Ahead.position - targPos, Vector3.up);

		transform.position = Vector3.Lerp (transform.position, targPos, damping + Time.deltaTime);
		transform.rotation = Quaternion.Lerp (transform.rotation,tRot, damping + Time.deltaTime);
	}
}
