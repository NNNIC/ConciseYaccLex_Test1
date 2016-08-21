using UnityEngine;
using System.Collections;
using System;

public class menuScene : MonoBehaviour {

    public static string m_script;
    public static DateTime m_today;

	// Use this for initialization
	void Start () {
	    m_today = DateTime.Now;
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
        
        if (m_scriptname == "test5")
        { 
            GUILayout.Space(30);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Today :" + m_today.ToShortDateString()  );
            if (GUILayout.Button("NOW"))        m_today = DateTime.Now;
            if (GUILayout.Button("2016/8/31"))  m_today = DateTime.Parse("2016/8/31");
            if (GUILayout.Button("2016/9/1"))   m_today = DateTime.Parse("2016/9/1");
            if (GUILayout.Button("2016/12/24")) m_today = DateTime.Parse("2016/12/24");
            GUILayout.EndHorizontal();
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
