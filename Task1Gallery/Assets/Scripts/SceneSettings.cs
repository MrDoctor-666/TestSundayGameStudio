using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    [SerializeField] private ScreenOrientation orientation = ScreenOrientation.Portrait;

    [Header("Native Buttons Usage")]
    [SerializeField] private bool useButtonToGoToScene;
    [SerializeField] private int loadScene = 1;
    [SerializeField] private LevelLoader levelLoader;

    void Start()
    {
        Screen.orientation = orientation;
    }


    void Update()
    {
        if (!useButtonToGoToScene) return;
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                levelLoader.LoadLevel(loadScene);
            }
        }
    }
}
