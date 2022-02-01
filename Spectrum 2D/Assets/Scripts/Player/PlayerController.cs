using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _handOffsetPosition;

    [SerializeField] private KeyCode _takeItemKey = KeyCode.E;
    //[SerializeField] private KeyCode _dropItemKey = KeyCode.G;

    private bool _takeItemPressed = false;

    void Update()
    {
        TryTakeItem();
    }

    private void FixedUpdate()
    {
        if (_takeItemPressed)
        {
            TakeItem();
        }
    }

    private void TryTakeItem()
    {
        if (Input.GetKeyDown(_takeItemKey))
        {
            _takeItemPressed = true;
        }
    }

    private void TakeItem()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        EquipableItem equipableScript = hit.transform.gameObject.GetComponentInChildren<EquipableItem>();

        if (equipableScript)
        {
            equipableScript.TakeItem(_handOffsetPosition.position);
        }

        _takeItemPressed = false;
    }
}
