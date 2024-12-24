using UnityEngine;

/**
 * This component patrols between given points, chases a given target object when it sees it, and rotates from time to time.
 */
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Chaser))]
//[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(EnemyTeleportToPlayer))]
[RequireComponent(typeof(VisibilityManager))]
public class EnemyControllerStateMachine : StateMachine
{
    [Header("Pulsating Radius Settings")]
    [SerializeField] private float baseRadius = 5f; // Base radius for detection
    [SerializeField] private float pulseAmplitude = 2f; // Amplitude of the pulse
    [SerializeField] private float pulseSpeed = 2f; // Speed of the pulse (oscillation)

    [Header("Behavior Settings")]
    [SerializeField] private float radiusToTeleport = 10f; // Radius for teleporting
    //[SerializeField] private float probabilityToRotate = 0.2f; // Probability to rotate
    //[SerializeField] private float probabilityToStopRotating = 0.2f; // Probability to stop rotating
    [SerializeField] private float probabilityToBeInvisible = 0.3f; // Probability to become invisible
    [SerializeField] private float probabilityToStopBeInvisible = 0.2f; // Probability to stop invisibility

    private Chaser chaser;
    private Patroller patroller;
    //private Rotator rotator;
    private EnemyTeleportToPlayer teleport;
    private VisibilityManager invisibility;

    // Dynamically calculate the pulsating radius
    private float RadiusToWatch => baseRadius + Mathf.Sin(Time.time * pulseSpeed) * pulseAmplitude;

    // Calculate distance to the target
    private float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, chaser.TargetObjectPosition());
    }

    private void Awake()
    {
        // Initialize components
        chaser = GetComponent<Chaser>();
        patroller = GetComponent<Patroller>();
        //rotator = GetComponent<Rotator>();
        teleport = GetComponent<EnemyTeleportToPlayer>();
        invisibility = GetComponent<VisibilityManager>();

        // Add states and transitions
        base
        .AddState(patroller) // This would be the first active state
        .AddState(chaser)
        //.AddState(rotator)
        .AddState(teleport)
        .AddState(invisibility)

        // Define transitions
        .AddTransition(patroller, () => DistanceToTarget() <= RadiusToWatch, chaser)
        //.AddTransition(rotator, () => DistanceToTarget() <= RadiusToWatch, chaser)
        .AddTransition(patroller, () => Random.Range(0f, 1f) < probabilityToBeInvisible * Time.deltaTime, invisibility)
        .AddTransition(patroller, () => Random.Range(0f, 1f) < probabilityToBeInvisible * Time.deltaTime, invisibility)
        //.AddTransition(invisibility, () => Random.Range(0f, 1f) < probabilityToStopBeInvisible * Time.deltaTime, rotator)
        .AddTransition(invisibility, () => Random.Range(0f, 1f) < probabilityToStopBeInvisible * Time.deltaTime, patroller)
        .AddTransition(invisibility, () => DistanceToTarget() <= RadiusToWatch, chaser)
        .AddTransition(patroller, () => DistanceToTarget() > radiusToTeleport, teleport)
        .AddTransition(teleport, () => DistanceToTarget() <= RadiusToWatch, chaser)
        .AddTransition(chaser, () => DistanceToTarget() == RadiusToWatch, invisibility)
        .AddTransition(chaser, () => DistanceToTarget() > RadiusToWatch, patroller);
        //.AddTransition(rotator, () => Random.Range(0f, 1f) < probabilityToStopRotating * Time.deltaTime, patroller)
        //.AddTransition(patroller, () => Random.Range(0f, 1f) < probabilityToRotate * Time.deltaTime, rotator);
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the pulsating radius (red)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusToWatch);

        // Visualize the teleport radius (blue)
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radiusToTeleport);
    }
}
