using UnityEngine;
namespace ScottyFoxArt.PixelTools.Utilities
{
    /// <summary>
    /// Unity BlendModes for Colors!
    /// Use Example : BlendMode(BaseColor,BlendColor,Opacity)
    /// See Unity BlendModes For Reference :
    /// https://docs.unity3d.com/Packages/com.unity.shadergraph@14.0/manual/Blend-Node.html
    /// </summary>
    public static class BlendModeUtils
    {
        private static Color white = new Color(1, 1, 1, 1);
        /// <summary>
        /// Applies the Burn blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Burn blend mode.</returns>
        public static Color Burn(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, white - Divide(white - b, a), opacity);
        }
        /// <summary>
        /// Applies the Darken blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Darken blend mode.</returns>
        public static Color Darken(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = Mathf.Min(a.r, b.r);
            output.g = Mathf.Min(a.g, b.g);
            output.b = Mathf.Min(a.b, b.b);
            output.a = Mathf.Min(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the Difference blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Difference blend mode.</returns>
        public static Color Difference(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = Mathf.Abs(b.r - a.r);
            output.g = Mathf.Abs(b.g - a.g);
            output.b = Mathf.Abs(b.b - a.b);
            output.a = Mathf.Abs(b.a - a.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the Divide blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Divide blend mode.</returns>
        public static Color Divide(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = a.r / (b.r + 0.000000000001f);
            output.g = a.g / (b.g + 0.000000000001f);
            output.b = a.b / (b.b + 0.000000000001f);
            output.a = a.a / (b.a + 0.000000000001f);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the Dodge blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Dodge blend mode.</returns>
        public static Color Dodge(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = a.r / (1 - Mathf.Clamp(b.r, 0.000001f, 0.999999f));
            output.g = a.g / (1 - Mathf.Clamp(b.g, 0.000001f, 0.999999f));
            output.b = a.b / (1 - Mathf.Clamp(b.b, 0.000001f, 0.999999f));
            output.a = a.a / (1 - Mathf.Clamp(b.a, 0.000001f, 0.999999f));
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the Exclusion blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Exclusion blend mode.</returns>
        public static Color Exclusion(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, b + a - (2.0f * b * a), opacity);
        }
        /// <summary>
        /// Applies the HardLight blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying HardLight blend mode.</returns>
        public static Color HardLight(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = HardLight_float(a.r, b.r);
            output.g = HardLight_float(a.g, b.g);
            output.b = HardLight_float(a.b, b.b);
            output.a = HardLight_float(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Internal Helper Method for the HardLight blend mode.
        /// </summary>
        /// <param name="a">The Base value.</param>
        /// <param name="b">The Blend value.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Value after applying HardLight helper method.</returns>
        private static float HardLight_float(float a, float b, float opacity = 1)
        {
            float output;
            if (b < 0.5f)
                output = 1.0f - 2.0f * (1.0f - a) * (1.0f - b);
            else
                output = 2.0f * a * b;
            return Mathf.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the HardMix blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying HardMix blend mode.</returns>
        public static Color HardMix(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, Step(white - a, b), opacity);
        }
        /// <summary>
        /// Applies the Lighten blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Lighten blend mode.</returns>
        public static Color Lighten(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = Mathf.Max(a.r, b.r);
            output.g = Mathf.Max(a.g, b.g);
            output.b = Mathf.Max(a.b, b.b);
            output.a = Mathf.Max(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the LinearBurn blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying LinearBurn blend mode.</returns>
        public static Color LinearBurn(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, a + b - white, opacity);
        }
        /// <summary>
        /// Applies the LinearDodge blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying LinearDodge blend mode.</returns>
        public static Color LinearDodge(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, a + b, opacity);
        }
        /// <summary>
        /// Applies the LinearLight blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying LinearLight blend mode.</returns>
        public static Color LinearLight(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = LinearLight_float(a.r, b.r);
            output.g = LinearLight_float(a.g, b.g);
            output.b = LinearLight_float(a.b, b.b);
            output.a = LinearLight_float(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Internal Helper Method for the LinearLight blend mode.
        /// </summary>
        /// <param name="a">The Base value.</param>
        /// <param name="b">The Blend value.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Value after applying LinearLight helper method.</returns>
        private static float LinearLight_float(float a, float b, float opacity = 1)
        {
            float output;
            if (b < 0.5f)
                output = Mathf.Max(a + (2f * b) - 1f, 0f);
            else
                output = Mathf.Min(a + 2f * (b - 0.5f), 1f);
            return output;
        }
        /// <summary>
        /// Applies the LinearLightAddSub blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying LinearLightAddSub blend mode.</returns>
        public static Color LinearLightAddSub(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, b + 2.0f * a - white, opacity);
        }
        /// <summary>
        /// Applies the Multiply blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Multiply blend mode.</returns>
        public static Color Multiply(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, a * b, opacity);
        }
        /// <summary>
        /// Applies the Negation blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Negation blend mode.</returns>
        public static Color Negation(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = 1.0f - Mathf.Abs(1.0f - b.r - a.r);
            output.g = 1.0f - Mathf.Abs(1.0f - b.g - a.g);
            output.b = 1.0f - Mathf.Abs(1.0f - b.b - a.b);
            output.a = 1.0f - Mathf.Abs(1.0f - b.a - a.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the Overlay blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Overlay blend mode.</returns>
        public static Color Overlay(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = Overlay_float(a.r, b.r);
            output.g = Overlay_float(a.g, b.g);
            output.b = Overlay_float(a.b, b.b);
            output.a = Overlay_float(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Internal Helper Method for the Overlay blend mode.
        /// </summary>
        /// <param name="a">The Base value.</param>
        /// <param name="b">The Blend value.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Value after applying Overlay helper method.</returns>
        private static float Overlay_float(float a, float b, float opacity = 1)
        {
            float output;
            if (a < 0.5f)
                output = 1.0f - 2.0f * (1.0f - a) * (1.0f - b);
            else
                output = 2.0f * a * b;
            return Mathf.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the PinLight blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying PinLight blend mode.</returns>
        public static Color PinLight(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = PinLight_float(a.r, b.r);
            output.g = PinLight_float(a.g, b.g);
            output.b = PinLight_float(a.b, b.b);
            output.a = PinLight_float(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Internal Helper Method for the PinLight blend mode.
        /// </summary>
        /// <param name="a">The Base value.</param>
        /// <param name="b">The Blend value.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Value after applying PinLight helper method.</returns>
        private static float PinLight_float(float a, float b, float opacity = 1)
        {
            float output;
            if (b < 0.5f)
                output = Mathf.Min(2.0f * a, b);
            else
                output = Mathf.Max(2.0f * (b - 0.5f), b);
            return Mathf.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies the Screen blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Screen blend mode.</returns>
        public static Color Screen(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, white - (white - b) * (white - a), opacity);
        }
        /// <summary>
        /// Applies the SoftLight blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying SoftLight blend mode.</returns>
        public static Color SoftLight(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = SoftLight_float(a.r, b.r);
            output.g = SoftLight_float(a.g, b.g);
            output.b = SoftLight_float(a.b, b.b);
            output.a = SoftLight_float(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Internal Helper Method for the SoftLight blend mode.
        /// </summary>
        /// <param name="a">The Base value.</param>
        /// <param name="b">The Blend value.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Value after applying SoftLight helper method.</returns>
        private static float SoftLight_float(float a, float b, float opacity = 1)
        {
            float output;
            if (b < 0.5f)
                output = 2.0f * a * b + a * a * (1.0f - 2.0f * b);
            else
                output = Mathf.Sqrt(a) * (2.0f * b - 1.0f) + 2.0f * a * (1.0f - b);
            return Mathf.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Applies a Step method between two colors with color b acting as the edge case.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Step method.</returns>
        public static Color Step(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = Step(a.r, b.r);
            output.g = Step(a.g, b.g);
            output.b = Step(a.b, b.b);
            output.a = Step(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Internal Helper Method for the Step method.
        /// </summary>
        /// <param name="a">The Base value.</param>
        /// <param name="b">The Edge value.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>If value is less than edge it is 0, otherwise 1.</returns>
        private static float Step(float value, float edge)
        {
            return (value < edge) ? 0f : 1f;
        }
        /// <summary>
        /// Applies the Subtract blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying Subtract blend mode.</returns>
        public static Color Subtract(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, a - b, opacity);
        }
        /// <summary>
        /// Applies the VividLight blend mode between two colors.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after applying VividLight blend mode.</returns>
        public static Color VividLight(Color a, Color b, float opacity = 1)
        {
            var output = default(Color);
            output.r = VividLight_float(a.r, b.r);
            output.g = VividLight_float(a.g, b.g);
            output.b = VividLight_float(a.b, b.b);
            output.a = VividLight_float(a.a, b.a);
            return Color.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Internal Helper Method for the VividLight blend mode.
        /// </summary>
        /// <param name="a">The Base value.</param>
        /// <param name="b">The Blend value.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Value after applying VividLight helper method.</returns>
        private static float VividLight_float(float a, float b, float opacity = 1)
        {
            a = Mathf.Clamp(a, 0.000001f, 0.999999f);
            float output;
            if (b < 0.5f)
                output = 1.0f - (1.0f - b) / (2.0f * a);
            else
                output = b / (2.0f * (1.0f - a));
            return Mathf.LerpUnclamped(a, output, opacity);
        }
        /// <summary>
        /// Overwrite color a with color b based off the opacity.
        /// </summary>
        /// <param name="a">The Base Color.</param>
        /// <param name="b">The Blend Color.</param>
        /// <param name="opacity">Opacity of the Result (default : 1).</param>
        /// <returns>The resulting Color after replacing color a with color b.</returns>
        public static Color Overwrite(Color a, Color b, float opacity = 1)
        {
            return Color.LerpUnclamped(a, b, opacity);
        }
    }
}
