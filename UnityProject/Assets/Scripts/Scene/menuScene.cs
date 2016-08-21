using UnityEngine;
using System.Collections;

public class menuScene : MonoBehaviour {

    public static string m_script;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    string m_scriptname;

    Vector2 m_pos;
    void OnGUI()
    {

        GUILayout.Space(50);

        GUILayout.BeginHorizontal();
        GUILayout.Label("SELECT SCRIPT");
        _disp_button_and_load("test1");
        _disp_button_and_load("test2");
        _disp_button_and_load("test3");
        _disp_button_and_load("test4");
        _disp_button_and_load("test5");
        GUILayout.EndHorizontal();

        if (m_script!=null)
        { 
            if (GUILayout.Button("GO!"))
            {
                Application.LoadLevel("TestScene");
            }

            GUILayout.Label("SCRIPT :" + m_scriptname);
            m_pos = GUILayout.BeginScrollView(m_pos,GUILayout.Height(300));
            GUILayout.TextArea(m_script,GUILayout.Width(Screen.width));
            GUILayout.EndScrollView();
        }

    }

    void _disp_button_and_load(string n)
    {
        if (GUILayout.Button(n.ToUpper()))
        { 
            var a = (TextAsset)Resources.Load("Script/" + n);
            if (a!=null)
            {
                m_script = a.text;
                m_scriptname = n;
            }
        }
    }

}
