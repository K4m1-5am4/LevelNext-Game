using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public GameObject tankBullet;
    public int bulletDamage;
    public GameObject player;
    public float range = 1f;
    public Transform bulletSpawnPoint;

    public float fireRate = 1f;
    private float nextFireTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    

    private void Update()
    {
        shootPlayer();
    }

    public void shootPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        
        if (distance < range && Time.time >= nextFireTime)
        {
            Instantiate(tankBullet, bulletSpawnPoint.position, transform.rotation);
            nextFireTime = Time.time + fireRate; 
        }
    }
}
