using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BloodPuddle : MonoBehaviour
{
    // Set the desired target opacity (alpha value) between 0 and 1.
    public float targetOpacity = 0.5f;
    // Set the duration of the opacity change animation in seconds.
    public float duration = 1.5f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogWarning("No SpriteRenderer found on this GameObject.");
        }
        else
        {
            // Start the opacity change animation.
            StartCoroutine(ChangeOpacityCoroutine());
        }
    }

    private IEnumerator ChangeOpacityCoroutine()
    {
        Color startColor = spriteRenderer.color;
        Color targetColor = startColor;
        targetColor.a = targetOpacity;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Interpolate the alpha value over time.
            float alpha = Mathf.Lerp(startColor.a, targetColor.a, elapsedTime / duration);

            // Update the sprite renderer's color with the new alpha value.
            Color newColor = startColor;
            newColor.a = alpha;
            spriteRenderer.color = newColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is exactly the target color.
        spriteRenderer.color = targetColor;
    }
}