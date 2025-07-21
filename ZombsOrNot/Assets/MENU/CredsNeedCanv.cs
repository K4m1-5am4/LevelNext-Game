using UnityEngine;

public class CredsNeedCanv : MonoBehaviour
{
    public Canvas Homescreen;

    public void closeCredNeeded()
    {
        AudioManager.Instance.Play("Menu");
        Homescreen.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void addCreds(int amt)
    {

    }
}
