using UnityEngine;
using System.Collections.Generic;

namespace Hack4Fun.Data
{
    /// <summary>
    /// Global constants used throughout the game.
    /// Modify these values to balance gameplay.
    /// </summary>
    public static class GameConstants
    {
        // Game Settings
        public const int TOTAL_LEVELS = 20;
        public const string GAME_TITLE = "HACK4FUN";
        public const string VERSION = "1.0.0";

        // Cyberpunk Aesthetic Colors (Hex: #00FFFF, #FF00FF, #0A0E27)
        public static readonly Color NEON_CYAN = new Color(0f, 1f, 1f, 1f);      // #00FFFF
        public static readonly Color NEON_MAGENTA = new Color(1f, 0f, 1f, 1f);   // #FF00FF
        public static readonly Color DARK_BG = new Color(0.039f, 0.056f, 0.153f, 1f); // #0A0E27
        public static readonly Color SUCCESS_GREEN = new Color(0f, 1f, 0f, 1f);
        public static readonly Color FAIL_RED = new Color(1f, 0f, 0f, 1f);

        // Scoring Multipliers
        public const float TIME_BONUS_MULTIPLIER = 1.5f;
        public const float ATTEMPT_PENALTY = 100f;
        public const int BASE_POINTS = 1000;
        public const float PERFECT_ATTEMPT_BONUS = 500f;

        // Attack Types
        public const string ATTACK_BRUTE_FORCE = "BRUTE_FORCE";
        public const string ATTACK_DICTIONARY = "DICTIONARY";
        public const string ATTACK_MIXED = "MIXED";

        // Audio Tags
        public const string AUDIO_UI_CORRECT = "ui_correct";
        public const string AUDIO_UI_WRONG = "ui_wrong";
        public const string AUDIO_LEVEL_COMPLETE = "level_complete";
        public const string AUDIO_GAME_COMPLETE = "game_complete";
        public const string AUDIO_MENU_THEME = "menu_theme";
        public const string AUDIO_GAMEPLAY_THEME = "gameplay_theme";

        // UI Settings
        public const float TERMINAL_GLOW_INTENSITY = 2.5f;
        public const float GLITCH_EFFECT_CHANCE = 0.15f;

        // Difficulty Modifiers
        public const float EASY_TIME_MULTIPLIER = 1.0f;
        public const float MEDIUM_TIME_MULTIPLIER = 0.75f;
        public const float HARD_TIME_MULTIPLIER = 0.5f;
        public const float EXPERT_TIME_MULTIPLIER = 0.35f;

        // Hints
        public const int HINTS_PER_LEVEL = 2;
        public const string HINT_REVEAL_PARTIAL = "REVEAL_PARTIAL";
        public const string HINT_SHOW_LENGTH = "SHOW_LENGTH";
    }

    /// <summary>
    /// Enum for game difficulty levels
    /// </summary>
    public enum DifficultyLevel
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
        Expert = 3
    }

    /// <summary>
    /// Enum for attack types
    /// </summary>
    public enum AttackType
    {
        BruteForce,
        Dictionary,
        Mixed
    }

    /// <summary>
    /// Enum for game states
    /// </summary>
    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        LevelComplete,
        GameOver,
        Results
    }
}
