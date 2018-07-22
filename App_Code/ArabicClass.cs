using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ArabicClass
/// </summary>
public class ArabicClass
{
    public ArabicClass()
    {

    }

    public static string ConvertNumeralsToArabic(string input)
    {
        return input = input.Replace('0', '٠')
                    .Replace('1', '۱')
                    .Replace('2', '۲')
                    .Replace('3', '۳')
                    .Replace('4', '٤')
                    .Replace('5', '۵')
                    .Replace('6', '٦')
                    .Replace('7', '٧')
                    .Replace('8', '٨')
                    .Replace('9', '٩');
    }
}