using System;
using System.Collections;
using UnityEngine;

public class CallAppUiDeviceCustomManager : MonoBehaviour
{
    private CallAppUi _callAppUi;
    private CallApp _callApp;
    private CustomWebRtcRestManager _customWebRtcRestManager;
    
    [SerializeField] private string _uri = "web4ar.herokuapp.com/api/call?user_id=";

    private TargetHighlight _targetHighlight;
    [SerializeField] private RectTransform _localVideoImage;
    
    private void Awake()
    {
        _callAppUi = FindObjectOfType<CallAppUi>();
        
        _callApp = FindObjectOfType<CallApp>();
        _callAppUi.OnMessage += CallAppOnMessage;
        
        _customWebRtcRestManager = FindObjectOfType<CustomWebRtcRestManager>();
        _targetHighlight = FindObjectOfType<TargetHighlight>();
    }
    
    public void Join(string roomName)
    {
        _callAppUi.uAudioToggle.isOn = true;
        _callAppUi.uVideoToggle.isOn = true;
        _callAppUi.uRoomNameInputField.text = roomName;
        
        _callAppUi.JoinButtonPressed();
        _callAppUi.Fullscreen();
        
        _customWebRtcRestManager.SimplePostRequest(_uri + roomName);
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
        if (!message.Contains("(") || !message.Contains(",") || !message.Contains(")"))
        {
            return;
        }
        
        message = message.Trim('(', ')');
        var res = message.Split(',');

        res[0] = res[0].Replace('.', ',');
        res[1] = res[1].Replace('.', ',');
        var result = new Vector2(float.Parse(res[0].Trim()), float.Parse(res[1].Trim()));
        Debug.Log(result);
        _targetHighlight.SetTarget(result, _localVideoImage.rect);
    }
}
