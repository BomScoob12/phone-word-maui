using System.Text;

namespace Phoneword;
public static class PhonewordTranslator
{
    public static string? ToNumber(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) return null;

        raw = raw.ToUpperInvariant();
        string template = "-0123456789";
        var newNumber = new StringBuilder();
        foreach (var c in raw)
        {
            if (template.Contains(c))
                newNumber.Append(c);
            else
            {
                var result = TranslateToNumber(c);
                if (result != null)
                    newNumber.Append(result);
                else 
                    return null;
            }
        }
        return newNumber.ToString();
    }

    private static readonly string[] digits =
    {
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    };
    // This represent the number on the phone 1, 2, 3, 4, 5, 6, 7, 8, 9, 0

    private static int? TranslateToNumber(char c)
    {
        int aStartNumber = 2;
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i].Contains(c))
                return aStartNumber + i;
        }
        return null;
    }
}
