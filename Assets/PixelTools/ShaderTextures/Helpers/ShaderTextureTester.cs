using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
//EXAMPLE CODE : WAS USED TO TEST LAYER BUNDLES.
namespace ScottyFoxArt.PixelTools.ShaderTextures
{
    public class ShaderTextureTester : MonoBehaviour
    {
        [SerializeReference]
        public BlendModeShaderLibrary library;
        public bool generateTextureOutput = false;
        public Vector2Int outputSize = new Vector2Int(512, 512);
        public LayerBundle layerBundle = new LayerBundle();
        void Start()
        {
            GenerateTexture();
        }
        public void GenerateTexture()
        {
            ShaderTextureBuilder.SetShaderLibrary(library);
            var texture = ShaderTextureBuilder.RenderBundle(layerBundle, outputSize.x, outputSize.y, generateTextureOutput);
            Renderer renderer = GetComponent<Renderer>();
            renderer.sharedMaterial.mainTexture = texture;
            if (generateTextureOutput)
                File.WriteAllBytes(Path.Combine(Application.dataPath, $"ShaderTextureTest_{texture.GetHashCode()}.png"), texture.EncodeToPNG());
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(ShaderTextureTester))]
    public class ShaderTextureTesterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ShaderTextureTester myScript = (ShaderTextureTester)target;
            if (GUILayout.Button("Generate Texture"))
            {
                myScript.GenerateTexture();
            }
            GUILayout.Space(16);
            DrawDefaultInspector();
        }
    }
#endif
}