using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]
public class LightSwitchItem : UsableItem
{
    [SerializeField] private List<Light2D> _lightList;

    void Start()
    {
        if (_lightList.Count == 0 || _lightList.Contains(null))
        {
            Debug.LogWarning(gameObject.name + " light list is empty or null!");
        }
    }

    // It requires a Collider
    private void OnMouseDown()
    {
        UseItem();
    }

    protected override void UseItem()
    {
        foreach (Light2D light in _lightList)
        {
            light.enabled = !light.enabled;
        }
    }
}
