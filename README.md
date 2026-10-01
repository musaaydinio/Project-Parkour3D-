# 🏃 Bouncy Parkour Panic - 3D Physics & Reflex Parkour (Unity & C#)

![Status](https://img.shields.io/badge/Status-LIVE_ON_ITCH.IO-brightgreen?style=for-the-badge)
![Unity](https://img.shields.io/badge/Unity-3D_Engine-000000?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-OOP_%26_Physics-239120?style=for-the-badge&logo=c-sharp)
![itch.io](https://img.shields.io/badge/itch.io-Playable_Build-FA5C5C?style=for-the-badge&logo=itch.io)

> 🎮 **Playable Live Game (itch.io):** [Click Here to Play Bouncy Parkour Panic](https://nimugame.itch.io/bouncy-pakour-panc)
>
> 🎬 **Official Game Trailer (YouTube):** [Watch YouTube Trailer](https://www.youtube.com/watch?v=6S1k4kSZn3I)
>
> 📺 **Full Gameplay Showcase (LinkedIn):** [Watch Full Gameplay Video](https://www.linkedin.com/posts/-musaaydin_gamedev-unity3d-csharp-activity-7500784360141324288-m537?utm_source=share&utm_medium=member_desktop&rcm=ACoAAFt4-Z4BThiIQLsj6srcA3f0UiXfslG1sBs)

---

## 🎯 About The Project
**Bouncy Parkour Panic** is a high-speed, 3D physics-driven reflex parkour game where players navigate complex vertical courses, dodge dynamic hazards, and race against time.

Originally built as a physics-based movement experiment, the game evolved into a feature-complete 3D title featuring an **immersive narrative framework**, **cinematic story endings**, a **hardcore No-Death Challenge Mode**, real-time **Leaderboard tracking**, and heavy **CPU performance optimizations**.

---

## 🌟 Major Upgrades & New Features

### 📖 1. Narrative Intro & Cinematic Outro
* **Story Driven Course:** Integrated story context that drives the player forward through the dangerous obstacle course.
* **Cinematic Ending:** Upon crossing the finish line, the camera transitions seamlessly into a cinematic outro sequence, wrapping up the run before displaying the final stats.

### 💀 2. Hardcore "No-Death" Challenge Mode
* Designed for hardcore speedrunners and perfectionists.
* **Zero-Tolerance Gameplay:** A single mistake or fall resets the entire run. Players must complete the full course without dying once to conquer this mode and secure top leaderboard honors.

### 🏆 3. Stop-Watch Timer & Leaderboard Integration
* Real-time course completion timer that halts the exact millisecond the finish line is breached.
* **Persistent Leaderboard:** Automatically logs and ranks top completion times on the main menu leaderboard.

---

## 🏃 Player Movement & State Machine Architecture

* **Physics-Driven Controller:** Smooth character movement relying on custom gravity curves, momentum conservation, and ground interaction checks.
* **Animation State Machine:** Flawless blending between Idle, Running, Jump-up, Falling, and Death animation states dynamically synchronized with the character's real-time velocity vector (`RigidBody` / `CharacterController`).
* **Instant Spawn Point System:** Seamless checkpoint mechanics that instantly reset the player to safe ground upon falling or hitting lethal traps, ensuring zero friction in gameplay flow.

---

## ⚡ Performance Optimization & Engine Architecture

* **Distance-Based Activation (`DistanceActivator`):** To prevent dozens of moving gears, rotating traps, and physics hazards from consuming CPU/GPU cycles off-screen, a custom distance-culling algorithm was built. Traps only activate their movement math and physics routines when the player enters a defined proximity radius.
* **Audio Channel Manager:** Decoupled SFX and Background Music (BGM) channels with independent volume sliders and spatial 3D audio effects.
* **Graphics Settings & Framerate Controls:** In-game UI options allowing players to tweak resolution presets, graphic quality tiers, and target FPS toggles.

---

## ⚔️ Dynamic Hazards & Trap Mechanics

The obstacle course includes a diverse array of dynamic hazards designed to test player reflexes:

* **Mathematically Rotating Gears:** Mechanical wheels driven by `DeltaTime` rotation matrices and Euler angle transformations.
* **Surprise Box Traps:** Hidden spring-loaded hazards that spring out unexpectedly from deceptive terrain blocks.
* **Projectiles & Falling Hazards:** Explosive barrels, thrown bombs, and falling logs raining from above.
* **Jump Pads & Terrain Modifiers:** Trampoline bouncers that launch players into high vertical arcs, combined with Speed Boost and Slow-Mo mud zones.

---

## 🎮 Controls

| Action | Control Key |
| :--- | :--- |
| **Movement** | `W, A, S, D` or `Arrow Keys` |
| **Jump** | `Spacebar` |
| **Look / Camera** | `Mouse` |
| **Pause / Menu** | `ESC` |

---

## 👨‍💻 Developer Note
*Bouncy Parkour Panic represents my growth in 3D physics handling, animation synchronization, cinematic camera control, and level optimization in Unity.*

*It bridges the gap between pure gameplay mechanics and complete game design—combining speedrunning appeal, story elements, and performance-conscious coding.*
