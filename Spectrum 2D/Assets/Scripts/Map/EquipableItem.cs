using UnityEngine;

public class EquipableItem : MonoBehaviour
{
    [SerializeField] protected string _name;

    public void TakeItem(Vector2 handPosition) 
    {
        //StartCoroutine("TransferItem");
        //Vector2.Lerp(transform.position, handPosition, Time.deltaTime);
        Debug.Log("Hello World");
    }

    public void DropItem(Vector2 handDirection)
    {

    }

    private void TransferItem()
    {
        //Vector2.Lerp(transform.position, handPosition, Time.deltaTime);
    }
}
