# CITY EATER .IO 🕳️🏙️

![Unity](https://img.shields.io/badge/Unity-2022.3%2B-darkgrey.svg?style=flat-square&logo=unity)
![C#](https://img.shields.io/badge/C%23-Programming-blue.svg?style=flat-square&logo=c-sharp)
![Platform](https://img.shields.io/badge/Platform-WebGL%20%7C%20Android-green.svg?style=flat-square)

**City Eater .io** is a chaotic swallowing/growth game (a Hole.io clone) consisting of 120-second competitive rounds, developed with the Unity game engine. Players start as a small black hole and try to become the biggest hole on the map by swallowing objects in the city.

🔗 **https://kayraalan.itch.io/city-eater**

## 🎮 Gameplay and Mechanics

The main objective of the game is to reach the maximum size in the city within a 2-minute time limit.
* **Dynamic Growth (Lerp):** The hole grows smoothly (Lerp) towards a newly calculated target based on the size of the swallowed object.
* **Physics and Layer Management:** The kinematic properties of objects reaching the swallowing threshold are disabled, and they are made to fall through the ground using Unity's `LayerMask` system. A strong downward `linearVelocity` is applied to create a satisfying swallowing feel.
* **Enemy AI / Collision:** Other holes (enemies) in the scene can swallow the player if they are at least 10% larger. When the player is swallowed, a "Game Over" state is immediately triggered.

## 🛠️ Technologies Used and Architecture

This project was developed as a solo university project with a focus on clean code and modular structure.

* **Game Engine:** Unity 3D
* **Language:** C#
* **UI System:** Dynamic score and time tracking with TextMeshPro (TMP).
* **Audio Management:** Non-overlapping dynamic SFX system using `AudioSource.PlayOneShot`.

### Key Scripts
* `HolePhysics.cs`: Manages hole growth, object layer changing, gravity manipulation, and enemy/player size comparisons.
* `UIManager.cs`: Controls the in-game HUD, timer, scoring system, and "Game Over" (timeout or swallowed) panels.
