using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSystem : LevelSystem
{
    private void Start()
    {
        this.GetLevelUI().text = "Lv." + this.GetLevel();
    }
}
