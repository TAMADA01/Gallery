using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageScroll : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private GameObject _content;
    
    private int _imageCount;
    private bool _isLoadingInProcess = false;

    private URLImage _urlImage => ProjectContext.Instance.URLImage;

    private void Awake()
    {
        ShowAllImages();
    }

    private void ShowAllImages()
    {
        foreach (var texture in _urlImage.Textures) 
        {
            CreateRawImage(texture);
        }
    }

    public void LoadingNewImage(Vector2 vector)
    {
        if (vector.y <= 0.3f && !_isLoadingInProcess)
        {
            StartCoroutine(LoadingNewImage());
        }
    }

    private IEnumerator LoadingNewImage()
    {
        _isLoadingInProcess = true;

        yield return StartCoroutine(_urlImage.LoadImagesCoroutin());

        foreach (var texture in _urlImage.UpdateImages(_imageCount))
        {
            CreateRawImage(texture);
        }

        _isLoadingInProcess = false;
    }

    private void CreateRawImage(Texture texture)
    {
        _image.texture = texture;
        Instantiate(_image, _content.transform.position, Quaternion.identity, _content.transform);
        _imageCount++;
    }
}
