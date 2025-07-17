using System;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMain : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject player;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthbarS healthbar;

    public PlayerInteraction playerInteract;
    public int attackPower = 1;
    public float attackCooldown = 1f;
    private float lastAttackTime = -Mathf.Infinity;

    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        healthbar.setmaxHealth(maxHealth);
        player = GameObject.FindGameObjectWithTag("Player");
        playerInteract = player.GetComponent<PlayerInteraction>();
    }

    void Update()
    {
        FollowPlayer();
        ZombieLife();
        attackPlayer();
    }

    private void attackPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 1f &&
        Time.time > lastAttackTime + attackCooldown)
        {
            playerInteract.takeDmg(attackPower);
            lastAttackTime = Time.time; 
        }
    }

    public void ZombieLife()
    {
        if (currentHealth <= 0)
        {
            playerInteract.killEnemy();
            Destroy(gameObject);
        }
    }

    private void FollowPlayer()
    {
        agent.SetDestination(player.transform.position);
        LookAtYOnly(player.transform.position);
    }

    void LookAtYOnly(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0; 

        if (direction != Vector3.zero) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
    public void DealDamageZomb(int dmg)
    {
        currentHealth -= dmg;
        healthbar.setHealth(currentHealth);
    }
}
