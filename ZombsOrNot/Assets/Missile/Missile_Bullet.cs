using System;
using UnityEngine;

public class Missile_Bullet : MonoBehaviour
{
    public float initialAscendSpeed = 2f; 
    public float chaseSpeed = 5f;         
    public float rotationSpeed = 2f;      
    public float ascendDuration = 0.5f;    

    private GameObject Zombie;
    private float launchTime;
    private bool isChasing = false;
    private Vector3 initialDirection;

    private void Start()
    {
        Zombie = GameObject.FindGameObjectWithTag("Zombie");
        launchTime = Time.time;
        initialDirection = transform.up; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);
            //Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        
        if (Time.time - launchTime < ascendDuration)
        {
            Ascend();
        }
        else
        {
            if (!isChasing)
            {
                isChasing = true;
                
            }
            ChasePlayer();
        }
    }

    private void Ascend()
    {
        
        transform.Translate(initialDirection * initialAscendSpeed * Time.deltaTime, Space.World);

       
        SmoothRotation();
    }

    private void ChasePlayer()
    {
        SmoothRotation();
        transform.Translate(Vector3.forward * chaseSpeed * Time.deltaTime);
    }

    private void SmoothRotation()
    {
        if (Zombie == null) return;

        Vector3 directionToPlayer = Zombie.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}