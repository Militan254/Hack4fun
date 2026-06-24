using UnityEngine;
using Hack4Fun.Data;
using Hack4Fun.Systems;

namespace Hack4Fun.Managers
{
    /// <summary>
    /// Manages individual level gameplay and state
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        private LevelConfig currentLevel;
        private int attemptCount = 0;
        private bool levelComplete = false;

        private HackingSystem hackingSystem;
        private PasswordValidator passwordValidator;
        private ScoreSystem scoreSystem;
        private TimerSystem timerSystem;

        public delegate void LevelEventCallback(string message);
        public event LevelEventCallback OnLevelStateChanged;

        public delegate void AttemptCallback(int attempts, bool correct);
        public event AttemptCallback OnAttemptMade;

        private void Start()
        {
            hackingSystem = GetComponent<HackingSystem>();
            passwordValidator = GetComponent<PasswordValidator>();
            scoreSystem = GetComponent<ScoreSystem>();
            timerSystem = GetComponent<TimerSystem>();
        }

        /// <summary>
        /// Initialize a level
        /// </summary>
        public void InitializeLevel(int levelNumber)
        {
            currentLevel = LevelData.Instance.GetLevel(levelNumber);
            if (currentLevel == null)
            {
                Debug.LogError($"[LevelManager] Failed to load level {levelNumber}");
                return;
            }

            attemptCount = 0;
            levelComplete = false;
            hackingSystem.ResetCounters();

            // Start timer
            timerSystem.StartTimer(currentLevel.timeLimit);
            timerSystem.OnTimerExpired += HandleTimeExpired;

            Debug.Log($"[LevelManager] Level {levelNumber} initialized - Target: {currentLevel.targetPassword}");
            OnLevelStateChanged?.Invoke($"Breaching {currentLevel.systemName}...");
        }

        /// <summary>
        /// Submit a password guess
        /// </summary>
        public void SubmitGuess(string guess)
        {
            if (levelComplete || currentLevel == null)
                return;

            attemptCount++;
            OnAttemptMade?.Invoke(attemptCount, false);

            passwordValidator.ValidateGuess(guess, currentLevel.targetPassword);
        }

        /// <summary>
        /// Handle correct password submission
        /// </summary>
        public void HandleCorrectPassword()
        {
            levelComplete = true;
            timerSystem.StopTimer();

            float timeRemaining = timerSystem.GetTimeRemaining();
            float difficultyMultiplier = scoreSystem.GetDifficultyMultiplier(currentLevel.difficulty);
            int score = scoreSystem.CalculateScore(timeRemaining, attemptCount, currentLevel.difficulty, difficultyMultiplier);

            OnLevelStateChanged?.Invoke($"Level Complete! Score: {score}");
            GameManager.Instance.CompleteLevelWithScore(score);

            Debug.Log($"[LevelManager] Level {currentLevel.levelNumber} completed with score {score}!");
        }

        /// <summary>
        /// Handle timer expiration
        /// </summary>
        private void HandleTimeExpired()
        {
            if (levelComplete)
                return;

            levelComplete = true;
            OnLevelStateChanged?.Invoke("TIME'S UP! SYSTEM BREACH FAILED!");
            Debug.Log($"[LevelManager] Level {currentLevel.levelNumber} - Time expired!");
        }

        /// <summary>
        /// Get hint
        /// </summary>
        public string GetHint(int hintNumber)
        {
            if (hintNumber == 1)
                return currentLevel.hint1;
            else if (hintNumber == 2)
                return currentLevel.hint2;
            return "No more hints available";
        }

        // Getters
        public LevelConfig GetCurrentLevel() => currentLevel;
        public int GetAttemptCount() => attemptCount;
        public bool IsLevelComplete() => levelComplete;
        public float GetTimeRemaining() => timerSystem.GetTimeRemaining();
    }
}
