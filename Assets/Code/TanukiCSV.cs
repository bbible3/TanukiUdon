using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.Networking;

public class TanukiCSV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DownloadCSV("https://sample-videos.com/csv/Sample-Spreadsheet-10-rows.csv");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void callback(string csv)
    {
 
    }

    // Download a file from a URL with UnityWebRequest
    public static void DownloadCSV(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();
        while (!www.isDone)
        {
            // Waiting for the download to complete
        }
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

}
