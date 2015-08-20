using UnityEngine;
using System.Collections;

public class MissileSpawner : MonoBehaviour {


	public GameObject missile;
	public float spawnTime = 3;
	float posY = 0;
	// Use this for initialization
	void Start () {
		spawnMissile ();
	}
	
	// Update is called once per frame
	void spawnMissile () {
		posY = Random.Range (-4, 5);
		transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
		StartCoroutine(dangerSign());
	}

	public IEnumerator dangerSign(){
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.5f);
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.5f);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.5f);
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.5f);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (0.5f);
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.5f);
		fireMissile ();
	}

	void fireMissile(){
		Instantiate (missile, transform.position, Quaternion.identity);
		Invoke ("spawnMissile", Random.Range (5, 11));
	}
	
}
