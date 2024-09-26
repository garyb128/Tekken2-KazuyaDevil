using UnityEngine;

public class PS1Renderer : MonoBehaviour
{
    public int targetResolutionX = 320; // Adjust the target resolution as desired
    public int targetResolutionY = 240;
    public int pixelsPerUnit = 1; // Determines the level of pixelation

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.orthographic = true;
        mainCamera.orthographicSize = targetResolutionY / (pixelsPerUnit * 2f);
    }

    private void Update()
    {
        if (Screen.width != targetResolutionX || Screen.height != targetResolutionY)
        {
            Screen.SetResolution(targetResolutionX, targetResolutionY, false);
        }
    }
}
