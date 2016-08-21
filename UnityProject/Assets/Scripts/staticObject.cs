using UnityEngine;
using System.Collections;

public class staticObject : MonoBehaviour
{
    public static staticObject V;
    
    GameObject m_obj;

    //public TextAsset m_script;

    void Start()
    {
        if (V!=null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        V = this;

        DontDestroyOnLoad(gameObject);
    }

    public void PLAYEFFECT(string name, Vector3 pos)
    {
        StartCoroutine(_playeffect(name,pos));       
    }

    IEnumerator _playeffect(string name, Vector3 pos)
    { 
        var prefab = Resources.Load<GameObject>("Effect/" + name);
        if (prefab==null) yield break;

        m_obj = Instantiate<GameObject>(prefab);
        m_obj.transform.parent = transform;
        m_obj.transform.position = pos;
        
        yield return new WaitForSeconds(1.1f);
        DestroyImmediate(m_obj);
        m_obj = null;
    }
}	

