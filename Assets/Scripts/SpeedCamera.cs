using UnityEngine;

public class CameraFOVController : MonoBehaviour
{
    public Transform car;
    public float normalFOV = 60f;
    public float maxFOV = 70f; 
    public float speedThreshold = 100f; 
    public float fovChangeSpeed = 10f; 

    private Camera mainCamera;
    private float targetFOV;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        if (car == null)
        {
            Debug.LogError("Player car reference not set in CameraFOVController script!");
        }
        mainCamera.fieldOfView = normalFOV;
        targetFOV = normalFOV;
    }

    void Update()
    {
        if (car != null)
        {
            float carSpeed = car.GetComponent<Rigidbody>().velocity.magnitude;
            float desiredFOV = carSpeed >= speedThreshold ? maxFOV : normalFOV;
            targetFOV = Mathf.Lerp(targetFOV, desiredFOV, Time.deltaTime * fovChangeSpeed);
            mainCamera.fieldOfView = targetFOV;
        }
    }
}
