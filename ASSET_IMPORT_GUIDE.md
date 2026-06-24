# 📦 HACK4FUN - Asset Import Guide

## 🎨 Required Assets for Complete Experience

### Audio Assets (FREE SOURCES)

#### Background Music
1. **Menu Theme**
   - Source: Freepik / Pixabay
   - Search: "cyberpunk background music" or "synthwave"
   - Duration: 2-3 minutes looping
   - Format: .mp3
   - File: `Assets/Audio/menu_theme.mp3`

2. **Gameplay Theme**
   - Source: Freepik / YouTube Audio Library
   - Search: "intense electronic music" or "hacker theme"
   - Duration: 3-5 minutes looping
   - Format: .mp3
   - File: `Assets/Audio/gameplay_theme.mp3`

3. **Victory Theme**
   - Source: Freepik / Pixabay
   - Search: "success fanfare" or "triumph sound"
   - Duration: 5-10 seconds
   - Format: .wav
   - File: `Assets/Audio/victory_fanfare.wav`

#### Sound Effects
1. **Correct Password Beep**
   - Frequency: 2000-3000 Hz
   - Duration: 0.2-0.3 seconds
   - File: `Assets/Audio/sfx_correct.wav`
   - Alternative: Use Unity's built-in audio generator

2. **Wrong Password Buzz**
   - Frequency: 200-300 Hz (low buzz)
   - Duration: 0.3-0.5 seconds
   - File: `Assets/Audio/sfx_wrong.wav`

3. **Level Complete**
   - Similar to arcade "level up" sound
   - Duration: 0.5-1 second
   - File: `Assets/Audio/sfx_level_complete.wav`

4. **Button Click**
   - Sharp electronic beep
   - Duration: 0.1-0.2 seconds
   - File: `Assets/Audio/sfx_click.wav`

### Fonts

1. **Terminal Font (Monospace)**
   - Recommendation: "Courier New" or "Inconsolata"
   - Import: Download .ttf file
   - Location: `Assets/Fonts/`
   - Usage: UI text, terminal display

2. **Cyberpunk Font (Display)**
   - Recommendation: "Orbitron" or "Space Mono"
   - Import: Download .ttf file
   - Location: `Assets/Fonts/`
   - Usage: Titles, system names

### Textures

1. **Dark Grid Background**
   - Size: 512x512 or 1024x1024
   - File: `Assets/Textures/dark_grid.png`
   - Use: Panel backgrounds

2. **Glitch Noise Texture**
   - Size: 512x512
   - File: `Assets/Textures/glitch_noise.png`
   - Use: Glitch effect overlay

3. **Neon Glow Texture**
   - Size: 256x256 (radial gradient)
   - File: `Assets/Textures/neon_glow.png`
   - Use: Button glow effects

### Free Resource Websites

| Resource | Website | License |
|----------|---------|----------|
| Music | freepik.com | Free (CC0) |
| Music | pixabay.com | Free (CC0) |
| Music | YouTube Audio Library | Free |
| Sound FX | freesound.org | Various (mostly free) |
| Fonts | Google Fonts | Free (Open Source) |
| Fonts | DaFont.com | Various |
| Textures | polyhaven.com | Free (CC0) |
| Textures | textures.com | Freemium |

---

## 🔧 Import Instructions

### Audio Files
1. Download audio files to your computer
2. In Unity, navigate to `Assets/Audio/` folder
3. Drag and drop .mp3 or .wav files
4. Unity auto-imports with default settings
5. For compression: Right-click → Audio Import Settings
   - Compression Format: Vorbis (recommended for streaming)
   - Quality: 50-70%

### Fonts
1. Download .ttf or .otf font files
2. In Unity, create folder `Assets/Fonts/`
3. Drag and drop font files
4. Create new Text elements → Font: (select imported font)

### Textures
1. Download image files (.png preferred)
2. In Unity, create folder `Assets/Textures/`
3. Drag and drop image files
4. Right-click → Texture Import Settings:
   - Filter Mode: Trilinear
   - Compression: Normal Quality

---

## 🎵 Audio Integration

### Register Audio in AudioManager

```csharp
// In your initialization code:
AudioClip correctClip = Resources.Load<AudioClip>("Audio/sfx_correct");
AudioClip wrongClip = Resources.Load<AudioClip>("Audio/sfx_wrong");

AudioManager.Instance.RegisterSFX("correct_beep", correctClip);
AudioManager.Instance.RegisterSFX("wrong_buzz", wrongClip);
```

### Play Sound Effects

```csharp
// Correct password
AudioManager.Instance.PlaySFX("correct_beep");

// Wrong password
AudioManager.Instance.PlaySFX("wrong_buzz");

// Level complete
AudioManager.Instance.PlaySFX("level_complete");
```

### Play Background Music

```csharp
AudioClip menuTheme = Resources.Load<AudioClip>("Audio/menu_theme");
AudioManager.Instance.PlayMusic(menuTheme);
```

---

## 🖼️ Visual Setup

### Create Neon Materials

1. **Right-click in Assets → Create → Material**
   - Name: `NeonCyan`
   - Shader: Standard
   - Albedo: Cyan (#00FFFF)
   - Emission: Cyan
   - Emission Intensity: 2.0

2. **Create for each color:**
   - NeonMagenta (#FF00FF)
   - NeonGreen (#00FF00)
   - NeonOrange (#FF8800)

### UI Panel Setup

1. **Background Panel**
   - Color: Dark (#0A0E27)
   - Image: dark_grid.png (optional)

2. **Border/Glow**
   - Add Outline component
   - Color: Neon Cyan
   - Effect Distance: 2-3 pixels

3. **Text**
   - Font: Terminal font
   - Size: 24-36
   - Color: Neon Cyan (#00FFFF)

---

## 📊 Recommended Project Structure After Imports

```
Assets/
├── Audio/
│   ├── menu_theme.mp3
│   ├── gameplay_theme.mp3
│   ├── victory_fanfare.wav
│   ├── sfx_correct.wav
│   ├── sfx_wrong.wav
│   ├── sfx_level_complete.wav
│   └── sfx_click.wav
├── Fonts/
│   ├── Courier New.ttf
│   ├── Orbitron.ttf
│   └── Space Mono.ttf
├── Textures/
│   ├── dark_grid.png
│   ├── glitch_noise.png
│   └── neon_glow.png
├── Materials/
│   ├── NeonCyan.mat
│   ├── NeonMagenta.mat
│   ├── NeonGreen.mat
│   └── DarkBackground.mat
├── Scenes/
│   ├── MainMenu.unity
│   ├── GameScene.unity
│   └── ResultsScreen.unity
├── Scripts/
│   └── (all organized scripts)
└── Prefabs/
    ├── TerminalPanel.prefab
    ├── Button_CyberPunk.prefab
    └── UI_Window.prefab
```

---

## 🎮 Quick Setup Checklist

- [ ] Downloaded menu theme music
- [ ] Downloaded gameplay theme music
- [ ] Downloaded sound effects (4 main ones)
- [ ] Created `Assets/Audio/` folder
- [ ] Imported all audio files
- [ ] Created `Assets/Fonts/` folder
- [ ] Imported terminal font
- [ ] Imported cyberpunk display font
- [ ] Created `Assets/Textures/` folder
- [ ] Downloaded and imported textures
- [ ] Created Neon materials
- [ ] Tested audio playback
- [ ] Tested font rendering
- [ ] Applied materials to UI panels

---

## 🎨 Color Reference (Cyberpunk)

| Color | Hex | RGB | Usage |
|-------|-----|-----|-------|
| Neon Cyan | #00FFFF | (0, 255, 255) | Primary UI, Terminal text |
| Neon Magenta | #FF00FF | (255, 0, 255) | Highlights, System names |
| Dark Background | #0A0E27 | (10, 14, 39) | Panel backgrounds |
| Success Green | #00FF00 | (0, 255, 0) | Success feedback |
| Fail Red | #FF0000 | (255, 0, 0) | Error feedback |
| Neon Orange | #FF8800 | (255, 136, 0) | Warning/Caution |

---

## 🔊 Audio Levels (Recommended)

| Element | Volume | Usage |
|---------|--------|-------|
| Background Music | 0.6-0.7 | Always playing |
| Sound Effects | 0.8-0.9 | User feedback |
| UI Clicks | 0.5-0.6 | Subtle feedback |
| Fanfare | 1.0 | Victory moments |

---

## 💡 Tips for Best Results

1. **Audio Quality**
   - Use 44.1 kHz or 48 kHz sample rate
   - Mono for UI sounds, Stereo for music

2. **Texture Optimization**
   - Use PNG format for lossless quality
   - Keep sizes reasonable (512x512 max)
   - Use compression for build size

3. **Font Selection**
   - Monospace fonts work best for terminal feel
   - Ensure readability at small sizes
   - Test on different screen resolutions

4. **Color Consistency**
   - Use hex color codes for consistency
   - Create color style guide
   - Test colors on different monitors

---

## 🚀 Next Steps

After importing assets:
1. Test all audio in-game
2. Adjust volumes in AudioManager
3. Fine-tune UI colors
4. Test on target platforms
5. Optimize for performance

**Happy Hacking! 🔓⚡**
