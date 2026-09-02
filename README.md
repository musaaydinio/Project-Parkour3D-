# BOUNCY PARKOUR

## 🎮 About the Project
This project is a reflex-based 3D parkour game where the player navigates upwards and forward to complete the course as fast as possible. The main objective is to dodge moving and surprise obstacles, reach the finish line in record time, and log the completion time onto the leaderboard.

## 🇬🇧 Gameplay & Overview
> 📺 **You can watch the video showing the entire game and its progress here.:** (https://lnkd.in/p/dFzaicG9)(#)

## 🚀 Performance Optimization
* **Distance-Based Activation:** To prevent obstacles and moving objects from running constantly and draining CPU resources, a custom `DistanceActivator` script was implemented. Obstacles only become active when the player approaches within a specific distance threshold, preserving optimal game performance.

## ⚙️ Main Menu & System Settings
* **Graphics & Performance:** Resolution presets, graphic quality settings, and FPS configurations.
* **Audio Management:** Sound system allowing independent control over background music and sound effects (SFX).

## 🏃 Player Movement & Animation System
* **Physics-Based Movement:** Smooth character control architecture driven by gravity and ground interactions.
* **Animation Synchronization:** A State Machine structure that flawlessly blends Running, Jumping, and Death animations in sync with the player's real-time velocity.

## 📍 Spawn Point Logic
* When the player falls or fails during the course, they are instantly respawned at a predetermined safe **Spawn Point** without disrupting the gameplay flow.

## ⚔️ Obstacles & Trap Mechanics
The course features various active and dynamic hazards designed to constantly test the player:
* **Roaming Moving Obstacles:** Hazards that move back and forth or rotate independently within a designated distance range.
* **Mathematically Rotating Gears:** Rotating wheels and mechanical platforms powered by DeltaTime and Euler angles.
* **Surprise Box Traps:** Hidden obstacles that unexpectedly pop out of seemingly safe boxes to test reaction times.
* **Falling & Thrown Hazards:** Logs and bombs launched from above, alongside sudden explosive objects.
* **Speed & Slow Zones:** Special terrain areas that accelerate or decelerate the player's movement on contact.
* **Jump Pads (Bouncers):** Trampoline systems that propel the player upward.

## 🏆 Finish Line & Leaderboard
* Upon reaching the finish line at the end of the course, the in-game timer stops.
* The completion time is recorded and displayed on the **Leaderboard** located in the main menu (sorted logically from best/fastest times downwards), encouraging players to continuously beat their own records.
