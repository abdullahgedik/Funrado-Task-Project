using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysUI : MonoBehaviour
{
    [Header("Referenes")]
    [SerializeField] private GameObject[] keyImages;

    private int imageIndex = 0;

    public void ActivateImage(string color)
    {
        keyImages[imageIndex].SetActive(true);

        switch(color)
        {
            case "Red":
                keyImages[imageIndex].GetComponent<Image>().color = Color.red;
                break;
            case "Blue":
                keyImages[imageIndex].GetComponent<Image>().color = Color.blue;
                break;
            case "Green":
                keyImages[imageIndex].GetComponent<Image>().color = Color.green;
                break;
        }

        imageIndex++;
    }

    public void DeactivateImage(string color)
    {
        foreach(var image in keyImages)
        {
            if (image.GetComponent<Image>().color == Color.red && color == "Red")
            {
                image.SetActive(false);
            }
            if (image.GetComponent<Image>().color == Color.blue && color == "Blue")
            {
                image.SetActive(false);
            }
            if (image.GetComponent<Image>().color == Color.green && color == "Green")
            {
                image.SetActive(false);
            }
        }
    }
}
