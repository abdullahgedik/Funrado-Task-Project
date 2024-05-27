using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float levelIncreaseAmount = 1f; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<LevelSystem>().IncreaseLevel(levelIncreaseAmount);

            Destroy(this.gameObject);
        }
    }
}
