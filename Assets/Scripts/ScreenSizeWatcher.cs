using UnityEngine;
using UnityEngine.Events;

public class ScreenSizeWatcher : MonoBehaviour
{
    public static event UnityAction OnScreenSizeChanged;

    private Vector2 _lastScreenSize;

    private void Awake()
    {
        _lastScreenSize = new Vector2(Screen.width, Screen.height);
    }

    private void Update()
    {
        Vector2 currentScreenSize = new Vector2(Screen.width, Screen.height);
        if (_lastScreenSize != currentScreenSize)
        {
            OnScreenSizeChanged?.Invoke();
            _lastScreenSize = currentScreenSize;
        }
    }
}
