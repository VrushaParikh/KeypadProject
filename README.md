
Welcome to the OldPhonePad project! This simple C# application simulates the behavior of an old mobile phone keypad. It converts sequences of keypresses into their corresponding text outputs. If you're nostalgic for the days of pressing multiple keys to get the right letter, this tool is for you.

How It Works
The OldPhonePad class translates input sequences from an old mobile phone keypad into readable text. Here’s a quick rundown of how it processes the input:

Input Format:

Digits 2 through 9 correspond to letters (2 -> "ABC", 3 -> "DEF", etc.)

-->  0 represents a space.

--> '*' acts as a backspace, removing the last character.

--> '#' signifies the end of the input.

