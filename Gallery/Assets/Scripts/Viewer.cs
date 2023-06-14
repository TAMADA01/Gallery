using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Viewer : MonoBehaviour
{
    [SerializeField] private RawImage _image;

    private void Awake()
    {
        _image.texture = ProjectContext.Instance.URLImage.ViewerTexture;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cancel();
        }
    }

    public void Cancel()
    {
        SceneManager.LoadScene(ProjectContext.Instance.ProjectConstant.GalleryScene);
    }
}
