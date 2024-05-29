using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text levelUI;
    [SerializeField] private Animator animator;

    [Header("Settings")]
    [SerializeField] private float level = 1;

    public float GetLevel()
    {
        return level;
    }

    public TMP_Text GetLevelUI()
    {
        return levelUI;
    }

    public void IncreaseLevel(float amount)
    {
        level += amount;
        levelUI.text = "Lv." + level;
    }

    public void Die()
    {
        Invoke("SetDeathDelay", .6f);
    }

    private void SetDeathDelay()
    {
        levelUI.text = "";
        animator.applyRootMotion = false;
        animator.SetTrigger("Die");
        Destroy(gameObject.GetComponent<LevelSystem>());
        transform.position = new Vector3(transform.position.x, transform.position.y - .4f, transform.position.z);
    }
}
