using System.Collections;
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

    public float wobbleAmount = 0.2f; // How much to scale up/down
    public float wobbleDuration = 0.3f; // How long the wobble lasts
    private Vector3 originalScale;
    private bool isWobbling = false;

    void Start()
    {
        originalScale = transform.localScale;
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
        if (Vector3.Distance(transform.position, player.transform.position) <= 1.5f &&
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
            AudioManager.Instance.Play("ZombDed");
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
        AudioManager.Instance.Play("ZombDmg");
        currentHealth -= dmg;
        healthbar.setHealth(currentHealth);

        // Start the wobble effect
        if (!isWobbling)
        {
            StartCoroutine(WobbleEffect());
        }
    }

    private IEnumerator WobbleEffect()
    {
        isWobbling = true;

        float timer = 0f;

        while (timer < wobbleDuration)
        {
            // Calculate progress (0 to 1)
            float progress = timer / wobbleDuration;

            // Create a sine wave that goes from 0 to π (one full wobble)
            float wobble = Mathf.Sin(progress * Mathf.PI) * wobbleAmount;

            
            transform.localScale = originalScale * (1 + wobble);

            timer += Time.deltaTime;
            yield return null;
        }

        
        transform.localScale = originalScale;
        isWobbling = false;
    }
}
