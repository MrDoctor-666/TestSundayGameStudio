using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FakeLevelLoader : MonoBehaviour
{
    [SerializeField] Slider slider;

    private float loadTime = 1f;

    private void Start()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        float progress = 0f;
        float increment = 0.01f;

        while (progress < loadTime)
        {
            progress += increment;
            slider.value = progress / loadTime;
            yield return new WaitForSeconds(increment);
        }
        
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
