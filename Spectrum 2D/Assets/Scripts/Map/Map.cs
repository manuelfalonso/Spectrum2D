using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private string _name;
    [Multiline]
    [SerializeField] private string _description;
    [SerializeField] private List<Room> _rooms = new List<Room>();
    [SerializeField] private int _roomsQuantity;

    private void Start()
    {
        _roomsQuantity = _rooms.Count;
    }
}
