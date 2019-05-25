using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    [System.Serializable]
    public struct EnemySpawn
    {
        public GameObject enemyPrefab;
        public Vector3 offset;
        public int quantity;
    }

    public List<EnemySpawn> groups = new List<EnemySpawn>();
    public float respawnTimerMin = 2.0f;
    public float respawnTimerMax = 3.0f;

    public void Start()
    {
        if (respawnTimerMax == 0) SpawnEnemies();
        else if (respawnTimerMax > 0)
            Invoke("SpawnEnemies", Random.Range(respawnTimerMin,respawnTimerMax));   
    }

    [ContextMenu("SpawnEnemies")]
    public void SpawnEnemies()
    {
        foreach (EnemySpawn spawn in groups)
        {
            for (int i = 0; i < spawn.quantity; i++)
            {
                GameObject.Instantiate(spawn.enemyPrefab, transform.position + spawn.offset, Quaternion.identity);
            }
        }
        Invoke("SpawnEnemies", Random.Range(respawnTimerMin, respawnTimerMax));
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player") == false) return;

        SpawnEnemies();

        GameObject.Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (groups == null) groups = new List<EnemySpawn>();
        foreach (EnemySpawn spawn in groups)
        {
            Gizmos.DrawSphere(transform.position + spawn.offset, 0.5f);
        }
        
    }
}
