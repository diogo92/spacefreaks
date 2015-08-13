using UnityEngine;
using System.Collections;

public class Collisions_Sounds : MonoBehaviour {

	AudioSource audio;

	void Start () {
		audio = gameObject.AddComponent < AudioSource > ();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl)){
			audio.volume = 0.1f;
			audio.PlayOneShot((AudioClip)Resources.Load("sfx_pew"));
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			audio.volume = 1f;
			audio.PlayOneShot((AudioClip)Resources.Load("sfx_move"));
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		switch (collision.gameObject.name) {
		case "BotWall":
			audio.PlayOneShot((AudioClip)Resources.Load("sfx_thud"));
			break;
		case "TopWall":
			audio.PlayOneShot((AudioClip)Resources.Load("sfx_thud"));
			break;


		}
	}
}

