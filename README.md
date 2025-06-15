I3E Assignment 1 – 3D Virtual Player Experience
📘 Project Info
🎓 Course: Diploma in Immersive Media & Game Design

🧑‍💻 Student Name: [Your Name]

📆 Semester: Year 2 (2024/25), Semester 2.1

🛠 Platform: Unity 2022+ (Windows Desktop)

💾 Repository Link: [Insert GitHub Repository URL Here]

🎮 Game Description
This is a first-person 3D player experience featuring:

A fully explorable indoor and outdoor environment

Interactable doors separating both areas

5 collectibles scattered across the world

Multiple hazards that damage the player

UI that tracks progress and score

Simple audio cues and background music

Locked key mechanic that is unlocked by collecting all relics

🕹️ Controls
Key	Action
W / A / S / D	Move player
Mouse	Look around
E	Interact (collect, open doors, unlock key)
Esc	Quit

🧠 Game Logic Overview
Collectibles are tracked and counted via GameManager.

Doors unlock or open based on trigger zones or collection conditions.

Hazards use Unity Physics for collision and damage-over-time.

Key unlocks after all 3 relics are collected.

UI updates dynamically based on player progress.

🛠 Unity Systems Used
Rigidbody + Collider for Physics

Unity UI (TextMeshPro for prompts and counters)

Animator + Trigger-based Interactions

AudioSource for SFX and BGM

Tag & Layer logic for triggers (e.g. "Player", "Hazard", "Collectible")

📂 Project Structure
arduino
/Assets
  /Scripts
    GameManager.cs
    PlayerController.cs
    Collectible.cs
    DoorController.cs
    Hazard.cs
    LockedBox.cs
  /Prefabs
  /Scenes
  /Audio
  /Materials
  /Textures
🧪 Requirements Checklist
✅ Indoor and Outdoor areas

✅ Doors with interaction

✅ 5 Collectibles

✅ Score counter

✅ UI message on completion

✅ Hazards (2 types)

✅ BGM and SFX

✅ GitHub version control

✅ XML documentation and file headers

🐞 Known Issues / Limitations
Some objects may clip through terrain on collision

No health bar UI implemented yet for hazard damage

Audio balance may vary depending on output device

🎯 Puzzle/Hack Answers
Unlock the key by collecting 3 relics

The relics are placed: behind the waterfall, in the tower, and under the bridge

The locked box becomes inactive once the key is retrieved

🙏 Credits
BGM: "Adventure Loop" by Kevin MacLeod (incompetech.com)

SFX: freesound.org contributors

3D Models: Unity Asset Store (Free assets), ProBuilder-created geometry