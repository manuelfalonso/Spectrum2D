using UnityEngine;

public class ICollisionable : MonoBehaviour
{
    void Start()
    {
        Collider2D col2D = GetComponent<Collider2D>();

        if (!col2D)
        {
            Debug.LogError("The item " + gameObject.name + " is missing a Collider2D");
        }
    }
}
