using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;

public partial class TanukiUdonWindow : EditorWindow
{
    Vector2 docScrollPos;
    void ShowDocumentation()
    {
        EditorGUILayout.Space(8f);
        EditorGUILayout.BeginVertical();

        docScrollPos = EditorGUILayout.BeginScrollView(docScrollPos);

        // Source the info for our Code SNippets
        string tsvString = TanukiCSV.DownloadCSVString("https://raw.githubusercontent.com/CS540-22/TanukiUdon540/main/Doc_Snippets.tsv");
        TCSV docTSV = new TCSV(tsvString);
        

        int numItems = docTSV.GetNumRows();

        // Skip the first tiem since its useless info for the user
        for (int i = 1; i < numItems; i++)
        {
            TRow row = new TRow(docTSV.lineAt(i));

            // Heading
            EditorGUILayout.LabelField(row.title, headingGUIStyle);

            // Description
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(10f);
            EditorGUILayout.LabelField(row.description, paragraphGUIStyle);

            GUILayout.FlexibleSpace();
        
            // Popout Button
            if (GUILayout.Button(popoutBtnContent, GUILayout.Width(40), GUILayout.Height(40)))
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