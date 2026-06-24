using UnityEngine;
using System.Collections.Generic;
using Hack4Fun.Data;

namespace Hack4Fun.Data
{
    /// <summary>
    /// Stores individual level configuration
    /// </summary>
    [System.Serializable]
    public class LevelConfig
    {
        [SerializeField] public int levelNumber;
        [SerializeField] public string targetPassword;
        [SerializeField] public string systemName;
        [SerializeField] public string systemDescription;
        [SerializeField] public float timeLimit;
        [SerializeField] public DifficultyLevel difficulty;
        [SerializeField] public AttackType allowedAttackType;
        [SerializeField] public int maxAttempts;
        [SerializeField] public float scoreMultiplier;
        [SerializeField] public string hint1;
        [SerializeField] public string hint2;

        public LevelConfig()
        {
            maxAttempts = 999; // Effectively unlimited
            scoreMultiplier = 1f;
        }
    }

    /// <summary>
    /// Manages all level data for the game.
    /// This is the database of all 20 levels.
    /// </summary>
    public class LevelData : MonoBehaviour
    {
        private static LevelData instance;
        private List<LevelConfig> levels = new List<LevelConfig>();

        public static LevelData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<LevelData>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject("LevelData");
                        instance = obj.AddComponent<LevelData>();
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
            InitializeLevels();
        }

        /// <summary>
        /// Initialize all 20 levels with their configurations
        /// </summary>
        private void InitializeLevels()
        {
            // EASY LEVELS (1-5): 3-4 character passwords, 5 min limit
            levels.Add(new LevelConfig
            {
                levelNumber = 1,
                targetPassword = "abc",
                systemName = "TRAINING_SYSTEM",
                systemDescription = "Welcome to HACK4FUN. This is a training system. Breach it.",
                timeLimit = 300f,
                difficulty = DifficultyLevel.Easy,
                allowedAttackType = AttackType.BruteForce,
                maxAttempts = 999,
                scoreMultiplier = 1.0f,
                hint1 = "Try starting with 'aaa' and increment",
                hint2 = "The password is 3 letters long"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 2,
                targetPassword = "xyz",
                systemName = "FIREWALL_ALPHA",
                systemDescription = "Firewall Alpha is protecting the data vault. Crack it.",
                timeLimit = 300f,
                difficulty = DifficultyLevel.Easy,
                allowedAttackType = AttackType.BruteForce,
                maxAttempts = 999,
                scoreMultiplier = 1.1f,
                hint1 = "End of alphabet letters",
                hint2 = "3 characters: x, y, z"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 3,
                targetPassword = "hack",
                systemName = "DATABASE_CORE",
                systemDescription = "Access the database core. 4 character password.",
                timeLimit = 300f,
                difficulty = DifficultyLevel.Easy,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 1.2f,
                hint1 = "Related to this game's title",
                hint2 = "Four letter word: h-a-c-k"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 4,
                targetPassword = "neon",
                systemName = "TERMINAL_BETA",
                systemDescription = "Terminal Beta guards the neon city networks. Penetrate it.",
                timeLimit = 300f,
                difficulty = DifficultyLevel.Easy,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 1.3f,
                hint1 = "Related to cyberpunk aesthetic",
                hint2 = "Bright glowing lights"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 5,
                targetPassword = "cyber",
                systemName = "SECURITY_DELTA",
                systemDescription = "Security Delta - protecting the mainframe. Bypass it.",
                timeLimit = 300f,
                difficulty = DifficultyLevel.Easy,
                allowedAttackType = AttackType.Mixed,
                maxAttempts = 999,
                scoreMultiplier = 1.4f,
                hint1 = "Technology-related word",
                hint2 = "Five letters: c-y-b-e-r"
            });

            // MEDIUM LEVELS (6-10): 5-6 character passwords, 3-4 min limit
            levels.Add(new LevelConfig
            {
                levelNumber = 6,
                targetPassword = "matrix",
                systemName = "NEURAL_NETWORK_01",
                systemDescription = "Neural Network 01 - AI controlled. Hack the algorithm.",
                timeLimit = 240f,
                difficulty = DifficultyLevel.Medium,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 1.5f,
                hint1 = "Famous sci-fi movie reference",
                hint2 = "Six letters: m-a-t-r-i-x"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 7,
                targetPassword = "digital",
                systemName = "SECURE_VAULT_02",
                systemDescription = "The Digital Vault - protecting encrypted assets.",
                timeLimit = 240f,
                difficulty = DifficultyLevel.Medium,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 1.6f,
                hint1 = "Technology and electronics related",
                hint2 = "Seven letters"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 8,
                targetPassword = "shadow",
                systemName = "DARK_WEB_GATEWAY",
                systemDescription = "Dark Web Gateway - in the shadows of the internet.",
                timeLimit = 240f,
                difficulty = DifficultyLevel.Medium,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 1.7f,
                hint1 = "Darkness, hidden from light",
                hint2 = "Six letters: s-h-a-d-o-w"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 9,
                targetPassword = "signal",
                systemName = "QUANTUM_PROCESSOR",
                systemDescription = "Quantum Processor - sending encrypted signals.",
                timeLimit = 240f,
                difficulty = DifficultyLevel.Medium,
                allowedAttackType = AttackType.Mixed,
                maxAttempts = 999,
                scoreMultiplier = 1.8f,
                hint1 = "Radio or communication signal",
                hint2 = "Six letters"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 10,
                targetPassword = "cipher",
                systemName = "ENCRYPTION_FORTRESS",
                systemDescription = "Encryption Fortress - protecting codes within codes.",
                timeLimit = 240f,
                difficulty = DifficultyLevel.Medium,
                allowedAttackType = AttackType.Mixed,
                maxAttempts = 999,
                scoreMultiplier = 1.9f,
                hint1 = "Secret code or encryption method",
                hint2 = "Six letters: c-i-p-h-e-r"
            });

            // HARD LEVELS (11-15): 7-8 character passwords, 2-3 min limit
            levels.Add(new LevelConfig
            {
                levelNumber = 11,
                targetPassword = "phantom",
                systemName = "GHOST_NETWORK",
                systemDescription = "Ghost Network - invisible but everywhere.",
                timeLimit = 180f,
                difficulty = DifficultyLevel.Hard,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 2.0f,
                hint1 = "A ghost, something invisible",
                hint2 = "Seven letters"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 12,
                targetPassword = "decrypt",
                systemName = "CLASSIFIED_SERVER",
                systemDescription = "Classified Server - top secret information stored here.",
                timeLimit = 180f,
                difficulty = DifficultyLevel.Hard,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 2.1f,
                hint1 = "To decode or unlock a message",
                hint2 = "Seven letters: d-e-c-r-y-p-t"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 13,
                targetPassword = "firewall",
                systemName = "SENTINEL_CORE",
                systemDescription = "Sentinel Core - the ultimate defense system.",
                timeLimit = 180f,
                difficulty = DifficultyLevel.Hard,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 2.2f,
                hint1 = "Network security protection",
                hint2 = "Eight letters: f-i-r-e-w-a-l-l"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 14,
                targetPassword = "malware",
                systemName = "CORRUPTED_SECTOR",
                systemDescription = "Corrupted Sector - infected with malicious code.",
                timeLimit = 180f,
                difficulty = DifficultyLevel.Hard,
                allowedAttackType = AttackType.Mixed,
                maxAttempts = 999,
                scoreMultiplier = 2.3f,
                hint1 = "Harmful computer software",
                hint2 = "Seven letters"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 15,
                targetPassword = "terminal",
                systemName = "MAINFRAME_NEXUS",
                systemDescription = "Mainframe Nexus - the heart of all systems.",
                timeLimit = 180f,
                difficulty = DifficultyLevel.Hard,
                allowedAttackType = AttackType.Mixed,
                maxAttempts = 999,
                scoreMultiplier = 2.4f,
                hint1 = "Computer interface or endpoint",
                hint2 = "Eight letters"
            });

            // EXPERT LEVELS (16-20): 8-10 character passwords, 90s-2 min limit
            levels.Add(new LevelConfig
            {
                levelNumber = 16,
                targetPassword = "protocol",
                systemName = "SUPREME_COMMAND",
                systemDescription = "Supreme Command - the final frontier of hacking.",
                timeLimit = 120f,
                difficulty = DifficultyLevel.Expert,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 2.5f,
                hint1 = "A set of procedures or rules",
                hint2 = "Eight letters: p-r-o-t-o-c-o-l"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 17,
                targetPassword = "synthetic",
                systemName = "AI_OVERLORD",
                systemDescription = "AI Overlord - artificial intelligence in control.",
                timeLimit = 120f,
                difficulty = DifficultyLevel.Expert,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 2.6f,
                hint1 = "Not natural, artificially made",
                hint2 = "Nine letters"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 18,
                targetPassword = "blackgate",
                systemName = "MIDNIGHT_FORTRESS",
                systemDescription = "Midnight Fortress - guarded by the darkness itself.",
                timeLimit = 120f,
                difficulty = DifficultyLevel.Expert,
                allowedAttackType = AttackType.Dictionary,
                maxAttempts = 999,
                scoreMultiplier = 2.7f,
                hint1 = "Black + Gate = Two words",
                hint2 = "Nine letters: b-l-a-c-k-g-a-t-e"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 19,
                targetPassword = "nexuscore",
                systemName = "QUANTUM_SINGULARITY",
                systemDescription = "Quantum Singularity - reality breaks here.",
                timeLimit = 120f,
                difficulty = DifficultyLevel.Expert,
                allowedAttackType = AttackType.Mixed,
                maxAttempts = 999,
                scoreMultiplier = 2.8f,
                hint1 = "Central connection point",
                hint2 = "Nine letters"
            });

            levels.Add(new LevelConfig
            {
                levelNumber = 20,
                targetPassword = "infinitykey",
                systemName = "FINAL_NEXUS",
                systemDescription = "Final Nexus - the ultimate system. Ultimate challenge.",
                timeLimit = 120f,
                difficulty = DifficultyLevel.Expert,
                allowedAttackType = AttackType.Mixed,
                maxAttempts = 999,
                scoreMultiplier = 3.0f,
                hint1 = "Infinity + Key = Two words or one concept",
                hint2 = "Eleven letters: the ultimate password"
            });

            Debug.Log($"[LevelData] Initialized {levels.Count} levels successfully!");
        }

        /// <summary>
        /// Get a specific level by number (1-20)
        /// </summary>
        public LevelConfig GetLevel(int levelNumber)
        {
            if (levelNumber < 1 || levelNumber > levels.Count)
            {
                Debug.LogError($"[LevelData] Level {levelNumber} does not exist!");
                return null;
            }
            return levels[levelNumber - 1];
        }

        /// <summary>
        /// Get all levels
        /// </summary>
        public List<LevelConfig> GetAllLevels()
        {
            return new List<LevelConfig>(levels);
        }

        /// <summary>
        /// Get total number of levels
        /// </summary>
        public int GetTotalLevels()
        {
            return levels.Count;
        }

        /// <summary>
        /// Get levels by difficulty
        /// </summary>
        public List<LevelConfig> GetLevelsByDifficulty(DifficultyLevel difficulty)
        {
            return levels.FindAll(l => l.difficulty == difficulty);
        }
    }
}
