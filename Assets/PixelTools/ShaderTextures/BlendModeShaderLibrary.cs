using UnityEngine;
namespace ScottyFoxArt.PixelTools.ShaderTextures
{
    public enum BlendMode
    {
        None,
        Burn,
        Darken,
        Difference,
        Dodge,
        Divide,
        Exclusion,
        HardLight,
        HardMix,
        Lighten,
        LinearBurn,
        LinearDodge,
        LinearLight,
        LinearLightAddSub,
        Multiply,
        Negation,
        Overlay,
        PinLight,
        Screen,
        SoftLight,
        Subtract,
        VividLight,
        Overwrite,
        UVDraw
    }
    [CreateAssetMenu(fileName = "BlendModeShaderLibrary", menuName = "ScriptableObjects/BlendMode Shader Library", order = 1)]
    public class BlendModeShaderLibrary : ScriptableObject
    {
        public Shader Burn = null;
        public Shader Darken = null;
        public Shader Difference = null;
        public Shader Dodge = null;
        public Shader Divide = null;
        public Shader Exclusion = null;
        public Shader HardLight = null;
        public Shader HardMix = null;
        public Shader Lighten = null;
        public Shader LinearBurn = null;
        public Shader LinearDodge = null;
        public Shader LinearLight = null;
        public Shader LinearLightAddSub = null;
        public Shader Multiply = null;
        public Shader Negation = null;
        public Shader Overlay = null;
        public Shader PinLight = null;
        public Shader Screen = null;
        public Shader SoftLight = null;
        public Shader Subtract = null;
        public Shader VividLight = null;
        public Shader Overwrite = null;
        public Shader UVDraw = null;
        public Shader GetBlendMode(BlendMode blendmode)
        {
            switch (blendmode)
            {
                case BlendMode.Burn:
                    return Burn;
                case BlendMode.Darken:
                    return Darken;
                case BlendMode.Difference:
                    return Difference;
                case BlendMode.Dodge:
                    return Dodge;
                case BlendMode.Divide:
                    return Divide;
                case BlendMode.Exclusion:
                    return Exclusion;
                case BlendMode.HardLight:
                    return HardLight;
                case BlendMode.HardMix:
                    return HardMix;
                case BlendMode.Lighten:
                    return Lighten;
                case BlendMode.LinearBurn:
                    return LinearBurn;
                case BlendMode.LinearDodge:
                    return LinearDodge;
                case BlendMode.LinearLight:
                    return LinearLight;
                case BlendMode.LinearLightAddSub:
                    return LinearLightAddSub;
                case BlendMode.Multiply:
                    return Multiply;
                case BlendMode.Negation:
                    return Negation;
                case BlendMode.Overlay:
                    return Overlay;
                case BlendMode.PinLight:
                    return PinLight;
                case BlendMode.Screen:
                    return Screen;
                case BlendMode.SoftLight:
                    return SoftLight;
                case BlendMode.Subtract:
                    return Subtract;
                case BlendMode.VividLight:
                    return VividLight;
                case BlendMode.Overwrite:
                    return Overwrite;
                case BlendMode.UVDraw:
                    return UVDraw;
                default:
                    return null;
            }
        }
    }
}
