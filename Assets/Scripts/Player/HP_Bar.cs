using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class HP_Bar : MonoBehaviour {

	public Sprite[] images;
	public int currentHP = 3;

	void Start(){
		GetComponent<Image> ().sprite = images [currentHP];
	}

	public void reduce(){
		currentHP--;
		GetComponent<Image> ().sprite = images [currentHP];
	}

	public void increase(){
		currentHP++;
		GetComponent<Image> ().sprite = images [currentHP];
	}
}
