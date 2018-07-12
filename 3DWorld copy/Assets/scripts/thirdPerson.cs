using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPerson : MonoBehaviour {
	
	[SerializeField]Vector3 cameraOffset;
	[SerializeField]float damping;


	Transform Ahead;

	public Player localPlayer;
	// Use this for initialization
	void Awake () {
		Manager.Instance.playerJoined += HandleOnPlayerJoined;;
	}

	void HandleOnPlayerJoined(Player player){
		localPlayer = player;
		Ahead = localPlayer.transform.Find ("Ahead");

		if (Ahead == null)
			Ahead = localPlayer.transform;
	}
	
	// Update is called once per frame
	//Sets target position and adds transforms in front of player then moves camera behind player
	void Update () {
		Vector3 targPos = Ahead.position + localPlayer.transform.forward * cameraOffset.z
		                  + localPlayer.transform.up * cameraOffset.y +
		                  localPlayer.transform.right * cameraOffset.x;

		transform.position = Vector3.Lerp (transform.position, targPos, damping + Time.deltaTime);
	}
}
