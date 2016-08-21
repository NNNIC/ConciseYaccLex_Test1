using System;
using System.Collections.Generic;

namespace lextool.runtime
{
    public static class FuncUtil
    {
        public static string get_funcname(VALUE v)
        {
            if (v.type == get_type(YDEF.sx_function))
            {
                if (v.list != null && v.list.Count > 0)
                {
                    return v.list[0].GetString();
                }
            }
            sys.error("Runtime/get_funcname", v);
            return null;
        }
        public static object[] get_parameters(VALUE v)
        {
            var find = v.FindValueByTravarse(get_type(YDEF.sx_param_list));

            if (find!=null)
            {
                if (find.list != null)
                {
                    List<object> olist = new List<object>();
                    foreach (var i in find.list)
                    {
                        var o = i.GetTerminalObject_ascent();
                        if (o == null) sys.error("Runtime/get_parameters");
                        olist.Add(o);
                    }
                    return olist.ToArray();
                }
                return null;
            }

            find = v.FindValueByTravarse(get_type(YDEF.sx_param));

            if (find!=null)
            { 
                var o = find.GetTerminalObject_ascent();
                if (o == null) sys.error("Runtime/get_parameters");
                return new object[1] { o };
            }
            
            return null;
        }
        public static void do_options_action(VALUE v, Action<VALUE> func)
        {
            if (v.type == get_type(YDEF.sx_option_phrase))
            {
                VALUE find = v.FindValueByTravarse(get_type(YDEF.sx_function_list));
                if (find != null && find.list!=null)
                {
                    find.list.ForEach(i=>func(i));
                    return;
                }
                find = v.FindValueByTravarse(get_type(YDEF.sx_function));
                if (find!=null)
                {
                    func(find);
                    return;
                }
            }
        }
        public static string del_dq(string s)
        {
            return s.Replace("\"", "");
        }

        public static int get_type(object[] o)
        {
            return YDEF.get_type(o);
        }

        public static bool get_postion(VALUE v, out UnityEngine.Vector3 pos, out string buttonname)
        {
            pos = UnityEngine.Vector3.zero;
            buttonname = null;
            var find = v.FindValueByTravarse(get_type(YDEF.sx_pos));
            if (find==null) return false;

            if (find.list.Count>1 && find.list[0].GetTerminalObject_ascent().GetType()==typeof(double))
            {
                double x = (double)find.list[0].GetTerminalObject_ascent();
                double y = find.list.Count>1 ? (double)find.list[1].GetTerminalObject_ascent() : 0;
                double z = find.list.Count>2 ? (double)find.list[2].GetTerminalObject_ascent() : 0;

                pos = new UnityEngine.Vector3((float)x,(float)y,(float)z);

                return true;
            }
            else
            { 
                buttonname = del_dq(find.list[0].GetTerminalObject_ascent().ToString());
                double x = find.list.Count>1 ? (double)find.list[1].GetTerminalObject_ascent() : 0;
                double y = find.list.Count>2 ? (double)find.list[2].GetTerminalObject_ascent() : 0;
                double z = find.list.Count>3 ? (double)find.list[3].GetTerminalObject_ascent() : 0;

                pos = new UnityEngine.Vector3((float)x,(float)y,(float)z);

                return true;
            }          
        }
    }
}
