using UnityEngine;
using UnityEngine.UI;
using Hack4Fun.Data;
using Hack4Fun.Systems;

namespace Hack4Fun.UI
{
    /// <summary>
    /// Main UI controller for the game interface
    /// </summary>
    public class UIController : MonoBehaviour
    {
        [SerializeField] private InputField passwordInputField;
        [SerializeField] private Text feedbackText;
        [SerializeField] private Text attemptText;
        [SerializeField] private Text systemNameText;
        [SerializeField] private Button submitButton;
        [SerializeField] private Button hint1Button;
        [SerializeField] private Button hint2Button;

        private LevelManager levelManager;
        private PasswordValidator passwordValidator;
        private bool canSubmit = true;

        private void Start()
        {
            levelManager = GetComponent<LevelManager>();
            passwordValidator = GetComponent<PasswordValidator>();

            // Hook up button events
            submitButton.onClick.AddListener(SubmitPassword);
            hint1Button.onClick.AddListener(() => ShowHint(1));
            hint2Button.onClick.AddListener(() => ShowHint(2));

            // Hook up input field
            passwordInputField.onEndEdit.AddListener(OnInputFieldSubmit);

            // Subscribe to validation events
            passwordValidator.OnValidationComplete += HandleValidationResult;

            // Style UI with cyberpunk colors
            ApplyCyberpunkStyle();
        }

        /// <summary>
        /// Submit password attempt
        /// </summary>
        public void SubmitPassword()
        {
            if (!canSubmit)
                return;

            string guess = passwordInputField.text.Trim();

            if (string.IsNullOrEmpty(guess))
            {
                feedbackText.text = "Enter a password first!";
                feedbackText.color = GameConstants.FAIL_RED;
                return;
            }

            canSubmit = false;
            passwordInputField.interactable = false;
            levelManager.SubmitGuess(guess);
        }

        /// <summary>
        /// Handle validation result
        /// </summary>
        private void HandleValidationResult(bool isCorrect, string feedback)
        {
            feedbackText.text = feedback;
            feedbackText.color = isCorrect ? GameConstants.SUCCESS_GREEN : GameConstants.FAIL_RED;

            if (isCorrect)
            {
                levelManager.HandleCorrectPassword();
            }
            else
            {
                passwordInputField.text = "";
                passwordInputField.interactable = true;
                canSubmit = true;
            }
        }

        /// <summary>
        /// Handle input field submission (Enter key)
        /// </summary>
        private void OnInputFieldSubmit(string text)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SubmitPassword();
            }
        }

        /// <summary>
        /// Show hint
        /// </summary>
        public void ShowHint(int hintNumber)
        {
            string hint = levelManager.GetHint(hintNumber);
            feedbackText.text = "HINT: " + hint;
            feedbackText.color = GameConstants.NEON_CYAN;
        }

        /// <summary>
        /// Update UI with level information
        /// </summary>
        public void UpdateLevelDisplay(LevelConfig level)
        {
            systemNameText.text = level.systemName;
            feedbackText.text = level.systemDescription;
            feedbackText.color = GameConstants.NEON_CYAN;
            passwordInputField.text = "";
            passwordInputField.interactable = true;
            canSubmit = true;
        }

        /// <summary>
        /// Update attempt counter display
        /// </summary>
        public void UpdateAttemptDisplay(int attempts)
        {
            attemptText.text = $"ATTEMPTS: {attempts}";
        }

        /// <summary>
        /// Apply cyberpunk color scheme to UI
        /// </summary>
        private void ApplyCyberpunkStyle()
        {
            // Set text colors
            systemNameText.color = GameConstants.NEON_MAGENTA;
            attemptText.color = GameConstants.NEON_CYAN;

            // Set button colors
            ColorBlock submitColors = submitButton.colors;
            submitColors.normalColor = GameConstants.NEON_CYAN;
            submitColors.highlightedColor = GameConstants.NEON_MAGENTA;
            submitButton.colors = submitColors;
        }
    }
}
