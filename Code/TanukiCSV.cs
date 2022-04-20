using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.Networking;


public class TRow
{
    public List<string> row;
    public int id;
    public string title;
    public string description;
    public List<string> tags;
    public string image;
    public string informationLink;
    public string downloadLink;
    public string dateAdded;
    
    public TRow(List<string> row)
    {
        this.row = row;
        id = 0;
        int.TryParse(row[0],out this.id);
        title = row[1];
        description = row[2];
        tags = new List<string>(row[3].Split(','));
        image = row[4];
        informationLink = row[5];
        downloadLink = row[6];
        dateAdded = row[7];
    }
}
public class TCSV
{
    public string text = "";
    public List<string> rows = new List<string>();
    private int numRows = 0;

    //Split the CSV file into rows
    public List<string> SplitCSV(string csv)
    {
        string[] rows = csv.Split("\n"[0]);
        List<string> rowsList;
        rowsList = new List<string>(rows);
        this.numRows = rowsList.Count;
        return rowsList;
    }
    public List<string> SplitRow(string row)
    {
        //Seperate row into columns
        string[] columns = row.Split("\t"[0]);
        List<string> columnsList;
        columnsList = new List<string>(columns);
        //Debug.Log("Split row into " + columnsList.Count + " columns");
        return columnsList;
    }
    public List<string> lineAt(int index)
    {
        string row = this.rows[index];
        return SplitRow(row);
    }
    //Return the number of rows in the CSV file
    public int GetNumRows()
    {
        //Return the length of the string List rows
        return numRows;
    }
    
    //Constructor
    public TCSV(string text)
    {
        this.text = text;
        this.rows = this.SplitCSV(text);
        this.numRows = this.rows.Count;
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
    public static string DownloadCSVString(string url)
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
            //Debug.Log(www.downloadHandler.text);
            string newCSV =www.downloadHandler.text;
            return newCSV;
        }
        return null;
    }

}
