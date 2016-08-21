using UnityEngine;
using System.Collections;
using System;
public class dssManager : MonoBehaviour {
    
    //public TextAsset  m_script;
    public GameObject m_root;
    public float      m_repeat_interval = 10*60*60;

    IEnumerator Start()
    {
        while(true)
        { 
            ClearAll();
            var dw = new dssWork();
            dw.SetManager(this);
            lextool.Program.Main(menuScene.m_script,dw);

            float saved_time = Time.time;
            var   savedLevel = Application.loadedLevelName;
            while(Time.time < saved_time + m_repeat_interval)
            {
               if (Application.loadedLevelName!=savedLevel)
               {
                   break;                   
               }
                yield return null;
            }
        }
    }

    // == Util for dssWork

    public void ClearAll() {
        while(m_root.transform.childCount>0) DestroyImmediate(m_root.transform.GetChild(0).gameObject);
    }
    public void SetRepeatInterval(float t) { m_repeat_interval = t; }

    public void SetObj(string name, Vector3 pos)
    {
        var prefab = Resources.Load<GameObject>("Effect/" + name);
        var obj = Instantiate<GameObject>(prefab);
        obj.transform.parent = m_root.transform;
        obj.transform.position = pos;
    }

    public void SetObj_Button(string name, string layer, string btn,Vector3 pos)
    {
        Transform t = null;
        if (!string.IsNullOrEmpty(layer))
        {
            var go = GameObject.Find(layer);
            if (go!=null) t = go.transform;
        }
        if (t==null) { Debug.Log("Cannnot find layer"); return; }

        Transform find = _findChildren(t,btn);
        if (find==null) { Debug.Log("Cannnot find button:" + btn); return; }

        var db = find.GetComponentInChildren<dssButton>();
        if (db==null) {Debug.Log("Cannot find dssButton");return; }
        db.m_pressEffect = name;
        db.m_relpos = pos;
    }

    private Transform _findChildren(Transform root, string name)
    {
        if (root.name == name) return root;
        for(int i = 0; i<root.childCount; i++)
        {
            if (root.GetChild(i).name == name) return root.GetChild(i);
        }
        for(int i = 0; i<root.childCount; i++)
        {
            var find = _findChildren(root.GetChild(i),name);
            if (find!=null) return find;
        }
        return null;
    }
}

