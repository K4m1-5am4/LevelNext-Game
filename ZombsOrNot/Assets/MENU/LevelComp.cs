using UnityEngine;

public class LevelComp : MonoBehaviour
{
    public Canvas menuCanv;
    public Canvas ShopCanv;

    public void closeScreen()
    {
        AudioManager.Instance.Play("Menu");
        menuCanv.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void openShop()
    {
        AudioManager.Instance.Play("Menu");
        ShopCanv.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
