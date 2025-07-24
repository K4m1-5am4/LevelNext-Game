using UnityEngine;
using System.Collections;

public class TankBullet : MonoBehaviour
{
    public float speedBullet = 1f;
    public float timeToDestroy = 5f;
    public int bulletDamage = 10;

    private void Start()
    {
        StartCoroutine(destroy_self());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.TryGetComponent<PlayerInteraction>(out PlayerInteraction pInteraction))
            {
                pInteraction.takeDmg(bulletDamage);
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        transform.Translate(0, 0, speedBullet * Time.deltaTime);
    }

    IEnumerator destroy_self()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
