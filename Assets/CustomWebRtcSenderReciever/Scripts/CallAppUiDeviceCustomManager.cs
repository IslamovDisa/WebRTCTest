using System.Collections;
using UnityEngine;

public class CallAppUiDeviceCustomManager : MonoBehaviour
{
    private CallAppUi _callAppUi;
    private CallApp _callApp;
    private CustomWebRtcRestManager _customWebRtcRestManager;
    
    [SerializeField] private string _uri = "web4ar.herokuapp.com/api/call?user_id=";

    private void Awake()
    {
        _callAppUi = FindObjectOfType<CallAppUi>();
        
        _callApp = FindObjectOfType<CallApp>();
        _callApp.OnMessage += CallAppOnMessage;
        
        _customWebRtcRestManager = FindObjectOfType<CustomWebRtcRestManager>();
    }
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        Join("5810");
    }
    public void Join(string roomName)
    {
        _callAppUi.uAudioToggle.isOn = true;
        _callAppUi.uVideoToggle.isOn = true;
        _callAppUi.uRoomNameInputField.text = roomName;
        
        _callAppUi.JoinButtonPressed();
        _callAppUi.Fullscreen();
        
        //_customWebRtcRestManager.SimplePostRequest(_uri + roomName);
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
