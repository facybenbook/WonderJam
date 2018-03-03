﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaker : MonoBehaviour {

	[SerializeField]
	private Joint _joint;

	[SerializeField]
	private GameObject _lastContact;

	void Start () {
		_joint = GetComponent<Joint>();
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag("Player")) {
			_lastContact = col.gameObject;

			if (_joint != null)
				return;

			AddScore(col.relativeVelocity.sqrMagnitude, col.gameObject);
		}

	}

	void OnJointBreak(float breakForce)
    {
		if (_joint == null || (_lastContact != null && !_lastContact.CompareTag("Player")))
			return;

		AddScore(breakForce / 100, _lastContact);		
    }

	void AddScore(float impact, GameObject player) {
		GameManager.GetInstance().addScore((int)impact);

		Destroy(this);
	}
}