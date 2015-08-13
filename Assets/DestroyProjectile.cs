using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {

	float timer;
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 5)
			Destroy (this.gameObject);
	}
}
