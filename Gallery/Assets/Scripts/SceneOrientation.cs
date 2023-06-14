using UnityEngine;

[ExecuteAlways]
public class SceneOrientation : MonoBehaviour
{
    [SerializeField] private OrientationType _orientationType;

    private void Start()
    {
        switch (_orientationType)
        {
            case OrientationType.Any:
                Screen.orientation = ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                break;
            case OrientationType.Portrait:
                Screen.orientation = ScreenOrientation.Portrait;
                Screen.orientation = ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = false;
                Screen.autorotateToLandscapeRight = false;
                break;
            case OrientationType.Landscape:
                Screen.orientation = ScreenOrientation.LandscapeLeft;

                Screen.autorotateToPortrait = false;
                Screen.autorotateToPortraitUpsideDown = false;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                break;
        }
    }
    public enum OrientationType
    {
        Any,
        Portrait,
        Landscape
    }
}
