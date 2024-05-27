using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Activate in UI
            door.GetComponent<Door>().OpenDoor();

            Destroy(this.gameObject);
        }
    }
}
