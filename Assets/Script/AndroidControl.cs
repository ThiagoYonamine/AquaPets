using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class AndroidControl : MonoBehaviour
{
    void OnApplicationPause(bool pauseStatus)
    {
        NotificationManager.CancelAll();
        if (pauseStatus)
        {
            //TODO TimeSpan.FromMinutes(120);
            NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(5), "Notification", "Notification with app icon", new Color(0, 0.6f, 1), NotificationIcon.Clock);
        }
    }
}
