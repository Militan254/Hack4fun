# 🎮 HACK4FUN - Setup & Development Guide

## 📋 Quick Start

### Prerequisites
- **Unity 2021.3 LTS or higher**
- **Visual Studio Code or Visual Studio**
- **Git** (for version control)

### Installation Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/Militan254/Hack4fun.git
   cd Hack4fun
   ```

2. **Open in Unity Hub**
   - Open Unity Hub
   - Click "Add project from disk"
   - Select the `Hack4fun` folder
   - Click "Open"

3. **Wait for Import**
   - Unity will import all assets and scripts
   - This may take 2-5 minutes on first load

4. **Open the Main Scene**
   - Navigate to `Assets/Scenes/`
   - Double-click `GameScene.unity`
   - Press `Play` to test

---

## 🏗️ Project Architecture

### Folder Structure
```
Assets/Scripts/
├── Managers/
│   ├── GameManager.cs          # Overall game control
│   ├── LevelManager.cs         # Level-specific logic
│   └── UIManager.cs            # UI coordination
├── Systems/
│   ├── HackingSystem.cs        # Attack algorithms
│   ├── PasswordValidator.cs    # Password verification
│   ├── ScoreSystem.cs          # Score calculation
│   └── TimerSystem.cs          # Timer management
├── UI/
│   ├── UIController.cs         # Main UI orchestration
│   ├── TerminalDisplay.cs      # Terminal styling
│   ├── TimerUI.cs              # Timer UI component
│   └── LeaderboardUI.cs        # Leaderboard display
├── Data/
│   ├── LevelData.cs            # All 20 level configs
│   ├── PasswordDatabase.cs     # Password storage
│   ├── PlayerStats.cs          # Player progress tracking
│   └── Constants.cs            # Game constants
└── Utils/
    └── AudioManager.cs         # Audio management
```

---

## 🎮 Core Game Flow

```
MainMenu
   ↓
   [Start Game]
   ↓
LevelSelect
   ↓
   [Select Level 1]
   ↓
Gameplay
   ├─ Player sees system info
   ├─ Player enters password guess
   ├─ System validates guess
   ├─ Feedback displayed
   └─ Repeat until correct or time expires
   ↓
Results Screen
   ├─ Show score, time, attempts
   ├─ Compare with level best
   └─ Next Level / Menu
   ↓
[Repeat for all 20 levels]
   ↓
Final Score Screen
   ├─ Total score
   ├─ Completion rank
   └─ Leaderboard position
```

---

## 🎨 Customization Guide

### Change Game Colors (Cyberpunk)

Edit `Assets/Scripts/Utils/Constants.cs`:

```csharp
public static readonly Color NEON_CYAN = new Color(0f, 1f, 1f, 1f);      // #00FFFF
public static readonly Color NEON_MAGENTA = new Color(1f, 0f, 1f, 1f);   // #FF00FF
public static readonly Color DARK_BG = new Color(0.039f, 0.056f, 0.153f, 1f); // #0A0E27
```

### Modify Level Difficulty

Edit `Assets/Scripts/Data/LevelData.cs`:

```csharp
levels.Add(new LevelConfig
{
    levelNumber = 1,
    targetPassword = "abc",           // Change password
    timeLimit = 300f,                 // Change time (in seconds)
    difficulty = DifficultyLevel.Easy,
    // ... other settings
});
```

### Adjust Scoring System

Edit `Assets/Scripts/Utils/Constants.cs`:

```csharp
public const float TIME_BONUS_MULTIPLIER = 1.5f;  // Time reward
public const float ATTEMPT_PENALTY = 100f;        // Per attempt cost
public const int BASE_POINTS = 1000;              // Base points
public const float PERFECT_ATTEMPT_BONUS = 500f;  // First try bonus
```

---

## 🔧 Key Scripts Explanation

### GameManager.cs
**Purpose**: Central game control
- Manages game state (Menu, Playing, Paused, etc.)
- Tracks player progression through levels
- Manages overall score
- Singleton pattern (only one instance)

**Key Methods**:
```csharp
StartNewGame()           // Begin a new game
LoadLevel(levelNumber)   // Load specific level
CompleteLevelWithScore() // Mark level complete
PauseGame() / ResumeGame()
ReturnToMenu()
```

### HackingSystem.cs
**Purpose**: Attack logic (brute force & dictionary)
- Dictionary word list management
- Brute force guess generation
- Dictionary attack guess retrieval
- Suggestion system for hints

**Key Methods**:
```csharp
GetNextBruteForceGuess()    // Generate next brute force attempt
GetNextDictionaryGuess()    // Get word from dictionary
GetRandomDictionaryGuess()  // Random word suggestion
GenerateSuggestions()       // For hint system
```

### PasswordValidator.cs
**Purpose**: Validate guesses and provide feedback
- Check if guess matches password
- Calculate partial matches
- Provide helpful feedback
- Hint generation

**Key Methods**:
```csharp
ValidateGuess()          // Check if guess is correct
GetPartialMatchFeedback() // Tell how close they are
GetLengthHint()          // Reveal password length
GetPartialRevealHint()   // Show first and last char
```

### ScoreSystem.cs
**Purpose**: Calculate and track scores
- Score calculation based on time/attempts/difficulty
- Rank assignment (S, A, B, C, D, F)
- Difficulty multipliers
- Combo multipliers

**Key Methods**:
```csharp
CalculateScore()          // Compute final score
GetDifficultyMultiplier() // Get difficulty bonus
GetRankByScore()          // Assign rank based on score
GetRankColor()            // Color for UI display
```

### TimerSystem.cs
**Purpose**: Manage level timers
- Start/stop/pause/resume timer
- Get time remaining
- Detect when running out of time
- Format time display

**Key Methods**:
```csharp
StartTimer(duration)     // Begin countdown
StopTimer()              // End timer
GetTimeRemaining()       // Current time left
GetFormattedTime()       // MM:SS format
IsTimeRunningOut()       // Check if <20% remains
```

---

## 🎵 Audio Setup

### Adding Sound Effects

1. **Import Audio Files**
   - Drag .mp3 or .wav files into `Assets/Audio/`

2. **Register with AudioManager**
   ```csharp
   AudioManager.Instance.RegisterSFX("correct_beep", correctClip);
   ```

3. **Play Sound**
   ```csharp
   AudioManager.Instance.PlaySFX("correct_beep");
   ```

### Required Audio Files
- `menu_theme.mp3` - Menu background music
- `gameplay_theme.mp3` - Level background music
- `correct_beep.wav` - Correct password sound
- `wrong_buzz.wav` - Wrong password sound
- `level_complete.wav` - Level completion sound
- `game_complete.wav` - Game completion fanfare

---

## 🖼️ Visual Assets Setup

### Materials for Cyberpunk Look

1. **Create Neon Material**
   - Right-click in `Assets/Materials/` → Create → Material
   - Name: `NeonMaterial`
   - Set Emission: Bright cyan (#00FFFF)

2. **Terminal UI Panel**
   - Use dark background (#0A0E27)
   - Neon border glow effect
   - Monospace font for text

3. **Glitch Effect Material**
   - Use displacement map for screen tears
   - Apply randomly for brief moments

---

## 🧪 Testing Your Build

### Quick Test Checklist
- [ ] Main menu displays correctly
- [ ] Level loads with correct password
- [ ] Timer counts down
- [ ] Wrong guess shows feedback
- [ ] Correct guess advances to next level
- [ ] Score calculates properly
- [ ] Audio plays when expected
- [ ] UI colors are cyberpunk themed
- [ ] Hints work correctly
- [ ] Leaderboard saves scores

---

## 🐛 Common Issues & Fixes

### Issue: Scripts don't compile
**Solution**: Ensure all namespaces match folder structure:
- Scripts in `Managers/` use `namespace Hack4Fun.Managers`
- Scripts in `Systems/` use `namespace Hack4Fun.Systems`
- etc.

### Issue: GameManager not found
**Solution**: 
- Ensure `GameManager.cs` is in `Assets/Scripts/Managers/`
- Add it to the scene first, or create it at runtime

### Issue: Timer not updating UI
**Solution**:
- Ensure `TimerSystem` and `TimerUI` are on same GameObject
- Check that UI elements are assigned in Inspector

### Issue: Passwords not matching
**Solution**:
- Check password case (system converts to lowercase)
- Verify spelling in `LevelData.cs`
- Check for extra spaces

---

## 🚀 Building for Release

### Build Settings
1. Go to `File` → `Build Settings`
2. Add `GameScene` to build (drag from Project)
3. Select target platform
4. Click `Build`

### Optimization Tips
- Disable unused shaders
- Compress audio files
- Use UI batching for better performance
- Profile with Profiler window

---

## 📊 Difficulty Progression

**Levels 1-5 (Easy)**
- 3-4 character passwords
- 5 minute time limit
- Brute force only
- Learning phase

**Levels 6-10 (Medium)**
- 5-6 character passwords
- 3-4 minute time limit
- Dictionary words
- Speed increases

**Levels 11-15 (Hard)**
- 7-8 character passwords
- 2-3 minute time limit
- Mixed attack types
- High competition

**Levels 16-20 (Expert)**
- 8-10 character passwords
- 90 seconds - 2 minutes
- All combinations
- Elite only

---

## 📈 What's Next?

After setup, consider adding:
- [ ] Multiplayer leaderboard (cloud sync)
- [ ] More password complexity (special chars)
- [ ] Procedural level generation
- [ ] Achievement system
- [ ] Custom difficulty presets
- [ ] Mobile touch support
- [ ] Voice acting for system names
- [ ] Advanced glitch effects

---

## 🤝 Need Help?

- Check existing issues on GitHub
- Review the code comments
- Test individual systems in isolation
- Use Debug.Log to trace execution

**Happy Coding! 🔓⚡**
