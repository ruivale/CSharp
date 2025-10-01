using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpRuntimeCameo.network
{
    public static class MyConvert
    {
        public static bool ToBoolean(string st, bool bDefaulValue)
        {
            if ((st.Equals("true", StringComparison.OrdinalIgnoreCase)) || (st.Equals("1")))
                return true;
            else if ((st.Equals("false", StringComparison.OrdinalIgnoreCase)) || (st.Equals("0")))
                return false;
            else
                return bDefaulValue;
        }

        public static int ToInt32(string st, int iDefaultValue)
        {
            int i;
            if (int.TryParse(st, out i))
                return i;

            return iDefaultValue;
        }

        public static short ToInt16(string st, short iDefaultValue)
        {
            short i;
            if (short.TryParse(st, out i))
                return i;

            return iDefaultValue;
        }

        public static DateTime ToDateTime(string st, DateTime dtDefaultValue)
        {
            DateTime dt;
            if (DateTime.TryParse(st, out dt))
                return dt;

            return dtDefaultValue;
        }
    }
}
