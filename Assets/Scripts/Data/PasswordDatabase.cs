using UnityEngine;
using System.Collections.Generic;
using Hack4Fun.Data;

namespace Hack4Fun.Data
{
    /// <summary>
    /// Password database for all levels
    /// </summary>
    public class PasswordDatabase : MonoBehaviour
    {
        private static PasswordDatabase instance;
        private Dictionary<int, string> levelPasswords = new Dictionary<int, string>();

        public static PasswordDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<PasswordDatabase>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("PasswordDatabase");
                        instance = obj.AddComponent<PasswordDatabase>();
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
            InitializePasswords();
        }

        /// <summary>
        /// Initialize all password data from LevelData
        /// </summary>
        private void InitializePasswords()
        {
            List<LevelConfig> allLevels = LevelData.Instance.GetAllLevels();
            foreach (LevelConfig level in allLevels)
            {
                levelPasswords[level.levelNumber] = level.targetPassword;
            }
            Debug.Log($"[PasswordDatabase] Initialized {levelPasswords.Count} passwords");
        }

        /// <summary>
        /// Get password for a level
        /// </summary>
        public string GetPassword(int levelNumber)
        {
            if (levelPasswords.ContainsKey(levelNumber))
            {
                return levelPasswords[levelNumber];
            }
            Debug.LogError($"[PasswordDatabase] Password for level {levelNumber} not found!");
            return "";
        }

        /// <summary>
        /// Check if password is correct
        /// </summary>
        public bool VerifyPassword(int levelNumber, string guess)
        {
            return GetPassword(levelNumber).ToLower() == guess.ToLower();
        }
    }
}
