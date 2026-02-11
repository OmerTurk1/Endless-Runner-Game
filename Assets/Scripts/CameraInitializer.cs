using Unity.VisualScripting;
using UnityEngine;

public class CameraInitializer : MonoBehaviour
{
    private void Start()
    {
        if(PermanentInfo.GameMode == "Third Person")
        {
            Camera.main.AddComponent<CameraManager>();
        }
    }
}
