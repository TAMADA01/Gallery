using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public ProjectConstant ProjectConstant { get; private set; }
    public URLImage URLImage { get; private set; }
    public static ProjectContext Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Instance.Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {
        ProjectConstant = new ProjectConstant();
        URLImage = gameObject.AddComponent<URLImage>();
    }
}
