namespace Scc.Mastermind;

public class MastermindLogic
{
    /// <summary>
    /// Check that the required number of digits have been entered, in the given range of values.
    /// </summary>
    /// <param name="input">Input string for validation</param>
    /// <returns>Validity flag</returns>
    public static bool ValidateInput(string? input, string secret, int minDigitValue, int maxDigitValue)
    {
        if (input?.Length == secret.Length)
        {
            int validDigits = 0;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    int val = c - '0';

                    if (val >= minDigitValue && val <= maxDigitValue)
                    {
                        validDigits++;
                    }
                }
            }

            return validDigits == secret.Length;
        }

        return false;
    }

    /// <summary>
    /// Check if the input matches the secret. If not apply logic such that a plus sign should be output 
    /// for every digit that is both correct and in the correct position.  Output all plus signs first, all minus 
    /// signs second, and nothing for incorrect digits.
    /// </summary>
    /// <param name="input">Input string for processing</param>
    /// <returns>Processing result string</returns>
    public static string ProcessInput(
        string? input,
        string secret,
        string successMessage,
        char plusMarker,
        char minusMarker)
    {
        int plusses = 0;
        int minusses = 0;

        for (int inputIndex = 0; inputIndex < secret.Length; inputIndex++)
        {
            if (input?[inputIndex] == secret[inputIndex])
            {
                plusses++;
            }
            else
            {
                for (int secretIndex = inputIndex; secretIndex < secret.Length; secretIndex++)
                {
                    if (secretIndex != inputIndex)
                    {
                        if (input?[inputIndex] == secret[secretIndex])
                        {
                            minusses++;
                        }
                    }
                }
            }
        }

        if (plusses == secret.Length)
        {
            return successMessage;
        }
        else
        {
            string matchStr = default!;

            for (int index = 0; index < plusses; index++)
            {
                matchStr += plusMarker;
            }

            for (int index = 0; index < minusses; index++)
            {
                matchStr += minusMarker;
            }

            return matchStr;
        }
    }
}
