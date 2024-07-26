using System;
using System.Collections.Generic;

public class OldPhonePad
{
    public static string ConvertInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "";

        Dictionary<char, string> keypad = new Dictionary<char, string>
        {
            { '1', "" },        // '1' key maps to special character
            { '2', "ABC" },    // '2' key maps to 'A', 'B', 'C'
            { '3', "DEF" },    // '3' key maps to 'D', 'E', 'F'
            { '4', "GHI" },    // '4' key maps to 'G', 'H', 'I'
            { '5', "JKL" },    // '5' key maps to 'J', 'K', 'L'
            { '6', "MNO" },    // '6' key maps to 'M', 'N', 'O'
            { '7', "PQRS" },   // '7' key maps to 'P', 'Q', 'R', 'S'
            { '8', "TUV" },    // '8' key maps to 'T', 'U', 'V'
            { '9', "WXYZ" },   // '9' key maps to 'W', 'X', 'Y', 'Z'
            { '0', " " },      // '0' key maps to a space character
            { '*', "" },       // '*' key is used for backspace
            { '#', "" }        // '#' key signifies end of input
        };

        string result = "";
        char lastChar = '\0';
        int count = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char nextChar = input[i]; // Renamed from currentChar to nextChar

            if (nextChar == '#')
            {
                break;
            }
            else if (nextChar == '*')
            {
                if (result.Length > 0)
                {
                    result = result.Substring(0, result.Length - 1);
                }
            }
            else if (nextChar == ' ')
            {
                // Pause detected, commit the last character if any
                if (lastChar != '\0' && keypad.ContainsKey(lastChar))
                {
                    string possibleChars = keypad[lastChar];
                    if (possibleChars.Length > 0)
                    {
                        result += possibleChars[(count - 1) % possibleChars.Length];
                    }
                }
                lastChar = '\0';  // Reset lastChar to handle pause
                count = 0;  // Reset count
            }
            else
            {
                if (nextChar == lastChar)
                {
                    count++;
                }
                else
                {
                    if (lastChar != '\0' && keypad.ContainsKey(lastChar))
                    {
                        string possibleChars = keypad[lastChar];
                        if (possibleChars.Length > 0)
                        {
                            result += possibleChars[(count - 1) % possibleChars.Length];
                        }
                    }

                    lastChar = nextChar; // Update lastChar to nextChar
                    count = 1;
                }
            }
        }

        // Handle the last sequence
        if (lastChar != '\0' && keypad.ContainsKey(lastChar))
        {
            string possibleChars = keypad[lastChar];
            if (possibleChars.Length > 0)
            {
                result += possibleChars[(count - 1) % possibleChars.Length];
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        // Testing the ConvertInput method with various inputs
        Console.WriteLine(OldPhonePad.ConvertInput("33#"));             // Output: E
        Console.WriteLine(OldPhonePad.ConvertInput("227*#"));           // Output: B
        Console.WriteLine(OldPhonePad.ConvertInput("4433555 555666#")); // Output: HELLO
        Console.WriteLine(OldPhonePad.ConvertInput("8 88777444666*664#")); 
        Console.WriteLine(OldPhonePad.ConvertInput("222 2 22#"));       // Output: CAB
    }
}
