using ScottyFoxArt.PixelTools.ShaderTextures;
using UnityEngine;

public class LayerBundleExample : MonoBehaviour
{
    [SerializeReference]
    public BlendModeShaderLibrary shaderLibrary;
    public Color backgroundColor;
    public Color shapesColor;
    public Texture2D shapeMask;
    // Start is called before the first frame update
    void Start()
    {
        //Fetching the renderer and material
        var renderer = GetComponent<Renderer>();
        var material = renderer.sharedMaterial;
        //New LayerBundle
        var layerbundle = new LayerBundle();
        //Background Color
        layerbundle.backgroundColor = backgroundColor;
        //You can add layers this way! name, texture, mask, color, blendmode
        layerbundle.AddLayer("Shapes", null, shapeMask, shapesColor, BlendMode.Overwrite);
        //Set The Library
        ShaderTextureBuilder.SetShaderLibrary(shaderLibrary);
        //Make the Texture! 
        material.mainTexture = ShaderTextureBuilder.RenderBundle(layerbundle, 512, 512);
    }
}
