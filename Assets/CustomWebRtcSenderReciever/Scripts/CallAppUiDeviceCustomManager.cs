using UnityEngine;

public class CallAppUiDeviceCustomManager : MonoBehaviour
{
    [SerializeField] private CallAppUi _callAppUi;
    [SerializeField] private CallApp _callApp;
    
    private void Awake()
    {
        _callAppUi = FindObjectOfType<CallAppUi>();
        
        _callApp = FindObjectOfType<CallApp>();
        _callApp.OnMessage += CallAppOnMessage;
    }
    
    public void Join(string roomName)
    {
        _callAppUi.uAudioToggle.isOn = true;
        _callAppUi.uVideoToggle.isOn = true;
        _callAppUi.uRoomNameInputField.text = roomName;
        
        _callAppUi.JoinButtonPressed();
        // _callAppUi.Fullscreen();
    }
    
    public void Shutdown()
    {
        _callAppUi.ShutdownButtonPressed();
        _callAppUi.Fullscreen();
    }
    
    // Get mouse data
    private void CallAppOnMessage(string message)
    {
        Debug.LogFormat("msg receive {0}",  message);
    }
}
