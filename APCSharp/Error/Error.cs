﻿namespace APCSharp.Error
{
    internal static class Error
    {
        internal static string Invalid(string what, string innerExcepton) => SyntaxError($"Invalid {what}; " + innerExcepton);
        internal static string Unexpected(dynamic got, params Parser.Parser[] parsers) => SyntaxError($"Unexpected '{got}' (expected {ToExpected(parsers)})");
        internal static string SyntaxError(string message) => $"Syntax Error ({Parser.Data.SharedData.LineColumn}): " + message + '.';
        internal static string ToExpected(Parser.Parser[] parsers)
        {
            string result = string.Empty;
            for (int i = 0; i < parsers.Length; i++)
            {
                result += parsers[i].GetMatchString();
                if (i < parsers.Length - 2) result += ", ";
                else if (i < parsers.Length - 1) result += " or ";
            }
            return result;
        }
    }
}