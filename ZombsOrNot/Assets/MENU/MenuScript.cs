using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject player;
    public TMP_Text levelText;
    public Canvas ShopCanv;
    public GameplayManager gameManager;
    public PlayerInteraction playerInteraction;

    private void Start()
    {
        playerInteraction = player.GetComponent<PlayerInteraction>();
    }
    private void Update()
    {
        levelText.text=player.GetComponent<PlayerInteraction>().playerLevel.ToString();
    }
    public void openShop()
    {
        ShopCanv.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void startGame()
    {
        gameManager.spawnZombs();
        playerInteraction.roundStart();
        gameObject.SetActive(false);
    }
}
