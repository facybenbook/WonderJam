﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : MonoBehaviour {

	[SerializeField]
	private float value;

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.tag);
		if (other.CompareTag ("Player")) {
			Player p = other.GetComponent<Player> ();
			p.modifyLife (value);
		}
			
	}
}
