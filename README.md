# Weekly Assignment – World Building and Algorithms in Two Dimensions

## Game Description

This game demonstrates the use of Unity's Tilemap system to create a dynamic and engaging gameplay experience.  
Players take control of the main character, navigating a tile-based map while attempting to evade a pursuing enemy.<br>
Move the character using the **arrow keys**, strategize your escape, and face the challenges the game presents!
- [Click Here to Play ](https://tomgoz.itch.io/tilemapalgo)
---

## Explanation of the Scripts

### 1. VisibilityManager
**Purpose** Manages the enemy's visibility by controlling its SpriteRenderer component.  
**Details**  
This script allows the enemy to toggle between visible and invisible states. It can be triggered by the state machine to add dynamic gameplay elements such as temporary invisibility. The integration ensures smooth transitions between states while maintaining visual clarity for the player.  
- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/3-enemies/VisibilityManager.cs)

---

### 2. EnemyTeleportToPlayer
**Purpose** Handles the enemy's ability to teleport to the player's location.  
**Details**  
This script implements a teleportation mechanic where the enemy can instantly move to the player's position under certain conditions. It includes a configurable delay, making the ability feel strategic and integrated with the state machine. The teleportation logic ensures the player's position is dynamically tracked and updated.  
- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/3-enemies/EnemyTeleportToPlayer.cs)

---

### 3. EnemyControllerStateMachine
**Purpose** Orchestrates the enemy's behavior using a state machine.  
**Details**  
This script manages the enemy's modes of operation, such as patrolling, chasing, teleporting, and becoming invisible. It integrates custom behaviors like teleportation and invisibility, ensuring modularity and scalability. Additionally, the chase radius is dynamic, pulsating to simulate a heartbeat effect, which adds an extra layer of complexity to the gameplay.  
- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/3-enemies/EnemyControllerStateMachine.cs)

---

## How the Scripts Work Together
- **EnemyControllerStateMachine**: Acts as the central brain, controlling which mode is active at any given time.
- **VisibilityManager**: Integrates with the state machine to toggle the enemy's visibility based on the active state.
- **EnemyTeleportToPlayer**: Provides the teleportation functionality, triggered as a specific state in the state machine.

This modular setup ensures each script focuses on a single responsibility while collectively creating dynamic and engaging enemy behavior.

---

## Part B: Dijkstra Algorithm

### 1. TileMapDijkstra
**Purpose**  
This script extends the functionality of a regular Tilemap by introducing a Dictionary to manage weights for different types of tiles. It is essential for Dijkstra's algorithm, as it calculates the cost of movement across the map.

#### Key Features
- **Tile Weights**  
  A Dictionary maps tile types (or positions) to their weights:
  - Grass: 1
  - Hill: 3
  - Water: 5

- **GetWeights Function**  
  Retrieves the weight of a tile at a specific position, enabling accurate cost calculations.

- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/0-bfs/TilemapGraphDijkstra.cs)

---

### 2. Igraph
**Purpose**  
An interface that abstracts graph operations, allowing different graph implementations (e.g., tilemaps, custom graphs) to share common functionality.

#### Functionality Overview
- **Neighbors Function**  
  Retrieves neighboring nodes of a given node.

- **GetWeight Function**  
  Fetches the weight of a specific node, required by Dijkstra to calculate path costs.

- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/0-bfs/IGraph.cs)

---

### 3. DijkstraAlgorithm
**Purpose**  
Implements Dijkstra's algorithm to compute the shortest path between two nodes. It leverages weights from TileMapForDijkstra to calculate path costs.

#### Key Details
- **Pathfinding Logic**  
  Iteratively explores nodes, prioritizing those with the lowest cumulative cost using a PriorityQueue.

- **Weighted Paths**  
  Incorporates tile weights (via GetWeight) to calculate the cost of each path.

#### Algorithm Workflow
1. Start from the initial node.
2. Use the PriorityQueue to process nodes with the lowest cost first.
3. Update the cost for each neighbor based on the current node’s cost and edge weight.
4. Repeat until the target node is reached or all nodes are processed.

- [View the script here](https://github.com/ComputerGameDev/05-tilemap-pathfinding/blob/master/Assets/Scripts/0-bfs/DijkstraAlgorithm.cs)

---

## How It All Fits Together

1. **TileMapForDijkstra** Represents the weighted graph using tile weights.
2. **Igraph** Abstracts graph functionality for compatibility with Dijkstra.
3. **DijkstraAlgorithm** Computes the shortest path using weighted paths and the priority queue.
4. **TargetMover** Uses Dijkstra to calculate paths and moves objects step-by-step along them.
5. **PriorityQueue** Optimizes Dijkstra’s performance by processing nodes with the lowest cost first.
