using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int playerLevel = 1;

    private int zombieNumber;

    public HealthbarS healthbar;
    public GameplayManager gameplayManager;
    private void Start()
    {
        currentHealth = maxHealth;
        Application.targetFrameRate = 120;
        healthbar.setmaxHealth(maxHealth);
    }
    
    public void roundStart()
    {
        zombieNumber=gameplayManager.zombieNumber;
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
        }
    }

}
