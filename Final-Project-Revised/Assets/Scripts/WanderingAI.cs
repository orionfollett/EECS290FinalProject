using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
	public const float baseSpeed = 0.3f;

	public float speed;
	public float obstacleRange = 5.0f;
	
	private GameObject playerObject;
	
	private bool _alive;
	private int _animState;
	private float _multiplier;
	int i = 0;

	Animator anim;

	void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void Start() {
		_alive = true;
		
		//anim = GetComponent<Animator>();
		playerObject = GameObject.Find("HumanPlayer");
		speed = baseSpeed;

		Vector3 diff = playerObject.transform.position - transform.position;
		float range = diff.magnitude;
		
		if (range > 8.0f) {
			//anim.SetInteger("zombieToState", 0);
			//_animState = 0;
			_multiplier = 0.0f;
		}
		if (range > 6.0f && range <= 8.0f) { 
			//anim.SetInteger("zombieToState", 1);
			//_animState = 1;
			_multiplier = 3.0f;
		}
		if (range <= 6.0f) { 
			//anim.SetInteger("zombieToState", 3);
			//_animState = 3;
			_multiplier = 8.0f;

		}

	}
	
	void Update() {
		if (_alive) {

			//if very far away zombie speed = 0: idle animation
			//if somewhat close zombie speed = walking speed: walking animation
			//if near zombie speed = 8.0*walking speed:running animation

			Vector3 diff = playerObject.transform.position - transform.position;
			float range = diff.magnitude;

			if (range > 8.0f && _animState != 0) {
				//anim.SetInteger("zombieToState", 0);
				_multiplier = 0.0f;
			}

			if (range > 6.0f && range <= 8.0f && _animState != 1) { 
				//anim.SetInteger("zombieToState", 1);
				_multiplier = 8.0f;
			}

			if (range <= 6.0f  && _animState != 3) { 
				//anim.SetInteger("zombieToState", 3);
				_multiplier = 12.0f;
			}

			Ray ray = new Ray(transform.position, transform.forward);
			Debug.DrawRay(transform.position, transform.forward * 1000, Color.green);
			RaycastHit hit;
			if (Physics.SphereCast(ray, 0.75f, out hit))
			{
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.name == "HumanPlayer")
				{
					_multiplier = 22f;
				}
				else if (Random.Range(0,10) >= 9)
				{
					_multiplier = 5f;
					float angle = Random.Range(-110, 110);
					transform.Rotate(0, angle, 0);
				}
			}

			transform.Translate(0, 0, _multiplier*speed * Time.deltaTime);

			
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}
}
