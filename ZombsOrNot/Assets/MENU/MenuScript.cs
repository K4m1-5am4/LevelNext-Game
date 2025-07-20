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
    public MovementMain playerMovement;

    private void Start()
    {
        playerInteraction = player.GetComponent<PlayerInteraction>();
        playerMovement = player.GetComponent<MovementMain>();
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
        playerMovement.checkandsetSpeed();
        gameManager.spawnZombs();
        playerInteraction.roundStart();
        gameObject.SetActive(false);
    }

}
