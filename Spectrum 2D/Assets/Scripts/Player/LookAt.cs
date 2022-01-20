using UnityEngine;

public class LookAt : MonoBehaviour
{
    void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }
}
