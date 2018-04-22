using System;
using System.Text;
using System.Collections;
using System.Reflection;
using Microsoft.VisualBasic;
using System.Globalization;

namespace SouthStarTitleCommon.Text
{
    public class StringUtil
    {
        // Methods
        private StringUtil()
        {
        }

        public static ArrayList ExtractInnerContent(string content, string start, string end)
        {
            int startIndex = -1;
            int index = -1;
            int num3 = -1;
            int length = 0;
            ArrayList list = new ArrayList();
            startIndex = content.IndexOf(start);
            num3 = startIndex + start.Length;
            index = content.IndexOf(end, num3);
            length = index - num3;
            if ((startIndex >= 0) && (index > startIndex))
            {
                list.Add(content.Substring(num3, length));
            }
            while ((startIndex >= 0) && (index > 0))
            {
                startIndex = content.IndexOf(start, index);
                if (startIndex > 0)
                {
                    index = content.IndexOf(end, startIndex);
                    num3 = startIndex + start.Length;
                    length = index - num3;
                    if ((num3 > 0) && (index > 0))
                    {
                        list.Add(content.Substring(num3, length));
                    }
                }
            }
            return list;
        }

        public static ArrayList ExtractOuterContent(string content, string start, string end)
        {
            int startIndex = -1;
            int index = -1;
            ArrayList list = new ArrayList();
            startIndex = content.IndexOf(start);
            index = content.IndexOf(end);
            if ((startIndex >= 0) && (index > startIndex))
            {
                list.Add(content.Substring(startIndex, (index + end.Length) - startIndex));
            }
            while ((startIndex >= 0) && (index > 0))
            {
                startIndex = content.IndexOf(start, index);
                if (startIndex > 0)
                {
                    index = content.IndexOf(end, startIndex);
                    if ((startIndex > 0) && (index > 0))
                    {
                        list.Add(content.Substring(startIndex, (index + end.Length) - startIndex));
                    }
                }
            }
            return list;
        }

        public static string Pluralize(string word)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            if (word.Length >= 2)
            {
                str = word.Substring(word.Length - 1);
            }
            if (word.Length >= 3)
            {
                str2 = word.Substring(word.Length - 2);
            }
            if (str2.ToLower() == "ss")
            {
                word = word + "es";
                return word;
            }
            if (str.ToLower() == "s")
            {
                return word;
            }
            if (str.ToLower() == "y")
            {
                return (word.Substring(0, word.Length - 1) + "ies");
            }
            return (word = word + "s");
        }

        public static string RemoveFinalChar(string s)
        {
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            return s;
        }

        public static string RemoveFinalComma(string s)
        {
            if (s.Trim().Length > 0)
            {
                int num = s.LastIndexOf(",");
                if (num > 0)
                {
                    s = s.Substring(0, s.Length - (s.Length - num));
                }
            }
            return s;
        }

        public static string RemoveSpaces(string s)
        {
            s = s.Trim();
            s = s.Replace(" ", "");
            return s;
        }

        public static string Singularize(string word)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (word.Length >= 2)
            {
                str = word.Substring(word.Length - 1);
            }
            if (word.Length >= 3)
            {
                str2 = word.Substring(word.Length - 2);
            }
            if (word.Length >= 4)
            {
                str3 = word.Substring(word.Length - 3);
            }
            if (str3.ToLower() == "ies")
            {
                return (word.Substring(0, word.Length - 3) + "y");
            }
            if (str3.ToLower() == "ees")
            {
                return word.Substring(0, word.Length - 1);
            }
            if (str2.ToLower() == "es")
            {
                word = word.Substring(0, word.Length - 2);
                return word;
            }
            if ((str2.ToLower() != "ss") && (str.ToLower() == "s"))
            {
                return word.Substring(0, word.Length - 1);
            }
            return word;
        }

        public static string ToProperCase(string s)
        {
            if (s.Length <= 0)
            {
                return "";
            }
            if (s.IndexOf(" ") > 0)
            {
                return Strings.StrConv(s, VbStrConv.ProperCase, 0x409);
            }
            return (s.Substring(0, 1).ToUpper(new CultureInfo("en-US")) + s.Substring(1, s.Length - 1));
        }

        public static string ToString(object o)
        {
            StringBuilder builder = new StringBuilder();
            Type type = o.GetType();
            PropertyInfo[] properties = type.GetProperties();
            builder.Append("Properties for: " + o.GetType().Name + Environment.NewLine);
            foreach (PropertyInfo info in properties)
            {
                try
                {
                    builder.Append("\t" + info.Name + "(" + info.PropertyType.ToString() + "): ");
                    if (null != info.GetValue(o, null))
                    {
                        builder.Append(info.GetValue(o, null).ToString());
                    }
                }
                catch
                {
                }
                builder.Append(Environment.NewLine);
            }
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo info2 in fields)
            {
                try
                {
                    builder.Append("\t" + info2.Name + "(" + info2.FieldType.ToString() + "): ");
                    if (null != info2.GetValue(o))
                    {
                        builder.Append(info2.GetValue(o).ToString());
                    }
                }
                catch
                {
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        public static string ToTrimmedProperCase(string s)
        {
            return RemoveSpaces(ToProperCase(s));
        }
    }
}
