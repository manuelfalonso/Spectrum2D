using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]
public class LightSwitchItem : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light2D> _lightList;

    void Start()
    {
        if (_lightList.Count == 0)
        {
            Debug.LogWarning(gameObject.name + " light list is empty!");
        }
    }

    // It requires a Collider
    private void OnMouseDown()
    {
        foreach (Light2D light in _lightList)
        {
            light.enabled = !light.enabled;
        }
    }

    public void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
