using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTrigger : MonoBehaviour {
    public int healAmount = 50;

	void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player") == false) return;

		CompleteProject.PlayerHealth health = c.GetComponent<CompleteProject.PlayerHealth>();

        int hp = health.currentHealth;
        hp += healAmount;
        if (hp > 100) hp = 100;

        health.currentHealth = hp;

        GameObject.Destroy(this.gameObject);
    }
}
