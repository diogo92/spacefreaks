using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void Start () {
		Invoke ("Destroy",3);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Destroy(){
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy ();
	}
}
