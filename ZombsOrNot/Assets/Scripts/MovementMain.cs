using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementMain : MonoBehaviour
{
    public GameObject tank_upper;

    public CharacterController characterController;
    public InputActionAsset InputActions;

    public float moveSpeed;     
    public float rotationSpeed = 10f;

    private InputAction m_moveAction;
    private InputAction m_shootAction;
    private InputAction m_lookAction;

    

    private Vector2 m_moveAmt;
    private Vector2 m_lookAmt;


    public GameObject bullet;
    public Transform bulletspawn;

    [SerializeField] private float fireRate = 0.5f; // Time between shots (adjust as needed)
    private float nextFireTime = 0f; // Tracks when next shot can occur


    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_shootAction = InputSystem.actions.FindAction("Shoot");
        m_lookAction = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {
        m_moveAmt = m_moveAction.ReadValue<Vector2>();
        m_lookAmt = m_lookAction.ReadValue<Vector2>();  
        movePlayer();
        // If fire button held down and enough time has passed
        if (Time.time >= nextFireTime&& PlayerPrefs.GetInt("started")==1)
        {
            ShootBullet();
            nextFireTime = Time.time + fireRate; // Set next allowed shot time
        }
        lookPlayer();
    }

    private void ShootBullet() // Renamed to follow C# conventions
    {
        // 1. Get the tank's current rotation
        Quaternion tankRotation = tank_upper.transform.rotation;

        // 2. Define a corrected forward direction
        Quaternion rotationCorrection = Quaternion.Euler(0, -90, 0);

        // 3. Combine rotations
        Quaternion bulletRotation = tankRotation * rotationCorrection;

        // 4. Spawn the bullet
        Instantiate(bullet, bulletspawn.position, bulletRotation);
    }

    private void movePlayer()
    {

        if (m_moveAmt.magnitude > 0.1f)
        {
            checkandsetSpeed();
            Vector3 moveDirection = new Vector3(m_moveAmt.x, 0, m_moveAmt.y).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            characterController.SimpleMove(moveDirection * moveSpeed);
        }
        else
        {
            characterController.SimpleMove(new Vector3(0, 0, 0));
        }
    }

    private void lookPlayer()
    {
        if (m_lookAmt.magnitude > 0.1f)
        {
            Vector3 lookDirection = new Vector3(m_lookAmt.x, 0, m_lookAmt.y).normalized;

            // Calculate the angle (Y-axis only)
            float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;

            // Apply the base rotation (-90,0,90) but only modify Y-axis
            Quaternion targetRotation = Quaternion.Euler(-90f, targetAngle, 90f);

            // Smooth rotation
            tank_upper.transform.rotation = Quaternion.Slerp(
                tank_upper.transform.rotation,
                targetRotation,
                Time.deltaTime * rotationSpeed
            );
        }
    }

    public void checkandsetSpeed()
    {
        int k = PlayerPrefs.GetInt("S_Lvl", 1);
        if (k == 1)
        {
            moveSpeed = 3;
        }
        if (k == 2)
        {
            moveSpeed = 5;
        }
        if (k == 3)
        {
            moveSpeed = 7;
        }
        if (k == 4)
        {
            moveSpeed = 9;
        }
        if (k == 5)
        {
            moveSpeed = 10;
        }
    }


}
