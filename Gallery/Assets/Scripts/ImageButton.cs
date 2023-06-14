using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(RawImage))]
public class ImageButton : MonoBehaviour
{
    private RawImage _image;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }

    public void OpenViewer()
    {
        ProjectContext.Instance.URLImage.ViewerTexture = _image.texture;
        SceneManager.LoadScene(ProjectContext.Instance.ProjectConstant.ViewerScene);
    }
}
