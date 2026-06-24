using UnityEngine;
using Hack4Fun.Data;

namespace Hack4Fun.Systems
{
    /// <summary>
    /// Handles score calculation based on time, attempts, and difficulty
    /// </summary>
    public class ScoreSystem : MonoBehaviour
    {
        public delegate void ScoreUpdateCallback(int score);
        public event ScoreUpdateCallback OnScoreUpdated;

        /// <summary>
        /// Calculate score for completing a level
        /// </summary>
        public int CalculateScore(float timeRemaining, int attemptsUsed, DifficultyLevel difficulty, float difficultyMultiplier)
        {
            int baseScore = GameConstants.BASE_POINTS;

            // Apply difficulty multiplier
            float multipliedScore = baseScore * difficultyMultiplier;

            // Add time bonus (more time remaining = more points)
            float timeBonus = timeRemaining * GameConstants.TIME_BONUS_MULTIPLIER;

            // Apply attempt penalty (fewer attempts = better)
            float attemptPenalty = attemptsUsed * GameConstants.ATTEMPT_PENALTY;

            // Perfect attempt bonus
            float perfectBonus = attemptsUsed == 1 ? GameConstants.PERFECT_ATTEMPT_BONUS : 0;

            // Calculate final score
            int finalScore = (int)(multipliedScore + timeBonus - attemptPenalty + perfectBonus);

            // Ensure score is never negative
            finalScore = Mathf.Max(0, finalScore);

            Debug.Log($"[ScoreSystem] Base: {baseScore} | Time Bonus: {timeBonus} | Attempt Penalty: {attemptPenalty} | Perfect Bonus: {perfectBonus} | Final: {finalScore}");

            OnScoreUpdated?.Invoke(finalScore);
            return finalScore;
        }

        /// <summary>
        /// Get difficulty score multiplier
        /// </summary>
        public float GetDifficultyMultiplier(DifficultyLevel difficulty)
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    return 1.0f;
                case DifficultyLevel.Medium:
                    return 1.5f;
                case DifficultyLevel.Hard:
                    return 2.0f;
                case DifficultyLevel.Expert:
                    return 3.0f;
                default:
                    return 1.0f;
            }
        }

        /// <summary>
        /// Calculate combo multiplier (for consecutive quick completions)
        /// </summary>
        public float GetComboMultiplier(int consecutiveFirstAttempts)
        {
            return 1.0f + (consecutiveFirstAttempts * 0.1f);
        }

        /// <summary>
        /// Get rank based on score
        /// </summary>
        public string GetRankByScore(int score)
        {
            if (score >= 5000)
                return "S RANK - LEGENDARY";
            else if (score >= 4000)
                return "A RANK - ELITE";
            else if (score >= 3000)
                return "B RANK - EXPERT";
            else if (score >= 2000)
                return "C RANK - SKILLED";
            else if (score >= 1000)
                return "D RANK - NOVICE";
            else
                return "F RANK - BEGINNER";
        }

        /// <summary>
        /// Get color for rank
        /// </summary>
        public Color GetRankColor(string rank)
        {
            if (rank.Contains("S RANK"))
                return Color.yellow;
            else if (rank.Contains("A RANK"))
                return new Color(1f, 0.5f, 0f); // Orange
            else if (rank.Contains("B RANK"))
                return new Color(0f, 1f, 0f); // Green
            else if (rank.Contains("C RANK"))
                return GameConstants.NEON_CYAN;
            else if (rank.Contains("D RANK"))
                return GameConstants.NEON_MAGENTA;
            else
                return Color.gray;
        }
    }
}
