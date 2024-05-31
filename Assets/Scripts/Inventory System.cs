using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<string> keys = new List<string>();

    public void AddKey(string key)
    {
        keys.Add(key);
    }

    public List<string> GetKeys()
    {
        return keys;
    }
}
