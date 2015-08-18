using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform player;

	float lastPlayerX;
	float nextPlayerX;
	void Start(){
		lastPlayerX = -100;
	}
	// Update is called once per frame
	void Update () {
		nextPlayerX = player.transform.position.x - 2.5f;

		if (nextPlayerX > lastPlayerX) {
			lastPlayerX=nextPlayerX;
			transform.position=new Vector3(nextPlayerX,transform.position.y,transform.position.z);
		}
	}
}
