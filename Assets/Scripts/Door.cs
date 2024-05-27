using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject closedCollider;

    public void OpenDoor()
    {
        closedCollider.SetActive(false);
    }
}
