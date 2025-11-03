using UnityEngine;

public class SetScreenSize : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Screen.SetResolution(640, 480, true);
        }
    }
}
