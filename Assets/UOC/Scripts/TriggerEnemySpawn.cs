using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemySpawn : MonoBehaviour {
    
    [System.Serializable]
    public struct EnemySpawn
    {
        public GameObject enemyPrefab;
        public Vector3 offset;
        public int quantity;
    }

    public List<EnemySpawn> groups;

	void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player") == false) return;

        foreach (EnemySpawn spawn in groups)
        {
            for (int i = 0; i < spawn.quantity; i++)
            {
                GameObject.Instantiate(spawn.enemyPrefab, transform.position + spawn.offset, Quaternion.identity);
            }
        }

        GameObject.Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (EnemySpawn spawn in groups)
        {
            Gizmos.DrawSphere(transform.position + spawn.offset, 0.5f);
        }
        
    }
}
