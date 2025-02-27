using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    [SerializeField]
    private GameObject m_interactionIcon;
    
    private IInteractable _interactableInRange = null;
    
    void Start()
    {
        m_interactionIcon.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && _interactableInRange != null)
        {
            _interactableInRange.Interact();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Returns if the object isn't interactable
        if (!collision.TryGetComponent(out IInteractable interactable) || !interactable.CanInteract()) return;
        _interactableInRange = interactable;
        m_interactionIcon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Returns if the object isn't the interactable in range
        if (!collision.TryGetComponent(out IInteractable interactable) || interactable != _interactableInRange) return;
        _interactableInRange = null;
        m_interactionIcon.SetActive(false);
    }
}
