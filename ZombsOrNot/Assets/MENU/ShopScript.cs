using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject player;
    public Canvas MenuCanvas;
    

    public void closeShop()
    {
        MenuCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);    
    }
}
