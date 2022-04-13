using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.Networking;

public class TCSV
{
    public string text;
    public string[] rows;

    //Split the CSV file into rows
    public string[] SplitCSV(string csv)
    {
        string[] rows = csv.Split("\n"[0]);
        return rows;
    }

    //Return the number of rows in the CSV file
    public int GetNumRows()
    {
        return rows.Length;
    }
    
    //Constructor
    public TCSV(string text)
    {
        this.text = text;
        this.SplitCSV(text);
    }

}
public class TanukiCSV : MonoBehaviour
{
    public string csvtext = "";
    
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
    public static TCSV DownloadCSV(string url)
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
            TCSV newCSV = new TCSV(www.downloadHandler.text);
            return newCSV;
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
        return null;
    }

}
