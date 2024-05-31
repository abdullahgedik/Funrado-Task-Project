using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject retryPanel;
    [SerializeField] private GameObject completePanel;

    public void LevelCompleted()
    {
        //Activate LevelCompleteUI
        completePanel.SetActive(true);
    }

    public void PlayerDied()
    {
        //Activate Retry Screen
        retryPanel.SetActive(true);
    }

    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 4)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
