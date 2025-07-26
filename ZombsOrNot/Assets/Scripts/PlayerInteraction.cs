using System;
using System.Collections;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int playerLevel;
    public CharacterController characterController;

    public Canvas pDiedCanv;


    private int zombieNumber;

    public HealthbarS healthbar;
    public GameplayManager gameplayManager;

    public float wobbleAmount = 0.2f; // How much to scale up/down
    public float wobbleDuration = 0.3f; // How long the wobble lasts
    private Vector3 originalScale;
    private bool isWobbling = false;
    private void Start()
    {
        PlayerPrefs.SetInt("started", 0);
        originalScale = transform.localScale;
        //temp
        PlayerPrefs.SetInt("Creds", 500);//delete line when publish
        //temp
        playerLevel = PlayerPrefs.GetInt("Level",1);
        currentHealth = maxHealth;
        Application.targetFrameRate = 120;
        checkandsetHealth();
    }

    private void Update()
    {
        changeLevel();
    }

    private void changeLevel()
    {
        if (Input.GetKey(KeyCode.T))
        {
            PlayerPrefs.SetInt("Level", 1);
            playerLevel = PlayerPrefs.GetInt("Level");
        }
    }

    public void roundStart()
    {
        zombieNumber = gameplayManager.zombieNumber;
        checkandsetHealth();
    }

    private void checkandsetHealth()
    {
        int k = PlayerPrefs.GetInt("H_Lvl", 1);
        maxHealth = k * 100;
        currentHealth = maxHealth; 
        healthbar.setmaxHealth(maxHealth);
    
    }

    public void takeDmg(int dmg)
    {
        if (currentHealth > 0)
        {
            currentHealth -= dmg;
            healthbar.setHealth(currentHealth);
            AudioManager.Instance.Play("PlayerHit");

            if (!isWobbling)
            {
                StartCoroutine(WobbleEffect());
            }
        }
        else
        {
            AudioManager.Instance.Play("Over");
            playerDied();
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

    public void playerDied()
    {
        
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
        pDiedCanv.gameObject.SetActive(true);
        resetPosition();
    }

    public void killEnemy()
    {
        zombieNumber--;
        if(zombieNumber <= 0)
        {
            gameplayManager.RoundOver();
            int curLev = PlayerPrefs.GetInt("Level");
            int newlev = curLev + 1;
            PlayerPrefs.SetInt("Level", newlev);
            playerLevel= PlayerPrefs.GetInt("Level");
        }
    }
    public void resetPosition()
    {
        characterController.enabled = false;   
        transform.position = new Vector3(0, 0.1f, -3);
        currentHealth = maxHealth;
        healthbar.setHealth(currentHealth);
        characterController.enabled = true;
        PlayerPrefs.SetInt("started", 0);
    }



}
