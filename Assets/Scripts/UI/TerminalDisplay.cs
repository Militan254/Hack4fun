using UnityEngine;
using UnityEngine.UI;
using Hack4Fun.Data;

namespace Hack4Fun.UI
{
    /// <summary>
    /// Terminal display component for cyberpunk aesthetic
    /// </summary>
    public class TerminalDisplay : MonoBehaviour
    {
        [SerializeField] private Text terminalOutputText;
        [SerializeField] private Image terminalBackgroundImage;

        private void Start()
        {
            ApplyTerminalStyle();
        }

        /// <summary>
        /// Apply terminal styling
        /// </summary>
        private void ApplyTerminalStyle()
        {
            // Set background color to dark cyberpunk
            terminalBackgroundImage.color = GameConstants.DARK_BG;

            // Set text to neon cyan (typical terminal color)
            terminalOutputText.color = GameConstants.NEON_CYAN;
            terminalOutputText.font = Resources.Load<Font>("Fonts/Terminal");
        }

        /// <summary>
        /// Add text to terminal with glitch effect
        /// </summary>
        public void PrintToTerminal(string text)
        {
            terminalOutputText.text += text + "\n";

            // Optional: Add glitch effect
            if (Random.value < GameConstants.GLITCH_EFFECT_CHANCE)
            {
                StartCoroutine(GlitchEffect());
            }
        }

        /// <summary>
        /// Clear terminal
        /// </summary>
        public void ClearTerminal()
        {
            terminalOutputText.text = "";
        }

        /// <summary>
        /// Simple glitch effect coroutine
        /// </summary>
        private System.Collections.IEnumerator GlitchEffect()
        {
            Color originalColor = terminalOutputText.color;
            terminalOutputText.color = GameConstants.NEON_MAGENTA;
            yield return new WaitForSeconds(0.1f);
            terminalOutputText.color = originalColor;
        }
    }
}
