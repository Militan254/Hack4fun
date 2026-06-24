using UnityEngine;
using Hack4Fun.Data;

namespace Hack4Fun.Data
{
    /// <summary>
    /// Stores player statistics and progress
    /// </summary>
    [System.Serializable]
    public class PlayerStats
    {
        public string playerName = "Player";
        public int highScore = 0;
        public int rank = 0;
        public int levelsCompleted = 0;
        public float totalPlayTime = 0f;
        public int[] levelBestTimes = new int[GameConstants.TOTAL_LEVELS];
        public int[] levelBestScores = new int[GameConstants.TOTAL_LEVELS];
    }

    /// <summary>
    /// Manager for player data
    /// </summary>
    public class PlayerDataManager : MonoBehaviour
    {
        private static PlayerDataManager instance;
        private PlayerStats currentPlayerStats;

        public static PlayerDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<PlayerDataManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("PlayerDataManager");
                        instance = obj.AddComponent<PlayerDataManager>();
                    }
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPlayerData();
        }

        /// <summary>
        /// Load player data from PlayerPrefs
        /// </summary>
        private void LoadPlayerData()
        {
            string json = PlayerPrefs.GetString("PlayerStats", "");
            if (string.IsNullOrEmpty(json))
            {
                currentPlayerStats = new PlayerStats();
            }
            else
            {
                currentPlayerStats = JsonUtility.FromJson<PlayerStats>(json);
            }
            Debug.Log("[PlayerDataManager] Player data loaded");
        }

        /// <summary>
        /// Save player data to PlayerPrefs
        /// </summary>
        public void SavePlayerData()
        {
            string json = JsonUtility.ToJson(currentPlayerStats);
            PlayerPrefs.SetString("PlayerStats", json);
            PlayerPrefs.Save();
            Debug.Log("[PlayerDataManager] Player data saved");
        }

        /// <summary>
        /// Get current player stats
        /// </summary>
        public PlayerStats GetCurrentStats() => currentPlayerStats;

        /// <summary>
        /// Update level best score
        /// </summary>
        public void UpdateLevelBestScore(int levelNumber, int score)
        {
            if (levelNumber < 1 || levelNumber > GameConstants.TOTAL_LEVELS)
                return;

            int index = levelNumber - 1;
            if (score > currentPlayerStats.levelBestScores[index])
            {
                currentPlayerStats.levelBestScores[index] = score;
                SavePlayerData();
            }
        }

        /// <summary>
        /// Update high score
        /// </summary>
        public void UpdateHighScore(int score)
        {
            if (score > currentPlayerStats.highScore)
            {
                currentPlayerStats.highScore = score;
                SavePlayerData();
            }
        }
    }
}
