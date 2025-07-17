using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private int playerLevel;
    public GameObject player;
    public GameObject zombie1;
    public GameObject zombie2;  
    public GameObject zombie3;
    public GameObject zombie4;
    public Vector3[] spawnLoc;
    public PlayerInteraction playerInteraction;

    public int zombieNumber;
    private void Start()
    {
        playerLevel = player.GetComponent<PlayerInteraction>().playerLevel;
        playerInteraction = player.GetComponent<PlayerInteraction>();
    }

    public void RoundOver()
    {
        print("RoundOver");
    }

    //##################################################
    //##################################################
    
    public void spawnZombs()
    {
        zombieNumber = 0;
        for (int i = 0; i < 5; i++)
        {
            if (spawnLoc.Length > 0)
            {
                int randomIndex = Random.Range(0, spawnLoc.Length);

                Instantiate(zombie1, spawnLoc[randomIndex], Quaternion.identity);
                zombieNumber++;
            }
            else
            {
                Debug.LogWarning("spawnLoc array is empty!");
            }
        }
    }
}
