using UnityEngine;

public class ReviveCanv : MonoBehaviour
{

    public PlayerInteraction pInteract;
    public void closeRev()
    {
        gameObject.SetActive(false);
        pInteract.playerDied();
    }
}
