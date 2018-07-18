using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveControl))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour {


	[System.Serializable]
	public class mInput{
		public Vector2 Damping;
		public Vector2 Sensitivty;
	
	}
	AudioClip walk;

	[SerializeField]float speed = 0.4f;
	[SerializeField]mInput mouseControl;
	[SerializeField]AudioClip steps;
	[SerializeField]AudioSource source;

	public float jumpSpeed;
	public float jumpStrength = 10;
	public float gravity = 14;



	bool isGrounded = false;

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

	void onCollisionEnter(Collision other){
		if (other.gameObject.name == "floor") {
			isGrounded = true;
		}
	}

	void onCollisionExit(Collision other){
		
		if (other.gameObject.name == "floor") {
			isGrounded = false;
		}
	}

	void Start () {
		source = GetComponent<AudioSource> ();
		//canPlay = true;
	}




	void Awake () {
		Manager.Instance.LocalPlayer = this;
	}

	public float timeBetween = 5;
	float time;
	float lastTime = 0;

	// Update is called once per frame
	void Update () {
		time = Time.deltaTime;
		
		Vector2 direction = new Vector2 (Manager.Instance.InputControl.Vertical * speed, Manager.Instance.InputControl.Horizontal);
		//print (direction);


		if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0){
			if (time - lastTime < timeBetween) {
				source.PlayOneShot(steps);
			}

		}


		MoveControl.Move(direction);

		/*if (Input.GetKey (KeyCode.D)) {
			float holder = transform.position.x;
			holder += speed;

			transform.position = new Vector3 (holder, transform.position.y, transform.position.z);

		}
		if (Input.GetKey (KeyCode.A)) {
			float holder = transform.position.x;s
			holder -= speed;

			transform.position = new Vector3 (holder, transform.position.y, transform.position.z);

		}

		if (Input.GetKey (KeyCode.W)) {
			float holder = transform.position.z;
			holder += speed;

			transform.position = new Vector3 (transform.position.x, transform.position.y, holder);

		}
		if (Input.GetKey (KeyCode.S)) {
			float holder = transform.position.z;
			holder -= speed;

			transform.position = new Vector3 (transform.position.x, transform.position.y,holder);

		}*/
			
			



		mouseIn.x = Mathf.Lerp (mouseIn.x, Manager.Instance.InputControl.Horizontal * speed, 1f / mouseControl.Damping.x);

		transform.Rotate (Vector3.up * mouseIn.x * mouseControl.Sensitivty.x);
	}

}
