using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CallAppUiWebReciever))]
public class CallAppUiWebRecieverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var callAppUiWebReciever = (CallAppUiWebReciever) target;

        if (GUILayout.Button("Join"))
        {
            callAppUiWebReciever.Join();
        }
    }
}
