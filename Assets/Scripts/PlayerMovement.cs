using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 5f;
    private Rigidbody2D m_rb;
    private Vector2 m_moveInput;
    
    public void Move(InputAction.CallbackContext context)
    {
        m_moveInput = context.ReadValue<Vector2>();
    }
    
    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_rb.linearVelocity = m_moveInput * m_moveSpeed;
    }
}
