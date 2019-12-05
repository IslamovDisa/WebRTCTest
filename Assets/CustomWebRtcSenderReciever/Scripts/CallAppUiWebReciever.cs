using System;
using System.Collections;
using UnityEngine;

public class CallAppUiWebReciever : MonoBehaviour
{
    private CallAppUi _callAppUi;
    private CallApp _callApp;
    private CustomWebRtcRestManager _customWebRtcRestManager;
    
    private string _roomName;

    [SerializeField] private string _uri = "web4ar.herokuapp.com/api/call?user_id=";
    
    private void Awake()
    {
        _callAppUi = FindObjectOfType<CallAppUi>();
        
        _callApp = FindObjectOfType<CallApp>();
        _callApp.OnWaitForIncomingCall += CallAppOnWaitForIncomingCall;
        
        var pm = Application.absoluteURL.IndexOf("?", StringComparison.Ordinal);
        
        if (pm != -1)
        {
            _roomName = Application.absoluteURL.Split("?"[0])[1];
        }

        _customWebRtcRestManager = FindObjectOfType<CustomWebRtcRestManager>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        _callAppUi.uRoomNameInputField.text = _roomName;
        _callAppUi.uRoomNameInputField.ForceLabelUpdate();
        
        Join();
    }

    public void Join()
    {
        _callAppUi.uAudioToggle.isOn = true;
        _callAppUi.uVideoToggle.isOn = true;
        _callAppUi.uRoomNameInputField.text = _roomName;
        
        _callAppUi.JoinButtonPressed();
        _callAppUi.Fullscreen();
        
        //_customWebRtcRestManager.SimpleDeleteRequest(_uri + _roomName);
    }
    
    private void CallAppOnWaitForIncomingCall()
    {
        Debug.Log("CallAppOnWaitForIncomingCall");
        // Here send post message
    }
    
    // Send mouse data
    public void SendMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return;
        }
    
        _callApp.Send(message);
    }
}
