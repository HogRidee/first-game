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
            if (!_interactableInRange.CanInteract())
            {
                m_interactionIcon.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out IInteractable interactable) || !interactable.CanInteract()) return;
        _interactableInRange = interactable;
        m_interactionIcon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out IInteractable interactable) || interactable != _interactableInRange) return;
        _interactableInRange = null;
        m_interactionIcon.SetActive(false);
    }
}