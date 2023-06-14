using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private ProjectConstant _constant => ProjectContext.Instance.ProjectConstant;
    public void LoadGallery()
    {
        _constant.LoadScene = _constant.GalleryScene;
        SceneManager.LoadScene(_constant.LoadingScene);
    }
}
