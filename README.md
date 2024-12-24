# Weekly Assignment – ​​World Building and Algorithms in Two Dimensions

## **Game Description**

This game demonstrates the use of Unity's Tilemap system to create a dynamic and engaging gameplay experience.  
Players take control of the main character, navigating a tile-based map while attempting to evade a pursuing enemy.<br>
Move the character using the **arrow keys**, strategize your escape, and face the challenges the game presents!

---
## **Explanation of the Scripts**

### **1. VisibilityManager**
- **Purpose**: Manages the enemy's visibility by controlling its SpriteRenderer component.  
- **Details**:  
  This script allows the enemy to toggle between visible and invisible states. It can be triggered by the state machine to add dynamic gameplay elements such as temporary invisibility. The integration ensures smooth transitions between states while maintaining visual clarity for the player.  
- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/3-enemies/VisibilityManager.cs)

---

### **2. EnemyTeleportToPlayer**
- **Purpose**: Handles the enemy's ability to teleport to the player's location.  
- **Details**:  
  This script implements a teleportation mechanic where the enemy can instantly move to the player's position under certain conditions. It includes a configurable delay, making the ability feel strategic and integrated with the state machine. The teleportation logic ensures the player's position is dynamically tracked and updated.  
- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/3-enemies/EnemyTeleportToPlayer.cs)

---

### **3. EnemyControllerStateMachine**
- **Purpose**: Orchestrates the enemy's behavior using a state machine.  
- **Details**:  
  This script manages the enemy's modes of operation, such as patrolling, chasing, teleporting, and becoming invisible. It integrates custom behaviors like teleportation and invisibility, ensuring modularity and scalability. Additionally, the chase radius is dynamic, pulsating to simulate a heartbeat effect, which adds an extra layer of complexity to the gameplay.  
- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/3-enemies/EnemyControllerStateMachine.cs)

---

## **How the Scripts Work Together**
- **EnemyControllerStateMachine**: Acts as the central brain, controlling which mode is active at any given time.
- **VisibilityManager**: Integrates with the state machine to toggle the enemy's visibility based on the active state.
- **EnemyTeleportToPlayer**: Provides the teleportation functionality, triggered as a specific state in the state machine.

This modular setup ensures each script focuses on a single responsibility while collectively creating dynamic and engaging enemy behavior.
