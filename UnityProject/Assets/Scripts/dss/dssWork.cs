using UnityEngine;
using System.Collections.Generic;

public enum dssAnchor
{
    TL,TC,TR,
    ML,MC,MR,
    BL,BC,BR
}

public class dssDisplaySet
{
    public string screen;
    public string layer;
    public dssAnchor anchor;

    public string objectname;

    public Vector3 pos;

    public string buttonname;
}

public class dssWork {
    public dssManager Manager     {get; private set; }

    public string    Screen       {get; private set; }
    public string    Layer        {get; private set; }
    public dssAnchor Anchor       {get; private set; }

    public bool      bValidScreen {get; private set; }

    public void SetManager(dssManager man) { Manager = man; }

    public void SetScreen(string screen)
    {
        Screen = screen;
        bValidScreen = (Application.loadedLevelName == Screen);
    }
    public void SetScreenInterval(double t) { Manager.SetRepeatInterval((float)t);}

    public void SetLayer(string layer)
    {
        Layer = layer;
    }

    public dssDisplaySet SetDisplaySet(string objectname, Vector3 pos, string btn=null)
    {
        if (!bValidScreen) return null;

        if (btn==null)
        { 
            Manager.SetObj(objectname,pos);
        }
        else
        {
            Manager.SetObj_Button(objectname,Layer,btn,pos);
        }

        

        return null;
    }
}
