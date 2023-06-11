using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullImage : MonoBehaviour
{
    private void OnEnable()
    {
        var container = FindObjectOfType<SpriteContainer>();
        GetComponent<Image>().sprite = container.chosenSprite;
        container.RemoveObject();

    }
}
