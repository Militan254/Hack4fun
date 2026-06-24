# 🎮 HACK4FUN - Contributing Guide

## Welcome Hackers! 👨‍💻

Thank you for your interest in contributing to **Hack4fun**! This guide will help you get started.

---

## 🚀 Getting Started

1. **Fork the repository**
   - Click "Fork" on GitHub

2. **Clone your fork**
   ```bash
   git clone https://github.com/YOUR_USERNAME/Hack4fun.git
   cd Hack4fun
   ```

3. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

4. **Make your changes**
   - Follow the code style guide below

5. **Commit with clear messages**
   ```bash
   git commit -m "Add: description of your changes"
   ```

6. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

7. **Create a Pull Request**
   - Describe what you changed and why

---

## 📋 Code Style Guide

### Naming Conventions

```csharp
// Classes: PascalCase
public class GameManager { }

// Methods: PascalCase
public void StartGame() { }

// Variables: camelCase
private int playerScore;

// Constants: UPPER_SNAKE_CASE
private const int MAX_ATTEMPTS = 999;

// Private members: leadingUnderscore_camelCase
private int _localVariable;

// Properties: PascalCase
public int Score { get; set; }
```

### Spacing & Formatting

```csharp
// Good
if (playerScore > 1000)
{
    Debug.Log("High score!");
}

// Bad
if(playerScore>1000){
    Debug.Log("High score!");
}
```

### Comments

```csharp
/// <summary>
/// This is a method that does something important.
/// </summary>
public void ImportantMethod()
{
    // Single line comment explaining why
    int result = CalculateScore();
}
```

---

## 🐛 Bug Reports

When reporting bugs, include:

1. **Description**: What is the bug?
2. **Steps to reproduce**: How to trigger it?
3. **Expected behavior**: What should happen?
4. **Actual behavior**: What does happen?
5. **Environment**: Unity version, OS, etc.

Example:
```
Title: Timer doesn't stop when level completes

Description: The timer continues counting down even after the correct password is entered.

Steps:
1. Start level 1
2. Enter correct password "abc"
3. Timer continues

Expected: Timer should stop and show completion screen
Actual: Timer runs to zero

Environment: Unity 2021.3 LTS, Windows 10
```

---

## ✨ Feature Requests

Have an idea? Great! Create an issue with:

1. **Title**: Brief description
2. **Problem**: Why is this needed?
3. **Solution**: Your proposed solution
4. **Examples**: How would users interact with it?

Example:
```
Title: Add difficulty presets

Problem: Players want quick difficulty selection without customizing each setting

Solution: Add dropdown with Easy/Normal/Hard/Expert presets

Examples:
- Easy: 5 min per level, dictionary only
- Hard: 2 min per level, mixed attacks
```

---

## 📝 Areas for Contribution

### Easy (Good for beginners)
- [ ] Fix typos in documentation
- [ ] Add comments to existing code
- [ ] Create new password suggestions
- [ ] Add more hint varieties
- [ ] Improve error messages

### Medium (Intermediate)
- [ ] Add new UI themes
- [ ] Create level editor UI
- [ ] Add settings menu
- [ ] Implement pause menu
- [ ] Add sound effects menu

### Hard (Advanced)
- [ ] Implement cloud leaderboard
- [ ] Add procedural level generation
- [ ] Implement multiplayer mode
- [ ] Add advanced analytics
- [ ] Create mobile version

---

## 🧪 Testing Your Changes

Before submitting:

1. **Test in Unity**
   ```bash
   # Open the project and press Play
   # Test all affected features
   ```

2. **Test on multiple levels**
   - Easy levels
   - Hard levels
   - Edge cases

3. **Check for errors**
   - Open Console (Ctrl+Shift+C)
   - No red errors should appear

4. **Performance**
   - Open Profiler (Window → Analysis → Profiler)
   - Ensure FPS stays above 60

---

## 📚 Documentation

When adding features, update:

1. **Code Comments** - Explain your code
2. **README.md** - If it's a major feature
3. **SETUP_GUIDE.md** - If it changes setup
4. **This file** - If it affects contributing

---

## 🎯 PR Guidelines

Your Pull Request should:

✅ Have a clear title
✅ Reference related issues
✅ Include description of changes
✅ Have no merge conflicts
✅ Pass all tests
✅ Follow code style guide
✅ Include updated docs

Example PR:
```
Title: Add difficulty selector to main menu

Description:
Adds a visual difficulty selector on the main menu screen.

Closes: #42

Changes:
- Added DifficultySelector.cs UI component
- Updated MainMenuController.cs
- Added UI prefab for selector
- Updated README with new feature

Testing:
- Tested Easy/Medium/Hard/Expert selections
- Verified settings persist
- No console errors
```

---

## 🤝 Community

- **Discord**: [Join our server]
- **Issues**: GitHub Issues for bugs/features
- **Discussions**: GitHub Discussions for ideas
- **Email**: Reach out to maintainers

---

## 📜 License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

## 🙏 Thank You!

We appreciate all contributions, big or small! Every improvement helps make Hack4fun better for everyone.

**Happy Hacking! 🔓⚡**
