using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public partial class TanukiUdonWindow : EditorWindow
{
    Vector2 scrollPos;
    void ShowCodeSnippets()
    {
        EditorGUILayout.Space(8f);
        EditorGUILayout.BeginVertical();

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        // Source the info for our Code SNippets
        string tsvString = TanukiCSV.DownloadCSVString("https://raw.githubusercontent.com/CS540-22/TanukiUdon540/main/rpdb.tsv");
        TCSV ourCSV = new TCSV(tsvString);
        

        int numItems = ourCSV.GetNumRows();
        Debug.Log("Num items: " + numItems);

        // Skip the first tiem since its useless info for the user
        for (int i = 1; i < numItems; i++)
        {
            TRow row = new TRow(ourCSV.lineAt(i));

            // Heading
            EditorGUILayout.LabelField(row.title, headingGUIStyle);

            // Description
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(10f);
            EditorGUILayout.LabelField(row.description, paragraphGUIStyle);

            GUILayout.FlexibleSpace();
        
            // Download Button
            if (GUILayout.Button(downloadBtnContent, downloadBtnStyle, GUILayout.Width(40), GUILayout.Height(40)))
            {
                Application.OpenURL(row.downloadLink);
            }

            // End the Horizontal
            EditorGUILayout.Space(10f);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(15f);
            foreach(var tag in row.tags)
            {
                //Debug.Log("Tag: " + tag);
            }
        }
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }

}