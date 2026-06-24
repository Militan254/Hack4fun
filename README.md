# 🎮 Hack4fun - Cyberpunk Hacking Game

A 3D cyberpunk-themed hacking game built in Unity where players compete to breach security systems using brute force and dictionary attacks.

## 🎯 Game Overview

**Hack4fun** is an educational cybersecurity game featuring:
- 20 challenging levels with progressive difficulty
- Two attack types: Brute Force and Dictionary Attack
- Speed-based competition with leaderboard system
- Cyberpunk aesthetic with neon terminals and glitch effects
- Real-time scoring and level progression

## 🕹️ Game Features

### Gameplay Mechanics
- **Brute Force Attack**: Try all character combinations
- **Dictionary Attack**: Guess passwords using word lists
- **Speed Challenge**: Complete levels faster to earn higher scores
- **Progressive Difficulty**: 20 levels from Easy to Expert

### Level Structure
- **Levels 1-5**: Easy (3-4 character passwords, 5 min limit)
- **Levels 6-10**: Medium (5-6 character passwords, 3-4 min limit)
- **Levels 11-15**: Hard (7-8 character passwords, 2-3 min limit)
- **Levels 16-20**: Expert (8-10 character passwords, 90s-2 min limit)

### Audio & Visual
- Cyberpunk neon aesthetic environment
- Sci-fi ambient soundtrack
- Real-time glitch effects
- Terminal-style UI with matrix effects
- Particle effects for success/failure feedback

## 📁 Project Structure

```
Hack4fun/
├── Assets/
│   ├── Scripts/
│   │   ├── Managers/
│   │   │   ├── GameManager.cs
│   │   │   ├── LevelManager.cs
│   │   │   └── UIManager.cs
│   │   ├── Systems/
│   │   │   ├── HackingSystem.cs
│   │   │   ├── PasswordValidator.cs
│   │   │   ├── ScoreSystem.cs
│   │   │   └── TimerSystem.cs
│   │   ├── UI/
│   │   │   ├── UIController.cs
│   │   │   ├── TerminalDisplay.cs
│   │   │   ├── TimerUI.cs
│   │   │   └── LeaderboardUI.cs
│   │   ├── Data/
│   │   │   ├── LevelData.cs
│   │   │   ├── PasswordDatabase.cs
│   │   │   └── PlayerStats.cs
│   │   └── Utils/
│   │       ├── AudioManager.cs
│   │       └── Constants.cs
│   ├── Scenes/
│   ├── Prefabs/
│   ├── Audio/
│   ├── Textures/
│   ��── Materials/
├── .gitignore
└── README.md
```

## 🚀 Getting Started

### Prerequisites
- Unity 2021.3 or later
- C# knowledge (basic)
- Git installed

### Installation

1. Clone the repository
```bash
git clone https://github.com/Militan254/Hack4fun.git
cd Hack4fun
```

2. Open in Unity
   - Launch Unity Hub
   - Click "Add" → Select the Hack4fun folder
   - Open the project

3. Open Main Scene
   - Navigate to `Assets/Scenes/MainMenu.unity`
   - Press Play to test

## 📝 Game Controls

| Input | Action |
|-------|--------|
| Type text | Enter password guess |
| Enter | Submit guess |
| Space | Use hint (if available) |
| ESC | Return to menu |

## 🎓 Level Difficulty

Each level increases in challenge:
- Password length increases
- Time limits decrease
- Character complexity increases
- Mixed attack types required

## 🏆 Scoring System

Points are calculated based on:
- Time remaining
- Number of attempts used
- Difficulty multiplier
- Bonus for first-try completion

## 🔧 Configuration

Edit `Assets/Scripts/Data/LevelData.cs` to customize:
- Level passwords
- Time limits
- Difficulty settings
- Dictionary word lists

## 📚 Script Documentation

### Core Managers
- **GameManager.cs** - Overall game flow and scene management
- **LevelManager.cs** - Level progression and state management
- **UIManager.cs** - Central UI control system

### Game Systems
- **HackingSystem.cs** - Brute force and dictionary attack logic
- **PasswordValidator.cs** - Password validation and feedback
- **ScoreSystem.cs** - Score calculation and tracking
- **TimerSystem.cs** - Level timer management

### UI Components
- **UIController.cs** - Main UI orchestration
- **TerminalDisplay.cs** - Terminal/console display
- **TimerUI.cs** - Timer visual component
- **LeaderboardUI.cs** - Leaderboard display

### Data Management
- **LevelData.cs** - Level configuration data
- **PasswordDatabase.cs** - Password and dictionary storage
- **PlayerStats.cs** - Player statistics tracking

### Utilities
- **AudioManager.cs** - Sound effects and music management
- **Constants.cs** - Global game constants

## 🎨 Cyberpunk Aesthetic

- **Color Scheme**: Neon cyan (#00FFFF), magenta (#FF00FF), dark grays (#0A0E27)
- **Font**: Monospace terminal-style fonts
- **Effects**: Glitch animations, screen tears, neon glow
- **Ambiance**: Sci-fi hums, typewriter sounds, electronic beeps

## 🎵 Audio Assets Needed

### Ambient Sounds
- Sci-fi hum/drone background
- Server room buzz
- Glitch sound effects

### UI Feedback
- Correct guess beep (positive)
- Wrong guess buzz (negative)
- Level complete ding
- Game complete fanfare

### Music
- Menu theme (cyberpunk style)
- Gameplay theme (tense, progressive)
- Victory theme

## 🖼️ Visual Assets Needed

### Environment
- Dark tech room / server room
- Neon glowing terminals
- Holographic displays
- Cable and wiring details

### UI Elements
- Neon progress bars
- Digital text overlays
- Glowing buttons
- Matrix-style backgrounds

### Effects
- Screen glitch effects
- Success/failure explosions
- Neon glow particles

## 🤝 Contributing

Feel free to fork and submit pull requests for improvements!

## 📄 License

MIT License - Feel free to use and modify!

## 👨‍💻 Author

**Militan254** - Lead Developer

## 🐛 Bug Reports

Found a bug? Please create an issue with:
- Description of the bug
- Steps to reproduce
- Expected vs actual behavior
- Unity version used

## 📞 Support

For questions or suggestions, open an issue on GitHub!

---

**Happy Hacking! 🔓⚡**
