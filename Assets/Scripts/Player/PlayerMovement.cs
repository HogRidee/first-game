using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 5f;
    private Rigidbody2D m_rb;
    private Vector2 m_moveInput;
    private Animator m_animator;
    
    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        m_rb.linearVelocity = m_moveInput * m_moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        m_animator.SetBool("isWalking", true);
        if (context.canceled)
        {
            m_animator.SetBool("isWalking", false);
            m_animator.SetFloat("LastInputX", m_moveInput.x);
            m_animator.SetFloat("LastInputY", m_moveInput.y);
        }
        m_moveInput = context.ReadValue<Vector2>();
        m_animator.SetFloat("InputX", m_moveInput.x);
        m_animator.SetFloat("InputY", m_moveInput.y);
    }

}
