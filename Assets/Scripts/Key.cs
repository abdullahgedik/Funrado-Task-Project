using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Header("Settigs")]
    [SerializeField] private string keyColor = "Red";
    [SerializeField] private KeysUI keysUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            keysUI.ActivateImage(keyColor);
            other.GetComponent<InventorySystem>().AddKey(keyColor);

            Destroy(this.gameObject);
        }
    }
}
