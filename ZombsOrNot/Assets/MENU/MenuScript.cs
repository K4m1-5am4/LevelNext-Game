using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject player;
    public TMP_Text levelText;
    public TMP_Text credsCount;
    public Canvas ShopCanv;
    public Canvas credsN;
    public GameplayManager gameManager;
    public PlayerInteraction playerInteraction;
    public MovementMain playerMovement;

    private void Start()
    {
        playerInteraction = player.GetComponent<PlayerInteraction>();
        playerMovement = player.GetComponent<MovementMain>();
    }

    private void OnEnable()
    {
        credsCount.text = PlayerPrefs.GetInt("Creds", 100).ToString();
    }
    private void Update()
    {
        levelText.text=player.GetComponent<PlayerInteraction>().playerLevel.ToString();
    }
    public void openShop()
    {
        AudioManager.Instance.Play("Menu");
        ShopCanv.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void startGame()
    {
        AudioManager.Instance.Play("Menu");
        playerMovement.checkandsetSpeed();
        gameManager.spawnZombs();
        playerInteraction.roundStart();
        gameObject.SetActive(false);
    }
    public void credsNeeded()
    {
        AudioManager.Instance.Play("Menu");
        credsN.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

}
