using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Hack4Fun.Data;

namespace Hack4Fun.Systems
{
    /// <summary>
    /// Implements Brute Force and Dictionary attack mechanics
    /// </summary>
    public class HackingSystem : MonoBehaviour
    {
        private List<string> dictionaryWords = new List<string>();
        private int bruteForceAttempts = 0;
        private int dictionaryAttempts = 0;

        public delegate void AttackProgressCallback(int attempts, string lastGuess);
        public event AttackProgressCallback OnAttackProgress;

        private void Awake()
        {
            InitializeDictionary();
        }

        /// <summary>
        /// Initialize dictionary with common words for dictionary attacks
        /// </summary>
        private void InitializeDictionary()
        {
            // Common password words
            dictionaryWords = new List<string>
            {
                // Easy words
                "abc", "xyz", "password", "admin", "test", "hack", "neon", "cyber",
                
                // Medium words
                "matrix", "digital", "shadow", "signal", "cipher", "network", "system",
                "access", "secure", "data", "vault", "secret", "code", "lock",
                
                // Hard words
                "phantom", "decrypt", "firewall", "malware", "terminal", "command",
                "protocol", "gateway", "fortress", "nexus", "sentinel", "quantum",
                
                // Expert words
                "protocol", "synthetic", "blackgate", "nexuscore", "infinitykey",
                "algorithm", "encryption", "authentication", "verification",
                
                // Common substitutions
                "password123", "admin123", "letmein", "welcome", "monkey", "dragon",
                "master", "shadow", "sunshine", "princess", "qwerty", "123456",
                
                // Tech related
                "server", "database", "cache", "cloud", "mobile", "web", "api",
                "javascript", "python", "csharp", "java", "unity", "unreal",
            };

            Debug.Log($"[HackingSystem] Dictionary initialized with {dictionaryWords.Count} words");
        }

        /// <summary>
        /// Perform a brute force attack attempt
        /// </summary>
        public string GetNextBruteForceGuess(string targetPassword, int attemptNumber)
        {
            bruteForceAttempts++;
            
            // Generate guess based on password length and attempt number
            int passwordLength = targetPassword.Length;
            string guess = GenerateBruteForceGuess(passwordLength, attemptNumber);

            OnAttackProgress?.Invoke(bruteForceAttempts, guess);
            return guess;
        }

        /// <summary>
        /// Generate a brute force guess by incrementing through character combinations
        /// </summary>
        private string GenerateBruteForceGuess(int length, int attemptNumber)
        {
            // Simple approach: increment through lowercase letters + numbers
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            
            string result = "";
            int num = attemptNumber;

            for (int i = 0; i < length; i++)
            {
                result = chars[num % chars.Length] + result;
                num /= chars.Length;
            }

            return result;
        }

        /// <summary>
        /// Get next dictionary attack guess
        /// </summary>
        public string GetNextDictionaryGuess(int attemptNumber)
        {
            if (attemptNumber < dictionaryWords.Count)
            {
                dictionaryAttempts++;
                string guess = dictionaryWords[attemptNumber];
                OnAttackProgress?.Invoke(dictionaryAttempts, guess);
                return guess;
            }
            
            // Fallback to brute force if dictionary exhausted
            return GetNextBruteForceGuess("", attemptNumber - dictionaryWords.Count);
        }

        /// <summary>
        /// Get random guess from dictionary
        /// </summary>
        public string GetRandomDictionaryGuess()
        {
            if (dictionaryWords.Count == 0)
                return "random";

            string guess = dictionaryWords[Random.Range(0, dictionaryWords.Count)];
            dictionaryAttempts++;
            OnAttackProgress?.Invoke(dictionaryAttempts, guess);
            return guess;
        }

        /// <summary>
        /// Generate suggestions for a partial match
        /// </summary>
        public List<string> GenerateSuggestions(string targetPassword, string lastGuess, int suggestionCount = 5)
        {
            List<string> suggestions = new List<string>();

            // Get words with similar length
            var similarLengthWords = dictionaryWords
                .Where(w => w.Length >= targetPassword.Length - 1 && w.Length <= targetPassword.Length + 1)
                .ToList();

            // Return random similar words
            for (int i = 0; i < Mathf.Min(suggestionCount, similarLengthWords.Count); i++)
            {
                int randomIndex = Random.Range(0, similarLengthWords.Count);
                suggestions.Add(similarLengthWords[randomIndex]);
                similarLengthWords.RemoveAt(randomIndex);
            }

            return suggestions;
        }

        /// <summary>
        /// Get attack suggestions based on password length
        /// </summary>
        public List<string> GetAttackSuggestions(int passwordLength, AttackType attackType)
        {
            List<string> suggestions = new List<string>();

            if (attackType == AttackType.Dictionary || attackType == AttackType.Mixed)
            {
                // Get dictionary words of similar length
                suggestions = dictionaryWords
                    .Where(w => w.Length >= passwordLength - 1 && w.Length <= passwordLength + 1)
                    .OrderBy(x => Random.value)
                    .Take(10)
                    .ToList();
            }

            return suggestions;
        }

        /// <summary>
        /// Add custom word to dictionary
        /// </summary>
        public void AddWordToDictionary(string word)
        {
            if (!dictionaryWords.Contains(word.ToLower()))
            {
                dictionaryWords.Add(word.ToLower());
            }
        }

        /// <summary>
        /// Reset attack attempt counters
        /// </summary>
        public void ResetCounters()
        {
            bruteForceAttempts = 0;
            dictionaryAttempts = 0;
        }

        /// <summary>
        /// Get total attacks performed
        /// </summary>
        public int GetTotalAttempts()
        {
            return bruteForceAttempts + dictionaryAttempts;
        }
    }
}
