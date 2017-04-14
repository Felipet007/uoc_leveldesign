using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        public float moveSpeed = 0.5f;
        public bool useNavMesh = false;

        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        void Update ()
        {
            // If the enemy and the player have health left...
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                if (useNavMesh)
                {
                    // ... set the destination of the nav mesh agent to the player.
                    nav.SetDestination(player.position);
                }
                else
                {
                    // Not using navmesh, just go towards the player if he's close
                    float distanceToPlayer = Vector3.Distance(player.position, transform.position);
                    if (distanceToPlayer < 10.0f)
                    {
                        Vector3 dirToPlayer = player.position - transform.position;
                        transform.position += dirToPlayer * Time.deltaTime * moveSpeed;
                        transform.LookAt(player);
                    }
                }
            }
            // Otherwise...
            else
            {
                if (useNavMesh)
                {
                    // ... disable the nav mesh agent.
                    nav.enabled = false;
                }
            }
        }
    }
}