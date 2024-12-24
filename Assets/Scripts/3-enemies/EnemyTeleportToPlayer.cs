using UnityEngine;

/// <summary>
/// Teleports the enemy to the player's location when the teleport state is active.
/// </summary>
public class EnemyTeleportToPlayer : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The player object to teleport to.")]
    [SerializeField] private Transform playerTransform;

    [Tooltip("Delay before teleporting (in seconds).")]
    [SerializeField] private float teleportDelay = 2f;

    private bool isTeleporting = false;

    /// <summary>
    /// Called when the teleport state is activated.
    /// Starts the teleportation process.
    /// </summary>
    private void OnEnable()
    {
        if (!isTeleporting)
        {
            StartTeleport();
        }
    }

    /// <summary>
    /// Cancels teleportation if the teleport state is exited.
    /// </summary>
    private void OnDisable()
    {
        CancelTeleport();
    }

    /// <summary>
    /// Starts the teleportation process with a delay.
    /// </summary>
    private void StartTeleport()
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("Player Transform is not assigned!");
            return;
        }

        isTeleporting = true;
        Invoke(nameof(TeleportToPlayer), teleportDelay); // Trigger teleportation after delay
    }

    /// <summary>
    /// Teleports the enemy to the player's location after the delay.
    /// </summary>
    private void TeleportToPlayer()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position;
            Debug.Log($"{gameObject.name} teleported to the player at {playerTransform.position}");
        }
        else
        {
            Debug.LogWarning("Player Transform is null during teleportation.");
        }

        isTeleporting = false; // Reset teleporting flag
    }

    /// <summary>
    /// Cancels the teleportation process.
    /// </summary>
    private void CancelTeleport()
    {
        if (isTeleporting)
        {
            CancelInvoke(nameof(TeleportToPlayer));
            isTeleporting = false;
            Debug.Log("Teleportation canceled.");
        }
    }

    /// <summary>
    /// Dynamically assigns the player's Transform as the teleport target.
    /// </summary>
    /// <param name="newPlayerTransform">The player's Transform.</param>
    public void SetPlayerTransform(Transform newPlayerTransform)
    {
        playerTransform = newPlayerTransform;
    }
}
