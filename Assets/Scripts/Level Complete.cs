using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("LevelCompleted", 1f);
        }
    }

    private void LevelCompleted()
    {
        gameManager.LevelCompleted();
    }


}
