using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryItem : MonoBehaviour
{
    public RectTransform rectTransform { get; private set; }
    private Image image;

    private bool isLoaded = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public async void SetRemoteImage(string fullURL)
    {
        Sprite sprite = await Loader.GetRemoteSprite(fullURL);
        image.sprite = sprite;
        isLoaded = true;
    }

    public void OpenImage()
    {
        if (!isLoaded) { return;  }
        FindObjectOfType<SpriteContainer>().SelectSprite(image.sprite);
    }
}
