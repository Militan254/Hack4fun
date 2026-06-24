using UnityEngine;
using UnityEngine.UI;
using Hack4Fun.Systems;

namespace Hack4Fun.UI
{
    /// <summary>
    /// UI component for displaying the timer
    /// </summary>
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        [SerializeField] private Image timerFillImage;

        private TimerSystem timerSystem;

        private void Start()
        {
            timerSystem = GetComponent<TimerSystem>();
            if (timerSystem != null)
            {
                timerSystem.OnTimerTick += UpdateTimerDisplay;
            }
        }

        /// <summary>
        /// Update timer display
        /// </summary>
        private void UpdateTimerDisplay(float timeRemaining, float totalTime)
        {
            timerText.text = FormatTime(timeRemaining);

            // Update fill bar
            float fillAmount = timeRemaining / totalTime;
            timerFillImage.fillAmount = fillAmount;

            // Change color based on time remaining
            if (fillAmount > 0.5f)
                timerFillImage.color = Color.green;
            else if (fillAmount > 0.2f)
                timerFillImage.color = Color.yellow;
            else
                timerFillImage.color = Color.red;
        }

        /// <summary>
        /// Format time as MM:SS
        /// </summary>
        private string FormatTime(float seconds)
        {
            int minutes = (int)(seconds / 60f);
            int secs = (int)(seconds % 60f);
            return string.Format("{0:00}:{1:00}", minutes, secs);
        }
    }
}
