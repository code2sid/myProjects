using System;
using System.Text;
using System.Text.RegularExpressions;

namespace KarrStyle.BLL
{
    public static class CleanAndFormat
    {
        #region Clean DB Object
        public static object CleanObject(object obj)
        {
            if (obj == System.DBNull.Value)
                obj = null;

            return obj;
        }
        #endregion

        #region Clean Text Methods
        /// <summary>
        /// This function takes an object and returns a string
        /// </summary>
        /// <param name="text">the object which is a string</param>
        /// <param name="htmlSpace">appends an html space if true</param>
        /// <param name="htmlLine">appends an html line break if true</param>
        /// <returns>returns a string value of the object</returns>
        public static string CleanText(object obj)
        {
            obj = CleanObject(obj);

            if (obj == null)
                obj = string.Empty;

            return CleanText(obj.ToString(), false, false);
        }

        public static string CleanText(string text)
        {
            if (text == null)
                text = string.Empty;

            return CleanText(text, false, false);
        }

        /// <summary>
        /// This function cleans the string text and appends a html space &nbsp; or htmnl line break if required
        /// </summary>
        /// <param name="text">text to check & clean</param>
        /// <param name="htmlSpace">appends html space if true</param>
        /// <param name="htmlLine">appends html line break if true</param>
        /// <returns>returns a cleaned string with no leading or trailing spaces</returns>
        public static string CleanText(string text, bool htmlSpace, bool htmlLine)
        {
            if (text == null)
                text = string.Empty;
            else
            {
                text = text.Trim();
            }

            if (htmlSpace)
                text = text + "&nbsp;";

            if (htmlLine)
                text = text + "<br />";

            return text;
        }

        #endregion

        #region Clean Integer Methods
        /// <summary>
        /// returns a zero if it is an empty string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CleanInteger(string num)
        {
            num = CleanText(num);

            if (num.Equals(string.Empty))
                num = "0";
            return int.Parse(num);
        }

        /// <summary>
        /// returns zero or number assuming the object can be cast into int
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int CleanInteger(object num)
        {
            return CleanInteger(CleanText(num));
        }

        #endregion

        #region Clean Double Methods

        public static double CleanDouble(string num)
        {
            num = CleanText(num);

            if (num.Equals(string.Empty))
                num = "0.0";

            return double.Parse(num);
        }

        public static double CleanDouble(object num)
        {
            return CleanDouble(CleanText(num));
        }

        #endregion

        #region Clean Float Methods

        public static float CleanFloat(string num)
        {
            num = CleanText(num);

            if (num.Equals(string.Empty))
                num = "0.0";

            return float.Parse(num);
        }

        public static float CleanFloat(object num)
        {
            return CleanFloat(CleanText(num));
        }

        #endregion

        #region Check Field methods

        /// <summary>
        /// This functions checks if the field value is blank then it
        /// throws an exception
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <param name="message"></param>
        public static void CheckField(string fieldValue, string message)
        {
            if (CleanText(fieldValue) == string.Empty)
                throw new ArgumentException(message);
        }

        public static void CheckField(object fieldValue, string message)
        {
            CheckField(CleanText(fieldValue), message);
        }

        public static void CheckField(string fieldValue, string emptyFieldValue, string message)
        {
            if (CleanText(fieldValue) == emptyFieldValue)
                throw new ArgumentException(message);
        }

        public static void CheckField(object fieldValue, string emptyFieldValue, string message)
        {
            CheckField(CleanText(fieldValue), emptyFieldValue, message);
        }

        /// <summary>
        /// This functions checks if the field value is blank then it
        /// throws an exception 
        /// </summary>
        /// <param name="fieldValue"></param>
        /// <param name="message"></param>
        public static void CheckField(int fieldValue, string message)
        {
            if (CleanInteger(fieldValue) <= 0)
                throw new ArgumentException(message);
        }

        #endregion

        #region Clean and Check Fields

        public static string CleanAndCheckString(string fieldValue, string message)
        {
            return CleanAndCheckString(fieldValue, message, string.Empty);
        }

        public static string CleanAndCheckString(string fieldValue, string message, string emptyFieldValue)
        {
            fieldValue = CleanText(fieldValue);

            if (fieldValue.Equals(emptyFieldValue) && message != string.Empty)
                throw new ArgumentException(message);

            return fieldValue;
        }

        public static string CleanAndCheckString(object fieldValue, string message)
        {
            return CleanAndCheckString(CleanText(fieldValue), message);
        }

        public static string CleanAndCheckString(object fieldValue, string message, string emptyFieldValue)
        {
            return CleanAndCheckString(CleanText(fieldValue), message, emptyFieldValue);
        }

        public static int CleanAndCheckInteger(string fieldValue, string message)
        {
            int num = 0;

            fieldValue = CleanText(fieldValue);

            if (IsNumeric(fieldValue))
            {
                num = CleanInteger(fieldValue);
                if (num <= 0)
                    throw new ArgumentException(message);
            }
            else
            {
                throw new ArgumentException(message);
            }

            return num;
        }

        public static int CleanAndCheckInteger(object fieldValue, string message)
        {
            return CleanAndCheckInteger(CleanText(fieldValue), message);
        }

        public static double CleanAndCheckDouble(string fieldValue, string message)
        {
            double num = 0;

            fieldValue = CleanText(fieldValue);

            if (IsNumeric(fieldValue))
            {
                num = CleanDouble(fieldValue);
                if (num <= 0.00)
                    throw new ArgumentException(message);
            }
            else
            {
                throw new ArgumentException(message);
            }

            return num;
        }

        public static double CleanAndCheckDouble(object fieldValue, string message)
        {
            return CleanAndCheckDouble(CleanText(fieldValue), message);
        }



        #endregion

        #region IsNumeric method
        public static bool IsNumeric(object fieldValue)
        {
            double retNum;
            bool ret = false;

            if (Double.TryParse(Convert.ToString(fieldValue), System.Globalization.NumberStyles.Any,
                                    System.Globalization.NumberFormatInfo.InvariantInfo, out retNum))
                ret = true;

            return ret;
        }

        public static bool IsInteger(object fieldValue)
        {
            double retNum;
            bool ret = false;

            if (Double.TryParse(CleanText(fieldValue),
                                    System.Globalization.NumberStyles.AllowLeadingSign & System.Globalization.NumberStyles.Integer,
                                    System.Globalization.NumberFormatInfo.InvariantInfo,
                                    out retNum))
                ret = true;
            return ret;
        }

        #endregion

        #region Format double & Integer method
        public static string FormatDouble(string str)
        {
            double num = CleanDouble(str);
            return string.Format("{0:#,##0.00}", num);
        }

        public static string FormatDouble(object obj)
        {
            double num = CleanDouble(obj);
            return string.Format("{0:#,##0.00}", num);
        }

        public static string FormatInteger(string str)
        {
            int num = CleanInteger(str);
            return string.Format("{0:#,##0}", num);
        }

        public static string FormatInteger(object obj)
        {
            int num = CleanInteger(obj);
            return string.Format("{0:#,##0}", num);
        }
        #endregion

        #region Format Date and Email
        public static string CheckEmailFormat(string emailAddress, string message)
        {
            bool result = false;

            Regex regEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (regEmail.IsMatch(emailAddress))
            {
                result = true;
            }

            if (emailAddress != string.Empty && result == false)
            {
                throw new ArgumentException(message);
            }
            return emailAddress;
        }

        public static DateTime CheckDateFormat(string date, string message)
        {
            DateTime result;

            if (CleanText(date) == string.Empty || !DateTime.TryParse(date, out result))
            {
                throw new ArgumentException(message);
            }

            return result;
        }

        public static string CheckURLFormat(string url, string message)
        {
            bool result = false;
            string strRegex = "^(https?://)"
            + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
            + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
            + "|" // allows either IP or domain
            + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
            + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // second level domain
            + "[a-z]{2,6})" // first level domain- .com or .museum
            + "(:[0-9]{1,4})?" // port number- :80
            + "((/?)|" // a slash isn't required if there is no file name
            + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(CleanText(url)))
            {
                result = true;
            }

            if (url != string.Empty && result == false)
            {
                throw new ArgumentException(message);
            }
            return url;
        }

        public static string CheckTelephoneFormat(string telephoneNum, string message)
        {
            bool result = false;

            Regex regTelephone = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");

            if (regTelephone.IsMatch(CleanText(telephoneNum)))
            {
                result = true;
            }

            if (telephoneNum != string.Empty && result == false)
            {
                throw new ArgumentException(message);
            }
            return telephoneNum;
        }

        public static string CheckZipCodeFormat(string zipcode, string message)
        {
            bool result = false;

            //Regex regZipCode = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
            Regex regZipCode = new Regex(@"^(\d{5})(-\d{4})?$");
            if (regZipCode.IsMatch(CleanText(zipcode)) && (!zipcode.Equals("00000")))
            {
                result = true;
            }

            if (zipcode != string.Empty && result == false)
            {
                throw new ArgumentException(message);
            }
            return zipcode;
        }
        #endregion

        #region Special Common Functions
        public static string XmlToText(string xmlString, string seperator)
        {
            StringBuilder csvString = new StringBuilder(xmlString);
            csvString.Replace("<row ", "");
            csvString.Replace(" />", seperator);
            return csvString.ToString();
        }

        /// <summary>
        /// Return a copy of the specified string with the first character and
        /// any characters following spaces, as upper-case.
        /// </summary>
        public static string ConvertToTitleCase(string val)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < val.Length; ++i)
            {
                if (i == 0 || val[i - 1] == ' ')
                {
                    sb.Append(Char.ToUpper(val[i]));
                }
                else
                {
                    sb.Append(val[i]);
                }
            }

            return sb.ToString();
        }

        public static string ConvertToTitleCase(object val)
        {
            return ConvertToTitleCase(CleanText(val));
        }

        #endregion

        #region KM to Mile Conversion

        /// <summary>
        /// if the unit is kilometers the distance is converted into miles
        /// </summary>
        /// <param name="val"></param>
        /// <param name="useMetricsSystem"></param>
        /// <returns></returns>
        public static double GetMileageInCorrectUnit(double val, bool useMetricsSystem)
        {
            if (useMetricsSystem)
            {
                val *= 1.609;
            }
            string r = val.ToString(); //       'F1' format specifier: 240.0 
            val = double.Parse(r);
            return val;
        }

        public static double GetMileageInCorrectUnit(object obj, bool useMetricsSystem)
        {
            double val = 0.00;

            val = CleanDouble(obj);

            return GetMileageInCorrectUnit(val, useMetricsSystem);
        }

        public static double ConvertToMile(double val, bool useMetricsSystem)
        {
            //return useMetricsSystem ? val * .625 : val;
            return useMetricsSystem ? val  : val;
        }

        #endregion
    }
}
