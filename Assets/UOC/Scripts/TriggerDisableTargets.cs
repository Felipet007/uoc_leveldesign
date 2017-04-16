using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDisableTargets : MonoBehaviour {

	public GameObject[] targets;

	void OnTriggerEnter(Collider c)
	{
		// Ignorar todo lo que no sea el jugador
		if (c.CompareTag ("Player") == false)
			return; 
		
		foreach (GameObject g in targets) {
			g.SetActive (false);
		}
	}
}
