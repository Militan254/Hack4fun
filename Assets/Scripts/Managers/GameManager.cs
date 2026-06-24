using UnityEngine;
using Hack4Fun.Data;
using Hack4Fun.Systems;

namespace Hack4Fun.Managers
{
    /// <summary>
    /// Main game manager - handles overall game flow and state
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private GameState currentState = GameState.Menu;
        private int currentLevelNumber = 1;
        private int totalScore = 0;
        private int levelsCompleted = 0;

        public delegate void GameStateChangeCallback(GameState newState);
        public event GameStateChangeCallback OnGameStateChanged;

        public delegate void LevelCompleteCallback(int levelNumber, int score);
        public event LevelCompleteCallback OnLevelComplete;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("[GameManager] Initialized");
        }

        /// <summary>
        /// Start a new game
        /// </summary>
        public void StartNewGame()
        {
            currentLevelNumber = 1;
            totalScore = 0;
            levelsCompleted = 0;
            SetGameState(GameState.Playing);
            Debug.Log("[GameManager] Game started!");
        }

        /// <summary>
        /// Load a specific level
        /// </summary>
        public void LoadLevel(int levelNumber)
        {
            if (levelNumber < 1 || levelNumber > GameConstants.TOTAL_LEVELS)
            {
                Debug.LogError($"[GameManager] Invalid level: {levelNumber}");
                return;
            }
            currentLevelNumber = levelNumber;
            SetGameState(GameState.Playing);
            Debug.Log($"[GameManager] Loading level {levelNumber}");
        }

        /// <summary>
        /// Mark level as complete and award points
        /// </summary>
        public void CompleteLevelWithScore(int score)
        {
            totalScore += score;
            levelsCompleted++;

            OnLevelComplete?.Invoke(currentLevelNumber, score);
            Debug.Log($"[GameManager] Level {currentLevelNumber} completed! Score: {score} | Total: {totalScore}");

            if (currentLevelNumber >= GameConstants.TOTAL_LEVELS)
            {
                CompleteGame();
            }
            else
            {
                SetGameState(GameState.LevelComplete);
            }
        }

        /// <summary>
        /// Progress to next level
        /// </summary>
        public void NextLevel()
        {
            if (currentLevelNumber < GameConstants.TOTAL_LEVELS)
            {
                currentLevelNumber++;
                SetGameState(GameState.Playing);
                Debug.Log($"[GameManager] Progressing to level {currentLevelNumber}");
            }
        }

        /// <summary>
        /// Complete the entire game
        /// </summary>
        public void CompleteGame()
        {
            SetGameState(GameState.GameOver);
            Debug.Log($"[GameManager] GAME COMPLETE! Total Score: {totalScore}");
        }

        /// <summary>
        /// Pause the game
        /// </summary>
        public void PauseGame()
        {
            SetGameState(GameState.Paused);
            Time.timeScale = 0f;
            Debug.Log("[GameManager] Game paused");
        }

        /// <summary>
        /// Resume the game
        /// </summary>
        public void ResumeGame()
        {
            SetGameState(GameState.Playing);
            Time.timeScale = 1f;
            Debug.Log("[GameManager] Game resumed");
        }

        /// <summary>
        /// Return to main menu
        /// </summary>
        public void ReturnToMenu()
        {
            SetGameState(GameState.Menu);
            Time.timeScale = 1f;
            currentLevelNumber = 1;
            totalScore = 0;
            levelsCompleted = 0;
            Debug.Log("[GameManager] Returned to menu");
        }

        /// <summary>
        /// Change game state
        /// </summary>
        private void SetGameState(GameState newState)
        {
            currentState = newState;
            OnGameStateChanged?.Invoke(newState);
            Debug.Log($"[GameManager] Game state changed to: {newState}");
        }

        // Getters
        public GameState GetCurrentState() => currentState;
        public int GetCurrentLevel() => currentLevelNumber;
        public int GetTotalScore() => totalScore;
        public int GetLevelsCompleted() => levelsCompleted;
        public float GetProgressPercentage() => (levelsCompleted / (float)GameConstants.TOTAL_LEVELS) * 100f;
    }
}
