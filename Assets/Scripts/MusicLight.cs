using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MusicLighting : MonoBehaviour
{
    public Light directionalLight;
    public float colorChangeInterval = 1f; // Interval between color changes in seconds
    public Color[] colorSpectrum; // Array of colors to cycle through

    private void Start()
    {
        // Start coroutine to update light color
        StartCoroutine(UpdateLightColor());
    }

    private IEnumerator UpdateLightColor()
    {
        int colorIndex = 0;

        while (true)
        {
            // Change light color
            directionalLight.color = colorSpectrum[colorIndex];

            // Move to the next color
            colorIndex = (colorIndex + 1) % colorSpectrum.Length;

            // Wait for the next color change interval
            yield return new WaitForSeconds(colorChangeInterval);
        }
    }
}
