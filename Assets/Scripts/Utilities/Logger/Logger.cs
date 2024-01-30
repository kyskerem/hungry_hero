using UnityEngine;
using UnityEditor;

public class Logger : MonoBehaviour
{
    // Set this flag to true to enable logging, and false to disable it
    public static bool IsLoggingEnabled = true;

    public static void Log(string message)
    {
        if (IsLoggingEnabled)
        {
            Debug.Log(message);
        }
    }

    public static void LogWarning(string message)
    {
        if (IsLoggingEnabled)
        {
            Debug.LogWarning(message);
        }
    }

    public static void LogError(string message)
    {
        if (IsLoggingEnabled)
        {
            Debug.LogError(message);
        }
    }

    [MenuItem("HH/Logger/Toggle Logging")]
    private static void ToggleLogging()
    {
        IsLoggingEnabled = !IsLoggingEnabled;
        Debug.Log("Logging " + (IsLoggingEnabled ? "enabled" : "disabled"));
    }

}
