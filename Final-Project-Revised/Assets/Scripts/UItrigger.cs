using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UItrigger : MonoBehaviour {

	public GameObject welcomeCanvas;
	public float fadeSpeed = 10.0f;

	private bool _entrance;
	private bool _active;


	

	void Awake (){
	}

	// Use this for initialization
	void Start () {

		_entrance = false;
		_active = true;

	}

	void Update (){

		ColorChange();

	}
	void OnTriggerEnter(Collider other) {

		_entrance = true;

	}

	void OnTriggerExit(Collider other) {

		_entrance = false;
		_active = false;

	}

	void ColorChange(){

		if(_entrance && _active){

		}

	}
}