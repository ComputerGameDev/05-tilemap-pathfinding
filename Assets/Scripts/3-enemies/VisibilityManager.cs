using UnityEngine;

/// <summary>
/// Manages the visibility of a GameObject by controlling its SpriteRenderer component.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class VisibilityManager : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        InitializeSpriteRenderer();
    }

    private void Start()
    {
        // Default the GameObject to an invisible state when the game starts
        SetVisibility(false);
    }

    private void OnEnable()
    {
        // Ensure the GameObject is invisible when it becomes active
        SetVisibility(false);
    }

    private void OnDisable()
    {
        // Ensure the GameObject becomes visible when it is deactivated
        SetVisibility(true);
    }

    /// <summary>
    /// Toggles the visibility of the GameObject.
    /// </summary>
    /// <param name="isVisible">True to make visible, false to make invisible.</param>
    public void SetVisibility(bool isVisible)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.enabled = isVisible;
            Debug.Log($"{gameObject.name} is now {(isVisible ? "visible" : "invisible")}.");
        }
    }

    /// <summary>
    /// Initializes and validates the SpriteRenderer component.
    /// </summary>
    private void InitializeSpriteRenderer()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer == null)
        {
            Debug.LogError($"{gameObject.name} is missing a SpriteRenderer component. Disabling the script.");
            enabled = false; // Disable the script to prevent further issues
        }
    }
}
