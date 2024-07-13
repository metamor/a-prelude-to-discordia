using UnityEngine;

// Set the camera reference of a canvas to the main camera.
public class CanvasMainCamera : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Camera camera = GameManager.Instance.MainCamera;

            if (camera != null )
            {
                canvas.worldCamera = camera;
            }
        }
    }
}
