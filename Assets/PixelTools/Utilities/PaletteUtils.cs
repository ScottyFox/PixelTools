using System.Collections.Generic;
using UnityEngine;
namespace ScottyFoxArt.PixelTools.Utilities
{
    /// <summary>
    /// General Utility Methods For Palettes
    /// </summary>
    public static class PaletteUtils
    {
        /// <summary>
        /// Samples Colors to find the Avaraged, Dominate, and Brightest Colors.
        /// </summary>
        /// <param name="colors">Colors to sample.</param>
        /// <param name="average">Averaged color.</param>
        /// <param name="dominate">Dominate color.</param>
        /// <param name="brightest">Brightest color.</param>
        public static void SampleColors_Dominate(Color[] colors, out Color average, out Color dominate, out Color brightest)
        {
            // Initialize colors.
            dominate = Color.white;
            brightest = Color.black;
            average = Color.black;
            // Dictionary to count colors.
            Dictionary<Color, int> colorCounts = new Dictionary<Color, int>();
            int maxCount = 0;
            float maxSaturation = 0;
            foreach (Color pixelColor in colors)
            {
                // Count color.
                if (colorCounts.ContainsKey(pixelColor))
                    colorCounts[pixelColor]++;
                else
                    colorCounts.Add(pixelColor, 1);
                // Check if color is more than the count.
                if (colorCounts[pixelColor] > maxCount)
                {
                    maxCount = colorCounts[pixelColor];
                    dominate = pixelColor;
                }
                // Get Saturation + Value of color...
                Color.RGBToHSV(pixelColor, out _, out var S, out var V);
                Color.RGBToHSV(brightest, out _, out _, out var bV);
                // Check if color is bright, or if brightest has no value!
                if (V > 0.5 || bV == 0)
                {
                    // If color is just as bright, mix them!
                    if (S == maxSaturation)
                    {
                        brightest = Color.Lerp(brightest, pixelColor, 0.5f);
                    }
                    // If color brighter, lets use it!
                    else if (S > maxSaturation)
                    {
                        brightest = pixelColor;
                        maxSaturation = S;
                    }
                }
                // Add color to average.
                average += pixelColor;
            }
            // Average out all the colors!
            average /= colors.Length;
            // Sample our averaged colors to get the final brightest color.
            Color.RGBToHSV(average, out var aH, out var aS, out var aV);
            Color.RGBToHSV(brightest, out _, out var sS, out var sV);
            // Mix the saturation and value of both averaged colors!
            brightest = Color.HSVToRGB(aH, Mathf.Lerp(aS, sS, 0.5f), Mathf.Lerp(aV, sV, 0.5f));
        }
    }
}
