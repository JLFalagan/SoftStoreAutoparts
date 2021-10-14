using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// Pone en mayuscula la primer letra de cada palabra en el texto
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Capitalize(this string text)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text);
        }

        public static string ToFormat(this string value, params string[] args)
        {
            return string.Format(value, args);
        }

        public static string GetBimester(this int month)
        {
            switch (month)
            {
                case 2: return "Bimestre 1";
                case 4: return "Bimestre 2";
                case 6: return "Bimestre 3";
                case 8: return "Bimestre 4";
                case 10: return "Bimestre 5";
                case 12: return "Bimestre 6";
                default: return string.Empty;
            }
        }

        public static string MonthToText(this int month)
        {
            switch (month)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
                default: return string.Empty;
            }
        }

        public static string ToCurrencyInLetters(this decimal value, int decimals = 2)
        {
            var roundValue = Math.Round(value, decimals);
            var e = Convert.ToInt32(Math.Truncate(roundValue));
            var d = (int)((roundValue - (int)roundValue) * Convert.ToInt64(Math.Pow(10, decimals)));

            var result = $"{e.ToText()} con {d.ToText()} ctvo/s.";

            return result;
        }

        public static string ToText(this int value)
        {
            string Num2Text = "";
            if (value < 0) return "menos " + Math.Abs(value).ToText();

            if (value == 0) Num2Text = "cero";
            else if (value == 1) Num2Text = "uno";
            else if (value == 2) Num2Text = "dos";
            else if (value == 3) Num2Text = "tres";
            else if (value == 4) Num2Text = "cuatro";
            else if (value == 5) Num2Text = "cinco";
            else if (value == 6) Num2Text = "seis";
            else if (value == 7) Num2Text = "siete";
            else if (value == 8) Num2Text = "ocho";
            else if (value == 9) Num2Text = "nueve";
            else if (value == 10) Num2Text = "diez";
            else if (value == 11) Num2Text = "once";
            else if (value == 12) Num2Text = "doce";
            else if (value == 13) Num2Text = "trece";
            else if (value == 14) Num2Text = "catorce";
            else if (value == 15) Num2Text = "quince";
            else if (value < 20) Num2Text = "dieci" + (value - 10).ToText();
            else if (value == 20) Num2Text = "veinte";
            else if (value < 30) Num2Text = "veinti" + (value - 20).ToText();
            else if (value == 30) Num2Text = "treinta";
            else if (value == 40) Num2Text = "cuarenta";
            else if (value == 50) Num2Text = "cincuenta";
            else if (value == 60) Num2Text = "sesenta";
            else if (value == 70) Num2Text = "setenta";
            else if (value == 80) Num2Text = "ochenta";
            else if (value == 90) Num2Text = "noventa";
            else if (value < 100)
            {
                int u = value % 10;
                Num2Text = string.Format("{0} y {1}", ((value / 10) * 10).ToText(), (u == 1 ? "un" : (value % 10).ToText()));
            }
            else if (value == 100) Num2Text = "cien";
            else if (value < 200) Num2Text = "ciento " + (value - 100).ToText();
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800))
                Num2Text = ((value / 100)).ToText() + "cientos";
            else if (value == 500) Num2Text = "quinientos";
            else if (value == 700) Num2Text = "setecientos";
            else if (value == 900) Num2Text = "novecientos";
            else if (value < 1000) Num2Text = string.Format("{0} {1}", ((value / 100) * 100).ToText(), (value % 100).ToText());
            else if (value == 1000) Num2Text = "mil";
            else if (value < 2000) Num2Text = "mil " + (value % 1000).ToText();
            else if (value < 1000000)
            {
                Num2Text = ((value / 1000)).ToText() + " mil";
                if ((value % 1000) > 0) Num2Text += " " + (value % 1000).ToText();
            }
            else if (value == 1000000) Num2Text = "un millón";
            else if (value < 2000000) Num2Text = "un millón " + (value % 1000000).ToText();
            else if (value < int.MaxValue)
            {
                Num2Text = ((value / 1000000)).ToText() + " millones";
                if ((value - (value / 1000000) * 1000000) > 0) Num2Text += " " + (value - (value / 1000000) * 1000000).ToText();
            }
            return Num2Text;
        }

        public static string ToCopyName(this int value)
        {
            switch (value)
            {
                case 1:
                    return "Original";
                case 2:
                    return "Duplicado";
                case 3:
                    return "Triplicado";
                default:
                    return $"# {value}";
            }
        }

        static string[] dateStringformats = { "ddMMyy", "ddMMyyyy", "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "dd-MM-yyyy", "dd-M-yyyy", "d-M-yyyy", "d-MM-yyyy", "dd-MM-yy", "dd-M-yy", "d-M-yy", "d-MM-yy" };

        public static string ToStringDate(this string value, string outFormat = "dd/MM/yyyy")
        {
            string result = string.Empty;
            DateTime date;
            if (DateTime.TryParseExact(value, dateStringformats, null, DateTimeStyles.None, out date))
                result = date.ToString(outFormat);
            return result;
        }

        //public static string Indent(int count, char pad)
        //{
        //    return String.Empty.PadLeft(count, pad);
        //}

        public static string Indent(this string value, int count, string pad)
        {
            return string.Concat(Enumerable.Repeat(pad, count)) + value;
        }

        public static DateTime? ToDate(this string value, bool endTime = false)
        {
            DateTime? result = null;
            DateTime date;
            if (DateTime.TryParseExact(value, dateStringformats, null, DateTimeStyles.None, out date))
            {
                result = date;
                if (endTime)
                    result = result.Value.AddSeconds(86399);
            }

            return result;
        }

        public static DateTime ToDateEndTime(this DateTime value)
        {
            var newValue = new DateTime(value.Year, value.Month, value.Day);
            return newValue.AddSeconds(86399);
        }
        public static DateTime ToDateInitTime(this DateTime value)
        {
            var newValue = new DateTime(value.Year, value.Month, value.Day);
            return newValue;
        }
    }

}
