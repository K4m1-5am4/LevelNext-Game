using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject player;
    public Canvas MenuCanvas;

    public TMP_Text credsCount;
    public TMP_Text HLevel;

    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            PlayerPrefs.SetInt("Creds",100);
            PlayerPrefs.SetInt("H_Lvl", 1);
            credsCount.text = PlayerPrefs.GetInt("Creds", 100).ToString();
            HLevel.text = PlayerPrefs.GetInt("H_Lvl", 1).ToString();

        }
    }
    private void OnEnable()
    {
        credsCount.text = PlayerPrefs.GetInt("Creds", 100).ToString();
        HLevel.text= PlayerPrefs.GetInt("H_Lvl", 1).ToString();
    }
    public void closeShop()
    {
        MenuCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);    
    }

    public void upgradeHealth(int cost)
    {
        if (PlayerPrefs.GetInt("Creds") >= cost && PlayerPrefs.GetInt("H_Lvl")<10)
        {
            int c = PlayerPrefs.GetInt("Creds");
            PlayerPrefs.SetInt("Creds", c - cost);
            credsCount.text = PlayerPrefs.GetInt("Creds", 100).ToString();
            int k = PlayerPrefs.GetInt("H_Lvl", 1);
            PlayerPrefs.SetInt("H_Lvl", k + 1);
            HLevel.text = PlayerPrefs.GetInt("H_Lvl", 1).ToString();
        }
        else
        {
            print("NOT ENOUGH CREDS::");
        }
        
    }   
}
