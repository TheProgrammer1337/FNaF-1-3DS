using UnityEngine;

public class FPSLimiter : MonoBehaviour
{

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
}
