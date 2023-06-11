using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteContainer : MonoBehaviour
{
    public Sprite chosenSprite;

    public void SelectSprite(Sprite sprite)
    {
        chosenSprite = sprite;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RemoveObject()
    {
        Destroy(gameObject);
    }
}
