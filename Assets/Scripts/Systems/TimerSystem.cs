using UnityEngine;
using System;
using Hack4Fun.Data;

namespace Hack4Fun.Systems
{
    /// <summary>
    /// Manages game timer for each level
    /// </summary>
    public class TimerSystem : MonoBehaviour
    {
        private float timeRemaining;
        private float totalTime;
        private bool isRunning = false;

        public delegate void TimerTickCallback(float timeRemaining, float totalTime);
        public delegate void TimerExpiredCallback();

        public event TimerTickCallback OnTimerTick;
        public event TimerExpiredCallback OnTimerExpired;

        /// <summary>
        /// Start the timer for a level
        /// </summary>
        public void StartTimer(float duration)
        {
            totalTime = duration;
            timeRemaining = duration;
            isRunning = true;
            Debug.Log($"[TimerSystem] Timer started for {duration} seconds");
        }

        /// <summary>
        /// Stop the timer
        /// </summary>
        public void StopTimer()
        {
            isRunning = false;
            Debug.Log($"[TimerSystem] Timer stopped. Time remaining: {timeRemaining}");
        }

        /// <summary>
        /// Pause the timer
        /// </summary>
        public void PauseTimer()
        {
            isRunning = false;
        }

        /// <summary>
        /// Resume the timer
        /// </summary>
        public void ResumeTimer()
        {
            isRunning = true;
        }

        /// <summary>
        /// Reset the timer
        /// </summary>
        public void ResetTimer()
        {
            timeRemaining = 0;
            totalTime = 0;
            isRunning = false;
        }

        /// <summary>
        /// Get current time remaining
        /// </summary>
        public float GetTimeRemaining()
        {
            return Mathf.Max(0, timeRemaining);
        }

        /// <summary>
        /// Get time elapsed
        /// </summary>
        public float GetTimeElapsed()
        {
            return totalTime - timeRemaining;
        }

        /// <summary>
        /// Get progress (0-1)
        /// </summary>
        public float GetProgress()
        {
            return (totalTime - timeRemaining) / totalTime;
        }

        /// <summary>
        /// Check if time is running out (less than 20%)
        /// </summary>
        public bool IsTimeRunningOut()
        {
            return timeRemaining <= totalTime * 0.2f;
        }

        /// <summary>
        /// Format time as MM:SS
        /// </summary>
        public string GetFormattedTime()
        {
            int minutes = (int)(timeRemaining / 60f);
            int seconds = (int)(timeRemaining % 60f);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        /// <summary>
        /// Format time with centiseconds MM:SS:CC
        /// </summary>
        public string GetFormattedTimeDetailed()
        {
            int minutes = (int)(timeRemaining / 60f);
            int seconds = (int)(timeRemaining % 60f);
            int centiseconds = (int)((timeRemaining * 100f) % 100f);
            return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, centiseconds);
        }

        private void Update()
        {
            if (!isRunning)
                return;

            timeRemaining -= Time.deltaTime;

            OnTimerTick?.Invoke(GetTimeRemaining(), totalTime);

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isRunning = false;
                OnTimerExpired?.Invoke();
                Debug.Log("[TimerSystem] Timer expired!");
            }
        }

        /// <summary>
        /// Add bonus time to the timer
        /// </summary>
        public void AddBonusTime(float bonusSeconds)
        {
            timeRemaining += bonusSeconds;
            Debug.Log($"[TimerSystem] Added {bonusSeconds} seconds. New time: {timeRemaining}");
        }

        /// <summary>
        /// Subtract time from the timer (penalty)
        /// </summary>
        public void SubtractTime(float penaltySeconds)
        {
            timeRemaining -= penaltySeconds;
            timeRemaining = Mathf.Max(0, timeRemaining);
            Debug.Log($"[TimerSystem] Subtracted {penaltySeconds} seconds. New time: {timeRemaining}");
        }
    }
}
