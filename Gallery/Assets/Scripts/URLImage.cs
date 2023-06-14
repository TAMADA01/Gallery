using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class URLImage : MonoBehaviour
{
    private const int IMAGE_COUNT = 66;
    private const string URL = "http://data.ikppbb.com/test-task-unity-data/pics/";

    public Texture ViewerTexture;

    private readonly int r_numberUploadedImages = 10;

    private List<Texture> _textures = new();

    public List<Texture> Textures => _textures;
    public IEnumerator LoadImagesCoroutin()
    {
        if (_textures.Count < IMAGE_COUNT)
        {
            int numberUploadedImages = IMAGE_COUNT - _textures.Count < r_numberUploadedImages ? IMAGE_COUNT - _textures.Count : r_numberUploadedImages;

            for (int i = 0; i < numberUploadedImages; i++)
            {
                yield return StartCoroutine(LoadImage(_textures.Count+1));
            }
        }
    }

    private IEnumerator LoadImage(int name)
    {
        var url = URL + name + ".jpg";
        var request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            _textures.Add(DownloadHandlerTexture.GetContent(request));
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
        }

        request.Dispose();
    }

    public List<Texture> UpdateImages(int index)
    {
        var textures = new List<Texture>();
        for (int i = index; i < _textures.Count; i++)
        {
            textures.Add(_textures[i]);
        }
        return textures;
    }
}
