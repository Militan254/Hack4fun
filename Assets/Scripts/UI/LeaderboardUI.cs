using UnityEngine;
using System.Collections.Generic;
using Hack4Fun.Data;

namespace Hack4Fun.UI
{
    /// <summary>
    /// Leaderboard UI component
    /// </summary>
    public class LeaderboardUI : MonoBehaviour
    {
        [SerializeField] private Transform leaderboardItemContainer;
        [SerializeField] private GameObject leaderboardItemPrefab;

        private List<PlayerStats> topScores = new List<PlayerStats>();

        private void Start()
        {
            LoadLeaderboard();
        }

        /// <summary>
        /// Load leaderboard from data
        /// </summary>
        private void LoadLeaderboard()
        {
            // This would typically load from PlayerPrefs or a database
            // For now, we'll show placeholder
            Debug.Log("[LeaderboardUI] Loading leaderboard...");
        }

        /// <summary>
        /// Display leaderboard
        /// </summary>
        public void DisplayLeaderboard()
        {
            foreach (PlayerStats player in topScores)
            {
                GameObject item = Instantiate(leaderboardItemPrefab, leaderboardItemContainer);
                Text rankText = item.GetComponentInChildren<Text>();
                rankText.text = $"{player.rank}. {player.playerName} - {player.highScore}";
            }
        }

        /// <summary>
        /// Add score to leaderboard
        /// </summary>
        public void AddScore(string playerName, int score)
        {
            PlayerStats newStat = new PlayerStats { playerName = playerName, highScore = score };
            topScores.Add(newStat);
            topScores.Sort((a, b) => b.highScore.CompareTo(a.highScore));

            if (topScores.Count > 10)
                topScores.RemoveAt(topScores.Count - 1);
        }
    }
}
