using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallAppUiWebReciever : MonoBehaviour
{
    [SerializeField] private CallAppUi _callAppUi;
    [SerializeField] private CallApp _callApp;
    
    private string _roomName;
    
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

        //Join();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        _callAppUi.uRoomNameInputField.text = _roomName;
        _callAppUi.uRoomNameInputField.ForceLabelUpdate();
    }

    public void Join()
    {
        _callAppUi.uAudioToggle.isOn = true;
        _callAppUi.uVideoToggle.isOn = true;
        _callAppUi.uRoomNameInputField.text = _roomName;
        
        _callAppUi.JoinButtonPressed();
        _callAppUi.Fullscreen();
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
