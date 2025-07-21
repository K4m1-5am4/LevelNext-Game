using UnityEngine;

public class LevelComp : MonoBehaviour
{
    public Canvas menuCanv;
    public Canvas ShopCanv;

    public void closeScreen()
    {
        menuCanv.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void openShop()
    {
        ShopCanv.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
