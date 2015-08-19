using UnityEngine;
using System.Collections;

public class BackgroundCollector : MonoBehaviour {

	float posX = 0;
	bool bg1 = true;
	void Awake(){
		posX = transform.position.x;
	}

	void Update(){
		if(transform.position.x - posX >= 60){
			if(bg1){
				GameObject bg = GameObject.FindGameObjectWithTag("Background1");
				Vector3 t = bg.transform.position;
				bg.transform.position = new Vector3 ( t.x + 120, t.y, t.z);
				bg1=false;
			}
			else{
				GameObject bg = GameObject.FindGameObjectWithTag("Background2");
				Vector3 t = bg.transform.position;
				bg.transform.position = new Vector3 ( t.x + 120, t.y, t.z);
				bg1=true;
			}
			posX= transform.position.x;
		}
	}
}
