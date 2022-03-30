using UnityEngine;
using UnityEditor;
using VRC.SDK3.Components;
using VRC.Udon;
using UdonSharp;
using UdonSharpEditor;
public partial class TanukiUdonWindow : EditorWindow
{
    public static TanukiUdonWindow window;
    //Make the TanukiUdon window selection appear in Window toolbar tab
    [MenuItem("Window/TanukiUdon")]

    //Makes the UI actually work
    public static void ShowWindow()
    {
        window = (TanukiUdonWindow)EditorWindow.GetWindow<TanukiUdonWindow>("TanukiUdon");
        window.InitializeStyles();
    }
    
    // Needed for ToolBar
    int whichPanel = 0;

    // Styles
    public static GUIStyle titleGUIStyle;
    public static GUIStyle boxGUIStyle;
    static Texture _TanukiLogo;

    void InitializeStyles()
    {
        titleGUIStyle = new GUIStyle();
        titleGUIStyle.fontSize = 32;
        titleGUIStyle.fontStyle = FontStyle.BoldAndItalic;
        titleGUIStyle.alignment = TextAnchor.MiddleCenter;
        titleGUIStyle.wordWrap = true;
        if (EditorGUIUtility.isProSkin)
            titleGUIStyle.normal.textColor = Color.white;
        else
            titleGUIStyle.normal.textColor = Color.black;
        
        boxGUIStyle = new GUIStyle();
        if (EditorGUIUtility.isProSkin)
        {
            boxGUIStyle.normal.background = CreateBackgroundColorImage(new Color(0.3f, 0.3f, 0.3f));
            boxGUIStyle.normal.textColor = Color.white;
        }
        else
        {
            boxGUIStyle.normal.background = CreateBackgroundColorImage(new Color(0.85f, 0.85f, 0.85f));
            boxGUIStyle.normal.textColor = Color.black;
        }
        
    }

    private readonly GUIContent[] _toolbarLabels = new GUIContent[3]
    {
        new GUIContent("Tools"),
        new GUIContent("Documentation"),
        new GUIContent("WHatever")
    };

    void OnGUI()
    {
        if (window == null)
        {
            window = (TanukiUdonWindow)EditorWindow.GetWindow(typeof(TanukiUdonWindow));
            InitializeStyles();
        }
        // Load Logo
        if (_TanukiLogo == null)
            _TanukiLogo = Resources.Load<Texture2D>("TanukiLogo");

        // Display Logo and Header text
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUI.DrawTexture(new Rect(10, 0, 80, 80), _TanukiLogo);

        EditorGUILayout.Space(30f);
        EditorGUILayout.LabelField("TanukiUdon", titleGUIStyle);

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        EditorGUILayout.Space(20f);

        whichPanel = GUILayout.Toolbar(whichPanel, _toolbarLabels);
        GUILayout.Space(5f); 

        switch (whichPanel)
        {
            case 0:
                ShowTools();
                break;
            case 1:
                ShowDocumentation();
                break;
            case 2:
                ShowWhatever();
                break;
            default:
                ShowTools();
                break;
        }
        
        // Footer
        GUILayout.FlexibleSpace();
        GUILayout.Label("TanukiUdon v0.0.4", EditorStyles.boldLabel);
    }

    Texture2D CreateBackgroundColorImage(UnityEngine.Color color)
    {
        int w = 4, h = 4;
        Texture2D back = new Texture2D(w, h);
        UnityEngine.Color[] buffer = new UnityEngine.Color[w * h];
        for (int i = 0; i < w; ++i)
            for (int j = 0; j < h; ++j)
                buffer[i + w * j] = color;
        back.SetPixels(buffer);
        back.Apply(false);
        return back;
    }
}
