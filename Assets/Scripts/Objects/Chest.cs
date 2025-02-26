using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool IsOpen { get; private set; }
    public string ChestID { get; private set; }
    
    [SerializeField] 
    private GameObject m_itemToDrop;
    [SerializeField] 
    private Sprite m_openedSprite;
    
    void Start()
    {
        if (ChestID == null)
        {
            ChestID = GlobalHelper.GenerateUniqueID(gameObject);
        }
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        OpenChest();
    }

    public bool CanInteract()
    {
        return !IsOpen;
    }
    
    private void OpenChest()
    {
        SetOpened(true);
        if (m_itemToDrop != null)
        {
            GameObject droppedItem = Instantiate(m_itemToDrop, transform.position + Vector3.down, 
                Quaternion.identity);
        }
    }

    public void SetOpened(bool opened)
    {
        if (IsOpen == opened)
        {
            GetComponent<SpriteRenderer>().sprite = m_openedSprite;
        }
    }
}
