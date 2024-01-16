using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private List<Door> doors = new List<Door>();

    public void AddDoor(Door door)
    {
        doors.Add(door);
    }

    public void ActivateColor(ColorPick color)
    {
        BlockAll();
        foreach (Door door in doors)
        {
            if (door.GetColor() == color)
            {
                door.collider2d.enabled = false;
            }
        }
    }

    private void BlockAll()
    {
        foreach (Door door in doors)
        {
            door.collider2d.enabled = true;
        }
    }
}
