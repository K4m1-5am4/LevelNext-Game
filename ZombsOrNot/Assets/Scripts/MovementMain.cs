using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementMain : MonoBehaviour
{
    public CharacterController characterController;
    public InputActionAsset InputActions;

    public float moveSpeed = 1f;     
    public float rotationSpeed = 10f;

    private InputAction m_moveAction;
    private InputAction m_shootAction;

    private Vector2 m_moveAmt;


    public GameObject bullet;
    public Transform bulletspawn;

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
    }

    private void Update()
    {
        m_moveAmt = m_moveAction.ReadValue<Vector2>();
        movePlayer();
        shootBullet();
    }

    private void shootBullet()
    {
        if (m_shootAction.WasPressedThisFrame())
        {
            Instantiate(bullet,bulletspawn.position,transform.rotation);
        }
    }

    private void movePlayer()
    {

        if (m_moveAmt.magnitude > 0.1f)
        {

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

    
}
