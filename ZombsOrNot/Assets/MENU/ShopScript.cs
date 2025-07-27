using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject player;
    public Canvas MenuCanvas;
    public Canvas credsN;
    public TMP_Text credsCount;
    public TMP_Text HLevel;
    public TMP_Text ALevel;
    public TMP_Text SLevel;

    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            PlayerPrefs.SetInt("Creds",0);
            PlayerPrefs.SetInt("H_Lvl", 1);
            PlayerPrefs.SetInt("S_Lvl", 1);
            PlayerPrefs.SetInt("A_Lvl", 1);
            credsCount.text = PlayerPrefs.GetInt("Creds", 0).ToString();
            HLevel.text = PlayerPrefs.GetInt("H_Lvl", 1).ToString();
            ALevel.text = PlayerPrefs.GetInt("A_Lvl", 1).ToString();
            SLevel.text = PlayerPrefs.GetInt("S_Lvl", 1).ToString();

        }
    }
    private void OnEnable()
    {
        credsCount.text = PlayerPrefs.GetInt("Creds", 100).ToString();
        HLevel.text= PlayerPrefs.GetInt("H_Lvl", 1).ToString();
        ALevel.text = PlayerPrefs.GetInt("A_Lvl", 1).ToString();
        SLevel.text = PlayerPrefs.GetInt("S_Lvl", 1).ToString();
    }
    public void closeShop()
    {
        AudioManager.Instance.Play("Menu");
        MenuCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);    
    }

    public void upgradeHealth(int cost)
    {
        if (PlayerPrefs.GetInt("Creds") >= cost && PlayerPrefs.GetInt("H_Lvl")<5)
        {
            AudioManager.Instance.Play("Menu");
            int c = PlayerPrefs.GetInt("Creds");
            PlayerPrefs.SetInt("Creds", c - cost);
            credsCount.text = PlayerPrefs.GetInt("Creds", 100).ToString();
            int k = PlayerPrefs.GetInt("H_Lvl", 1);
            PlayerPrefs.SetInt("H_Lvl", k + 1);
            HLevel.text = PlayerPrefs.GetInt("H_Lvl", 1).ToString();
        }
        else
        {
            if(PlayerPrefs.GetInt("H_Lvl") < 5)
            {
                credsNeeded();
            }
            
        }
        
    } 

    public void upgradeAttack(int cost)
    {
        if (PlayerPrefs.GetInt("Creds") >= cost && PlayerPrefs.GetInt("A_Lvl") < 5)
        {
            AudioManager.Instance.Play("Menu");
            int c = PlayerPrefs.GetInt("Creds");
            PlayerPrefs.SetInt("Creds", c - cost);
            credsCount.text = PlayerPrefs.GetInt("Creds", 100).ToString();
            int k = PlayerPrefs.GetInt("A_Lvl", 1);
            PlayerPrefs.SetInt("A_Lvl", k + 1);
            ALevel.text = PlayerPrefs.GetInt("A_Lvl", 1).ToString();
        }
        else
        {
            if (PlayerPrefs.GetInt("H_Lvl") < 5)
            {
                credsNeeded();
            }
        }

    }
    public void upgradeSpeed(int cost)
    {
        if (PlayerPrefs.GetInt("Creds") >= cost && PlayerPrefs.GetInt("S_Lvl") < 5)
        {
            AudioManager.Instance.Play("Menu");
            int c = PlayerPrefs.GetInt("Creds");
            PlayerPrefs.SetInt("Creds", c - cost);
            credsCount.text = PlayerPrefs.GetInt("Creds", 100).ToString();
            int k = PlayerPrefs.GetInt("S_Lvl", 1);
            PlayerPrefs.SetInt("S_Lvl", k + 1);
            SLevel.text = PlayerPrefs.GetInt("S_Lvl", 1).ToString();
        }
        else
        {
            if (PlayerPrefs.GetInt("H_Lvl") < 5)
            {
                credsNeeded();
            }
        }
    }
    public void credsNeeded()
    {
        AudioManager.Instance.Play("Menu");
        credsN.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
