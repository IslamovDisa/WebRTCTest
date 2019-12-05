using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CallAppUiDeviceCustomManager))]
public class CallAppUiDeviceCustomManagerEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var callAppUiDeviceCustomManager = (CallAppUiDeviceCustomManager) target;

        if (GUILayout.Button("Join"))
        {
            callAppUiDeviceCustomManager.Join("5810");
        }

        if (GUILayout.Button("Shutdown"))
        {
            callAppUiDeviceCustomManager.Shutdown();
        }
    }
}
