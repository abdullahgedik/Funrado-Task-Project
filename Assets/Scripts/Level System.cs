using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text levelUI;

    [Header("Settings")]
    [SerializeField] private float level = 1;

    private void Start()
    {
        levelUI.text = "Lv." + level;
    }

    public float GetLevel()
    {
        return level;
    }

    public void IncreaseLevel(float amount)
    {
        level += amount;
        levelUI.text = "Lv." + level;
    }

    public void Die()
    {
        Destroy(gameObject, 1);
        Destroy(levelUI.gameObject, 1);
    }
}
