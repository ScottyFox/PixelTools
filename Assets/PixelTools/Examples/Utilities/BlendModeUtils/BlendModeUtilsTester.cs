using ScottyFoxArt.PixelTools.ShaderTextures;
using ScottyFoxArt.PixelTools.Utilities;
using UnityEngine;
class BlendModeUtilsTester : MonoBehaviour
{
    public Color colorA;
    public Color colorB;
    public Color colorC = Color.white;
    [SerializeField]
    public BlendMode blendmode;
    public void Start()
    {
        colorC = ApplyBlendMode(blendmode, colorA, colorB);
    }
    public void OnValidate()
    {
        colorC = ApplyBlendMode(blendmode, colorA, colorB);
    }
    public Color ApplyBlendMode(BlendMode blendmode, Color a, Color b)
    {
        switch (blendmode)
        {
            case BlendMode.Burn:
                return BlendModeUtils.Burn(a, b);
            case BlendMode.Darken:
                return BlendModeUtils.Darken(a, b);
            case BlendMode.Difference:
                return BlendModeUtils.Difference(a, b);
            case BlendMode.Dodge:
                return BlendModeUtils.Dodge(a, b);
            case BlendMode.Divide:
                return BlendModeUtils.Divide(a, b);
            case BlendMode.Exclusion:
                return BlendModeUtils.Exclusion(a, b);
            case BlendMode.HardLight:
                return BlendModeUtils.HardLight(a, b);
            case BlendMode.HardMix:
                return BlendModeUtils.HardMix(a, b);
            case BlendMode.Lighten:
                return BlendModeUtils.Lighten(a, b);
            case BlendMode.LinearBurn:
                return BlendModeUtils.LinearBurn(a, b);
            case BlendMode.LinearDodge:
                return BlendModeUtils.LinearDodge(a, b);
            case BlendMode.LinearLight:
                return BlendModeUtils.LinearLight(a, b);
            case BlendMode.LinearLightAddSub:
                return BlendModeUtils.LinearLightAddSub(a, b);
            case BlendMode.Multiply:
                return BlendModeUtils.Multiply(a, b);
            case BlendMode.Negation:
                return BlendModeUtils.Negation(a, b);
            case BlendMode.Overlay:
                return BlendModeUtils.Overlay(a, b);
            case BlendMode.PinLight:
                return BlendModeUtils.PinLight(a, b);
            case BlendMode.Screen:
                return BlendModeUtils.Screen(a, b);
            case BlendMode.SoftLight:
                return BlendModeUtils.SoftLight(a, b);
            case BlendMode.Subtract:
                return BlendModeUtils.Subtract(a, b);
            case BlendMode.VividLight:
                return BlendModeUtils.VividLight(a, b);
            case BlendMode.Overwrite:
                return BlendModeUtils.Overwrite(a, b);
            case BlendMode.UVDraw:
                return BlendModeUtils.Step(a, b);
            default:
                return Color.white;
        }
    }
}
