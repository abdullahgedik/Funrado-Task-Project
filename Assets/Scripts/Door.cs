using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject closedCollider;
    [SerializeField] private string targetKeyColor = "Red";
    [SerializeField] private KeysUI keysUI;

    [Header("Settings")]
    [SerializeField] private bool isOpen = false;

    private void OpenDoor()
    {
        closedCollider.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isOpen)
        {
            if(other.GetComponent<InventorySystem>().GetKeys().Contains(targetKeyColor))
            {
                OpenDoor();
                keysUI.DeactivateImage(targetKeyColor);
            }
        }
    }
}
