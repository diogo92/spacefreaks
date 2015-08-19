using UnityEngine;
using System.Collections;

public class MissileSpawner : MonoBehaviour {


	public GameObject missile;
	public float spawnTime = 3;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnMissile", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void spawnMissile () {
		Instantiate (missile, transform.position, Quaternion.identity);
	}
}
