using System;
using System.Collections.Generic;

namespace lextool.runtime
{
    public class PreProcessFunction
    {
        public static DateTime m_today { get { return menuScene.m_today; } }

        public static bool Execute(VALUE v)
        {
            var func = FuncUtil.get_funcname(v);
            if (func == "DATE")
            {
                var p = FuncUtil.get_parameters(v);
                if (p == null || p.Length == 0) sys.error("Runtime/PreProcessFunction.Execute",v);
                var s = FuncUtil.del_dq(p[0].ToString());
                try
                {
                    var date = DateTime.Parse(s);
                    if (date.Year == m_today.Year && date.Month == m_today.Month && date.Day == m_today.Day) return true;
                }
                catch {
                    sys.error("Runtime / PreProcessFunction.Execute",v);
                }
                return false;
            }
            if (func == "DATEAFTER")
            {
                var p = FuncUtil.get_parameters(v);
                if (p == null || p.Length == 0) sys.error("Runtime/PreProcessFunction.Execute", v);
                var s = FuncUtil.del_dq(p[0].ToString());
                try
                {
                    var date = DateTime.Parse(s);
                    var today = new DateTime(m_today.Year,m_today.Month,m_today.Day);
                    if (today>=date) return true;
                }
                catch
                {
                    sys.error("Runtime / PreProcessFunction.Execute", v);
                }
                return false;
            }
            if (func=="DATEBETWEEN")
            {
                var p = FuncUtil.get_parameters(v);
                if (p == null || p.Length < 2) sys.error("Runtime/PreProcessFunction.Execute", v);
                var s1 = FuncUtil.del_dq(p[0].ToString());
                var s2 = FuncUtil.del_dq(p[1].ToString());
                try
                {
                    var date1 = DateTime.Parse(s1);
                    var date2 = DateTime.Parse(s2);
                    var today = new DateTime(m_today.Year, m_today.Month, m_today.Day);
                    if (today >= date1 && today <= date2) return true;
                }
                catch
                {
                    sys.error("Runtime / PreProcessFunction.Execute", v);
                }
                return false;
            }

            return true;
        }
    }
}
