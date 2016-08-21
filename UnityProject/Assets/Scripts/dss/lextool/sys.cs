using System;
using System.Collections.Generic;

namespace lextool
{
    public static class sys
    {
        public static void error(string s, VALUE v = null)
        {
            int line = -1;
            if (v!=null) line = v.get_dbg_line();
            
            string es = "ERROR"+ (line>=0 ? "(L:" + (line+1).ToString() + ")" : "") + ":" + s;

            UnityEngine.Debug.Log(es);
            throw new SystemException(es);
        }

        static string m_str;
        public static void log(string s)
        {
            m_str += s;
        }

        public static void logline(string s=null)
        {
            m_str += s;
            UnityEngine.Debug.Log(m_str);

            m_str = null;
        }
    }
}
