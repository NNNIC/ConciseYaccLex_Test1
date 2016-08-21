using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dssButton : MonoBehaviour {

    public string m_pressEffect;
    public Vector3 m_relpos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Debug.Log("Pressed!");

        var pos = transform.position;
        staticObject.V.PLAYEFFECT(m_pressEffect,pos+m_relpos);

        StartCoroutine(_onclick());

    }
    IEnumerator _onclick()
    {
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel("HogeScene");
    }

}
