using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	Animator anim;

	void Start(){

		//anim = GetComponent<Animator>();
	}


	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		behavior.SetAlive(false);
		StartCoroutine(Stun(behavior));
	}

	private IEnumerator Stun(WanderingAI behavior) {
		
		
		yield return new WaitForSeconds(5f);
		behavior.SetAlive(true);
		Debug.Log("stun ended");
	}
}
