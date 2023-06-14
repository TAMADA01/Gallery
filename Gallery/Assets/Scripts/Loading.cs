using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Text _progressText;

    private ProjectConstant _projectConstant => ProjectContext.Instance.ProjectConstant;

    private void Start()
    {
        _progressBar.value = 0;
        _progressText.text = $"{0:p1}";
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation loadNextScene = SceneManager.LoadSceneAsync(_projectConstant.LoadScene);
        loadNextScene.allowSceneActivation = false;

        while (!loadNextScene.isDone) 
        {
            _progressBar.value = Mathf.Clamp01(loadNextScene.progress/0.9f);
            _progressText.text = $"{_progressBar.value:p1}";
            if (loadNextScene.progress >= 0.9f)
            {
                break;
            }
        }

        yield return StartCoroutine(ProjectContext.Instance.URLImage.LoadImagesCoroutin());

        _progressBar.value = Mathf.Clamp01(loadNextScene.progress / 0.9f);
        _progressText.text = $"{_progressBar.value:p1}";

        yield return new WaitForSeconds(0.2f);

        loadNextScene.allowSceneActivation = true;
    }
}
