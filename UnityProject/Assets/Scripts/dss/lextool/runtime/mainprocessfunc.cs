using System;
using System.Collections.Generic;

namespace lextool.runtime
{
    public class MainProcessFunction
    {
        public static object ExecuteSentence(List<VALUE> l,dssWork wk)
        {
            if (l==null || l.Count!=1) return null;

            var v = l[0];

            VALUE find = null;

            find = v.FindValueByTravarse(FuncUtil.get_type(YDEF.sx_screen_sentence));
            if (find != null)
            {
                sys.logline("Exec Screen Sentence");
                if (wk==null) return null;

                var id = find.list[1].GetTerminalObject_ascent();
                wk.SetScreen(FuncUtil.del_dq(id.ToString()));

                if (find.list.Count>2 && find.list[2].type == FuncUtil.get_type(YDEF.sx_option_phrase))
                {
                    FuncUtil.do_options_action(find.list[2],i=> {
                        var f = i.list[0].GetTerminalObject_ascent().ToString();
                        var pl = FuncUtil.get_parameters(i);
                        if (f=="REPEAT")
                        {
                            wk.SetScreenInterval((double)pl[0]);
                        }

                        sys.logline(f.ToString());
                    });
                }
                return null;
            }
            find = v.FindValueByTravarse(FuncUtil.get_type(YDEF.sx_layer_sentence));
            if (find != null)
            {
                sys.logline("Exec Layer Sentence");
                if (wk==null) return null;
                if (!wk.bValidScreen) return null;
                
                var id     = find.list.Count>1 ? find.list[1].GetTerminalObject_ascent() : null;
                var anchor = find.list.Count>2 ? find.list[2].GetTerminalObject_ascent() : null;
                
                wk.SetLayer(FuncUtil.del_dq(id.ToString()));

                return null;
            }
            find = v.FindValueByTravarse(FuncUtil.get_type(YDEF.sx_display_sentence));
            if (find != null)
            {
                sys.logline("Exec Display Sentence");
                if (wk==null) return null;
                if (!wk.bValidScreen) return null;

                var objname = FuncUtil.del_dq( find.list[1].GetTerminalObject_ascent().ToString() );

                UnityEngine.Vector3 pos;
                string buttonname;
                if (FuncUtil.get_postion(find.list[2],out pos, out buttonname))
                {
                    wk.SetDisplaySet(objname,pos,buttonname);
                }
                return null;
            }

            return null;
        }
    }
}
