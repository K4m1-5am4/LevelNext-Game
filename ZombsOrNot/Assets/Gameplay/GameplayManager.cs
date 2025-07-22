using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Canvas levCompCanv;
    private int playerLevel;
    public GameObject player;
    public GameObject zombieBase;
    public GameObject zombieHealth;  
    public GameObject zombieSpeed;
    public GameObject zombieBoss;
    public Vector3[] spawnLoc;
    public PlayerInteraction playerInteraction;

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
        
    }

    //##################################################
    //##################################################
    
    public void spawnZombs()
    {
        int P_level= PlayerPrefs.GetInt("Level");
        zombieNumber = 0;

        if (P_level == 1)
        {
            spawnZomb(zombieBase);
        }
        if (P_level == 2)
        {
            spawnZomb(zombieBase);
            spawnZomb(zombieHealth);
            spawnZomb(zombieSpeed);
            spawnZomb(zombieSpeed);
        }

    }

    private void spawnZomb(GameObject zomb)
    {
        Instantiate(zomb, spawnLoc[Random.Range(0, spawnLoc.Length)], Quaternion.identity);
        zombieNumber++;
    }
}
