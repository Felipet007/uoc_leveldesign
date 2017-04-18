using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player") == false) return;

        PlayerInventory inventory = c.GetComponent<PlayerInventory>();
        if (inventory == null) return;

        inventory.AddKey();
        Destroy(this.gameObject);
    }
}
