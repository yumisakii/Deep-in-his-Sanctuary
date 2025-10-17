# ⚔️ Deep in His Sanctuary

A **text-based roguelike** developed in **C#** as a school project to learn **data persistence**, **serialization**, and **secure user authentication**.  
The game runs entirely in the **console**, combining combat, loot, crafting, and progression through randomly generated encounters.

---

## 🎯 Project Goals

- Learn and implement **data persistence** using **MongoDB** and **JSON**.  
- Understand **secure password management** with **hash + salt**.  
- Structure a clean and modular C# project using multiple classes and files.  
- Build a simple yet functional **roguelike gameplay loop** with combat, loot, and fusion mechanics.

---

## 🧩 Gameplay Overview

You enter a mysterious **sanctuary** composed of successive rooms:

1. **Combat Rooms** — Face 3 random enemies in each battle.  
2. **Loot Room** — Choose a new weapon (each weapon is bound to a spell).  
3. **Forge Room** — Combine two weapons or spells to forge a stronger one.  
4. **Boss Room** — Defeat the boss to advance to the next loop.

The pattern repeats until your character dies.  
Enemies and loot are **randomized**, ensuring replayability.

---

## ⚙️ Technical Features

- **Language:** C#  
- **Interface:** Console application  
- **Architecture:** Multi-class project with separate files for entities, systems, and managers  
- **Data Persistence:**  
  - **Player Profiles:** Stored in **MongoDB** (username + hashed & salted password)  
  - **Game Data:** Saved locally as **JSON**  
- **Serialization:** Custom serialization system for storing and retrieving game progress  
- **Save Slots:** Up to **3 saves per profile**

---

## 🧠 Key Mechanics

- ⚔️ **Combat System:** Turn-based fights with random enemies  
- 💎 **Loot System:** Random weapon drops, each linked to a spell  
- 🔨 **Fusion System:** Combine weapons or spells to create upgraded versions  
- 🏰 **Progression Loop:** Fight → Loot → Forge → Boss → Repeat  

---

## 🗄️ Data Persistence

| Type | Technology | Description |
|------|-------------|-------------|
| **Profiles** | MongoDB | Stores user accounts with hashed and salted passwords |
| **Game Saves** | JSON (local) | Stores progression, inventory, and stats |
| **Serialization** | Custom C# system | Converts objects to and from JSON |

> Planned update: future versions will remove MongoDB to make the game fully playable offline.

---

## 🧠 What I Learned

- Implementing **secure authentication** (hash + salt)  
- Managing **persistent data** with MongoDB and local JSON files  
- Structuring a **modular C# project** with multiple classes  
- Using **serialization** to store and reload gameplay data  
- Building the base of a **roguelike gameplay loop** in console  

---

## 🔮 Future Improvements

- Replace MongoDB with a **local-only save system** for full offline play  
- Add **balancing and content** to make the game more enjoyable  
- Improve the **enemy and loot variety**  
- Add **clearer UI elements** for combat feedback  
- Implement **player progression and skill trees**

---

## 👤 Author

**Jonathan de Vaulchier**  
🎮 Student Developer @ [Gaming Campus – G.Tech](https://gamingcampus.fr/ecoles/ecole-developpeur-jeux-video-g-tech.html)  
📧 [jonathan.devaulchier.dev@gmail.com](mailto:jonathan.devaulchier.dev@gmail.com)  
🔗 [GitHub Profile](https://github.com/yumisakii)

