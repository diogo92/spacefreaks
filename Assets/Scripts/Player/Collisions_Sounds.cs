using UnityEngine;
using System.Collections;

public class Collisions_Sounds : MonoBehaviour {

	AudioSource audioNormal;
	AudioSource audioLower;
	bool shootSound = true;

	void Start () {
		audioNormal = gameObject.AddComponent < AudioSource > ();
		audioLower = gameObject.AddComponent < AudioSource > ();
		audioNormal.volume = 1f;
		audioLower.volume = 0.1f;
	}

	public void pewSound(){
		if (shootSound) {
			audioLower.PlayOneShot ((AudioClip)Resources.Load ("sfx_pew"));
			StartCoroutine (shootSoundCD ());
		}
	}

	public void jetpackSound(){
		audioNormal.PlayOneShot((AudioClip)Resources.Load("sfx_move"));
	}

	void OnCollisionEnter2D(Collision2D collision) {
		switch (collision.gameObject.name) {
		case "BotWall":
			audioLower.PlayOneShot((AudioClip)Resources.Load("sfx_thud"));
			break;
		case "TopWall":
			audioLower.PlayOneShot((AudioClip)Resources.Load("sfx_thud"));
			break;
		case "Missile(Clone)":
			GameObject hpbar = GameObject.FindGameObjectWithTag("HP_Bar");
			hpbar.GetComponent<HP_Bar>().reduce();
			break;

		}
	}

	IEnumerator shootSoundCD(){
		shootSound = false;
		yield return new WaitForSeconds (1f);
		shootSound = true;
	}
}

