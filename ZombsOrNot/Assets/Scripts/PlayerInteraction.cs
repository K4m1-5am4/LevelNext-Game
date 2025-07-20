using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int playerLevel;
    public CharacterController characterController;


    private int zombieNumber;

    public HealthbarS healthbar;
    public GameplayManager gameplayManager;
    private void Start()
    {
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
        currentHealth -= dmg;   
        healthbar.setHealth(currentHealth);  
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
            currentHealth = maxHealth;
            healthbar.setHealth(currentHealth);
        }
    }
    public void resetPosition()
    {
        characterController.enabled = false;   
        transform.position = new Vector3(0, 0.1f, -3);
        characterController.enabled = true;
    }

}
