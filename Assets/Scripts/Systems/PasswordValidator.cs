using UnityEngine;
using System.Collections.Generic;
using Hack4Fun.Data;

namespace Hack4Fun.Systems
{
    /// <summary>
    /// Validates player password guesses against target passwords
    /// </summary>
    public class PasswordValidator : MonoBehaviour
    {
        // Delegate for validation events
        public delegate void ValidationCallback(bool isCorrect, string feedback);
        public event ValidationCallback OnValidationComplete;

        /// <summary>
        /// Validate a password guess
        /// </summary>
        public void ValidateGuess(string guess, string targetPassword)
        {
            if (string.IsNullOrEmpty(guess) || string.IsNullOrEmpty(targetPassword))
            {
                OnValidationComplete?.Invoke(false, "Invalid input!");
                return;
            }

            guess = guess.ToLower().Trim();
            targetPassword = targetPassword.ToLower().Trim();

            if (guess == targetPassword)
            {
                OnValidationComplete?.Invoke(true, "PASSWORD CORRECT! System breached!");
            }
            else
            {
                string feedback = GetPartialMatchFeedback(guess, targetPassword);
                OnValidationComplete?.Invoke(false, feedback);
            }
        }

        /// <summary>
        /// Get feedback on how close the guess is to the target
        /// </summary>
        private string GetPartialMatchFeedback(string guess, string target)
        {
            int correctPositions = 0;
            int correctLettersWrongPosition = 0;

            // Check for correct positions
            for (int i = 0; i < Mathf.Min(guess.Length, target.Length); i++)
            {
                if (guess[i] == target[i])
                {
                    correctPositions++;
                }
                else if (target.Contains(guess[i].ToString()))
                {
                    correctLettersWrongPosition++;
                }
            }

            // Check for letters in target not in guess
            int missingLetters = 0;
            foreach (char c in target)
            {
                if (!guess.Contains(c.ToString()))
                {
                    missingLetters++;
                }
            }

            // Generate feedback
            string feedback = "INCORRECT - ";

            if (correctPositions > 0)
            {
                feedback += $"{correctPositions} correct position(s). ";
            }

            if (correctLettersWrongPosition > 0)
            {
                feedback += $"{correctLettersWrongPosition} correct letter(s) wrong position. ";
            }

            if (guess.Length != target.Length)
            {
                feedback += $"(Target is {target.Length} characters, you entered {guess.Length})";
            }
            else if (missingLetters > 0)
            {
                feedback += $"{missingLetters} missing character(s).";
            }

            return feedback;
        }

        /// <summary>
        /// Get password length hint
        /// </summary>
        public string GetLengthHint(string targetPassword)
        {
            return $"Password is {targetPassword.Length} characters long.";
        }

        /// <summary>
        /// Get partial reveal hint (reveal first and last character)
        /// </summary>
        public string GetPartialRevealHint(string targetPassword)
        {
            if (targetPassword.Length <= 2)
                return $"Password: {targetPassword}";

            string revealed = targetPassword[0] + new string('*', targetPassword.Length - 2) + targetPassword[targetPassword.Length - 1];
            return $"Password hint: {revealed}";
        }

        /// <summary>
        /// Check if a guess is valid (not empty, reasonable length)
        /// </summary>
        public bool IsValidInput(string input)
        {
            return !string.IsNullOrEmpty(input) && input.Length > 0 && input.Length < 50;
        }
    }
}
