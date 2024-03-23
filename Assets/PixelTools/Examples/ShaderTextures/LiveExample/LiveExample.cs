using ScottyFoxArt.PixelTools.ShaderTextures;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[RequireComponent(typeof(Renderer))]
public class LiveExample : MonoBehaviour
{
    [SerializeReference]
    public BlendModeShaderLibrary shaderLibrary;
    public Vector2Int outputSize = new Vector2Int(512,512);
    [SerializeField]
    public LayerBundle layerbundle = new LayerBundle();
    private new Renderer renderer;
    private Material material;
    private Texture2D texture;
    void Start()
    {
        RenderTextureBundle();
    }
    public void OnValidate()
    {
        RenderTextureBundle();
    }
    //Due to the nature of this creating hundreds of images in such a short time, I would not recommend running this in any environment.
    //And this is Purely an example.
    public void RenderTextureBundle()
    {
        if (renderer == null)
        {
            renderer = GetComponent<Renderer>();
            material = renderer.sharedMaterial;
        }
        ShaderTextureBuilder.SetShaderLibrary(shaderLibrary);
        if (texture != null)
            DestroyImmediate(texture);
        texture = ShaderTextureBuilder.RenderBundle(layerbundle, outputSize.x, outputSize.y);
        material.mainTexture = texture;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(LiveExample))]
public class LiveExampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var LiveExample = (LiveExample)target;
        EditorGUILayout.HelpBox("Disclaimer:\nDue to thie nature of this component creating hundreds of images at once,\nit is NOT recommend running this component in any environment.\nThis Component Exists Purely as an example.", MessageType.Info);
        DrawDefaultInspector();
    }
}
#endif