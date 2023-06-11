using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class Loader
{
    public static async Task<Sprite> GetRemoteSprite(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz

            // read results:
            if (www.isNetworkError || www.isHttpError)
            // if( www.result!=UnityWebRequest.Result.Success )// for Unity >= 2020.1
            {
                Debug.Log($"{www.error}, URL:{www.url}");
                // nothing to return on error:
                return null;
            }
            else
            {
                var content = DownloadHandlerTexture.GetContent(www);
                return SpriteFromTexture2D(content);
            }
        }
    }

    private static Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}
