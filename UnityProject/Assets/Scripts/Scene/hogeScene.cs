using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class hogeScene : MonoBehaviour {
    public Text m_text;
    public float m_limit = 5;

    float m_elapsed;

	// Use this for initialization
	void Start () {
	    m_elapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        m_text.text= (m_limit - m_elapsed).ToString("0.0");
        m_elapsed += Time.deltaTime;
        if (m_elapsed> m_limit)
        {
            Application.LoadLevel("TestScene");
        }    	
	}
}
