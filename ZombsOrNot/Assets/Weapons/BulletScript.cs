using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speedBullet = 1f;
    public float timeToDestroy=5f;
    public int bulletDamage;

    private void Start()
    {
        StartCoroutine(destroy_self());
        bulletDamage = PlayerPrefs.GetInt("bulletDamage", 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            if (other.TryGetComponent<ZombieMain>(out ZombieMain zombscript))
            {
                zombscript.DealDamageZomb(bulletDamage);
                Destroy(gameObject);
            }
        }
        
    }
    void Update()
    {
        transform.Translate(0,0,speedBullet*Time.deltaTime);
    }

    IEnumerator destroy_self()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
