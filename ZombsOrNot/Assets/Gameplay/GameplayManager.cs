using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Canvas levCompCanv;
    private int playerLevel;
    public GameObject player;
    public GameObject zombieBase;
    public GameObject zombieRapid;  
    public GameObject zombieSpeed;
    public GameObject zombieSpeedContact;
    public GameObject zombieMissile;
    public Vector3[] spawnLoc;
    public PlayerInteraction playerInteraction;

    public Canvas MobileControls;

    public int creds;

    public int zombieNumber;
    private void Start()
    {
        playerLevel = player.GetComponent<PlayerInteraction>().playerLevel;
        playerInteraction = player.GetComponent<PlayerInteraction>();
        creds = PlayerPrefs.GetInt("Creds", 100);
    }

    public void RoundOver()
    {
        AudioManager.Instance.Play("Win");
        levCompCanv.gameObject.SetActive(true);
        playerInteraction.resetPosition();
        MobileControls.gameObject.SetActive(false);
        
    }

    //##################################################
    //##################################################

    public void spawnZombs()
    {
        int P_level = PlayerPrefs.GetInt("Level", 1);
        zombieNumber = 0;

        if (P_level == 1)
        {
            spawnZomb(zombieBase);
        }
        if (P_level == 2)
        {
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
        }
        if (P_level == 3)
        {
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
        }
        if (P_level == 4)
        {
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
        }
        if (P_level == 5)
        {
            spawnZomb(zombieSpeed);
            spawnZomb(zombieSpeed);
        }
        if (P_level == 6)
        {
            spawnZomb(zombieSpeed);
            spawnZomb(zombieSpeed);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
        }
        if (P_level == 7)
        {
            spawnZomb(zombieSpeedContact);
        }
        if (P_level == 8)
        {
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
        }
        if (P_level == 9)
        {
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
        }
        if (P_level == 10)
        {
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieSpeed);
        }
        if (P_level == 11)
        {
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeed);
            spawnZomb(zombieSpeed);
        }
        if (P_level == 12)
        {
            spawnZomb(zombieRapid);
        }
        if (P_level == 13)
        {
            spawnZomb(zombieRapid);
            spawnZomb(zombieRapid);
        }
        if (P_level == 14)
        {
            spawnZomb(zombieRapid);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieSpeed);
        }
        if (P_level == 15)
        {
            spawnZomb(zombieMissile);
            spawnZomb(zombieBase);
            spawnZomb(zombieSpeed);
        }
        if (P_level == 16)
        {
            spawnZomb(zombieMissile);
            spawnZomb(zombieBase);
            spawnZomb(zombieMissile);
            spawnZomb(zombieBase);
        }
        if (P_level == 17)
        {
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
        }
        if (P_level == 18)
        {
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieBase);
            spawnZomb(zombieSpeed);
        }
        if (P_level == 19)
        {
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieMissile);
            spawnZomb(zombieMissile);
            spawnZomb(zombieSpeed);
        }
        if (P_level == 20)
        {
            spawnZomb(zombieRapid);
            spawnZomb(zombieRapid);
            spawnZomb(zombieRapid);
            spawnZomb(zombieRapid);

        }
        if(P_level >= 21)
        {
            spawnZomb(zombieRapid);
            spawnZomb(zombieMissile);
            spawnZomb(zombieBase);
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeed);
            spawnZomb(zombieRapid);
            spawnZomb(zombieMissile);
            spawnZomb(zombieBase);
            spawnZomb(zombieSpeedContact);
            spawnZomb(zombieSpeed);
        }



    }

    private void spawnZomb(GameObject zomb)
    {
        Instantiate(zomb, spawnLoc[Random.Range(0, spawnLoc.Length)], Quaternion.identity);
        zombieNumber++;
    }
}
