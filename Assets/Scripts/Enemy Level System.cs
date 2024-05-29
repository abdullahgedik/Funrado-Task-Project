using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelSystem : LevelSystem
{
    [Header("References")]
    [SerializeField] private PlayerLevelSystem pLS;
    [SerializeField] private GameObject eFOV;

    private void Start()
    {
        this.GetLevelUI().text = "Lv." + this.GetLevel();
    }

    private void Update()
    {
        if (pLS.GetLevel() < this.GetLevel() && this.GetLevelUI().color != Color.red)
        {
            this.GetLevelUI().color = Color.red;
        }
        if (pLS.GetLevel() > this.GetLevel() && this.GetLevelUI().color != Color.green)
        {
            this.GetLevelUI().color = Color.green;
        }
        if (pLS.GetLevel() == this.GetLevel() && this.GetLevelUI().color != Color.white)
        {
            this.GetLevelUI().color = Color.white;
        }
    }

    public GameObject GetEnemyFieldOfView()
    {
        return eFOV;
    }
}
