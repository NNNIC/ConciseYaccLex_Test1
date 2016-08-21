using UnityEngine;
using System.Collections;

public class testScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUILayout.Button("BACK TO MENU",GUILayout.Width(Screen.width)))
        {
            Application.LoadLevel("MenuScene");
        }
    }
}
