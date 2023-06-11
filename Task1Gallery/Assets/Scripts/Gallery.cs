using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gallery : MonoBehaviour
{
    [SerializeField] private string URL;
    [SerializeField] private int initializeOnStart = 6;

    private List<GalleryItem> imagesList;
    private Camera targetCamera;
    private int currentImage = 0;

    void Start()
    {
        imagesList = GetComponentsInChildren<GalleryItem>().ToList();
        targetCamera = Camera.main;


        for (int i = 0; i < initializeOnStart; i++)
        {
            if (!CanSetImage()) break;
            imagesList[currentImage].SetRemoteImage(URL + (currentImage+1).ToString() + ".jpg");
            currentImage++;
        }

        StartCoroutine(FollowImages());
    }

    private IEnumerator FollowImages()
    {
        while(currentImage < imagesList.Count)
        {
            if (CanSetImage())
            {
                imagesList[currentImage].SetRemoteImage(URL + (currentImage + 1).ToString() + ".jpg");
                currentImage++;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private bool CanSetImage()
    {
        return (currentImage < imagesList.Count && imagesList[currentImage].rectTransform.IsVisibleFrom(targetCamera));
    }
}
