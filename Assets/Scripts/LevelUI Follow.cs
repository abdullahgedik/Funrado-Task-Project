using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + 0.2f, 2.5f, player.position.z);
    }
}
