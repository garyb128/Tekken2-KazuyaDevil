using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public int targetWidth = 640;
    public int targetHeight = 480;
    public bool maintainAspectRatio = true;

    private void Start()
    {
        SetResolution();
    }

    private void SetResolution()
    {
        if (maintainAspectRatio)
        {
            float targetAspect = (float)targetWidth / targetHeight;
            float currentAspect = (float)Screen.width / Screen.height;

            if (currentAspect > targetAspect)
            {
                int height = Mathf.RoundToInt(Screen.width / targetAspect);
                Screen.SetResolution(Screen.width, height, false);
                Debug.Log("Resolution set to " + Screen.width + "x" + height);
            }
            else
            {
                int width = Mathf.RoundToInt(Screen.height * targetAspect);
                Screen.SetResolution(width, Screen.height, false);
                Debug.Log("Resolution set to " + width + "x" + Screen.height);
            }
        }
        else
        {
            Screen.SetResolution(targetWidth, targetHeight, false);
            Debug.Log("Resolution set to " + targetWidth + "x" + targetHeight);
        }
    }
}
