using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDisableTargets : MonoBehaviour {

	public GameObject[] targets;
    public bool needsKey = false;

	void OnTriggerEnter(Collider c)
	{
		// Ignorar todo lo que no sea el jugador
		if (c.CompareTag ("Player") == false)
			return;

        PlayerInventory inventory = c.GetComponent<PlayerInventory>();
        if (inventory == null) return;

        if (needsKey && inventory.UseKey() == false) return; // use key returns false if I don't have keys

		foreach (GameObject g in targets) {
			g.SetActive (false);
		}
	}
}
