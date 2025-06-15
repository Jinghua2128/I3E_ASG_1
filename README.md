# I3E Assignment 1 ReadMe

**Student Name:** Liu GuangXuan  
**Course:** Diploma in Immersive Media
**Assignment:** I3E Assignment 1
**Date:** 15 June 2025

---

## 🎮 Game Overview
In this 3D immersive experience, you play as a skeleton trapped inside a dungeon. To escape, you must:

- Collect 3 relics hidden across indoor and outdoor areas.
- Unlock a box to reveal the key.
- Use the key to open the main door.
- Collect the final crystal from the dome hall to win the game.

---

## 🕹️ Controls

| Key     | Action                |
|---------|------------------------|
| W A S D | Move                  |
| Mouse   | Look                  |
| Space   | Jump                  |
| E       | Interact with objects |

---

## 🧠 Game Logic

- Player uses raycasting to interact with relics, key, door, and crystal.
- Relics update a counter in the UI and increase score.
- Once 3 relics are collected, the locked box becomes interactive.
- The key appears after interacting with the box and can be picked up.
- Door only opens if player has collected the key.
- Final crystal activates a win message.
- Hazards reduce health; player respawns on death.
- Sound FX and background music enhance feedback and atmosphere.

---

## 🛠️ Systems & Tools Used

- Unity Engine 2022.3 LTS (URP)
- C# scripting
- Unity Raycasting (Physics.Raycast)
- Unity Terrain system
- Unity UI (TextMeshPro)
- GitHub Desktop

---

## 🖥️ Target Platform

- Platform: Windows Desktop
- Resolution: 1080p, 16:9 recommended
- Tested on: Windows 10 + Unity Editor

---

## 🎨 Assets & References

- VFX: Free Fire VFX – URP (Unity Asset Store)
- Sound Effects: soundfree.org
- 3D Models: Self-made for 3RT assignments
- Assistance: NP I3E AI Tutor (ChatGPT)

---

## ⚠️ Known Bugs / Limitations

- Doors do not close after being opened.
- No volume settings for background music.
- Some transitions rely on colliders only.

---

## 🧩 Puzzle/Game Flow

1. Player collects 3 relics around the map.
2. The locked box becomes active and spawns the key after interaction.
3. Player picks up the key.
4. Door becomes accessible using the key.
5. Final crystal appears and shows a win message on interaction.

---

## 📂 Project Folder Structure

Assets/
├── Audio/
├── Materials/
├── Prefabs/
├── Scenes/
├── Scripts/
├── Textures/
└── VFX/
ProjectSettings/
README.md

---

## 🔗 GitHub Submission
https://github.com/Jinghua2128/I3E_ASG_1
Thank you for playing!
