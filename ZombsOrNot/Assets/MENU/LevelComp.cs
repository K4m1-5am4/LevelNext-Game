using UnityEngine;

public class LevelComp : MonoBehaviour
{
    public Canvas menuCanv;

    public void closeScreen()
    {
        menuCanv.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
