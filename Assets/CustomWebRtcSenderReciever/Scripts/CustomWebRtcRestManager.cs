using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CustomWebRtcRestManager : MonoBehaviour
{
    private delegate void CompleteDelegate(string value);
    private delegate void ErrorDelegate(string error);

    public void SimplePostRequest(string uri)
    {
        StartCoroutine(PostRequest(uri));
    }

    private static IEnumerator PostRequest(string uri, string data = "",
        CompleteDelegate completeDelegate = null, ErrorDelegate errorDelegateUri = null)
    {
        using (var www = UnityWebRequest.Post(uri, data))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                errorDelegateUri?.Invoke(www.error);
            }
            else
            {
                Debug.Log("Upload complete!");
                completeDelegate?.Invoke(uri);
            }
        }
    }
    
    public void SimpleDeleteRequest(string uri)
    {
        StartCoroutine(DeleteRequest(uri));
    }
    
    private static IEnumerator DeleteRequest(string uri, 
        CompleteDelegate completeDelegate = null, ErrorDelegate errorDelegateUri = null)
    {
        using (var www = UnityWebRequest.Delete(uri))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                errorDelegateUri?.Invoke(www.error);
            }
            else
            {
                Debug.Log("Upload complete!");
                completeDelegate?.Invoke(uri);
            }
        }
    }
}
