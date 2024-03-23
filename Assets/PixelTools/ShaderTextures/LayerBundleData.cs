using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ScottyFoxArt.PixelTools.ShaderTextures
{
    [Serializable]
    [CreateAssetMenu(fileName = "LayerBundleData", menuName = "ScriptableObjects/Layer Bundle Data", order = 1)]
    public partial class LayerBundleData : ScriptableObject
    {
        public BlendModeShaderLibrary library;
        public Vector2Int outputSize = new Vector2Int(512, 512);
        public LayerBundle layerBundle = new LayerBundle();
        [HideInInspector, NonSerialized]
        public UnityEvent<Texture2D> onTextureGenerated = new UnityEvent<Texture2D>();
    }
    [Serializable]
    public struct MaterialInfo
    {
        public Material material;
        public List<string> textureProperties;
    }
    public partial class LayerBundleData : ScriptableObject
    {
        public bool updateMaterials = false;
        public List<MaterialInfo> materialsToUpdate = new List<MaterialInfo>();
        //TODO add way to add materials to this list via programing.
        private void UpdateMaterials(Texture2D texture)
        {
            if (!updateMaterials)
                return;
            foreach (var info in materialsToUpdate)
            {
                if (info.material == null || info.textureProperties.Count == 0)
                    continue;
                foreach (var propertyName in info.textureProperties)
                {
                    info.material.SetTexture(propertyName, texture);
                }
            }
        }
    }
    public partial class LayerBundleData : ScriptableObject
    {
        [HideInInspector]
        public bool generateOutput = false;
        [HideInInspector]
        public string outputLocation = "Output.png";
        [HideInInspector, NonSerialized]
        public Texture2D texture = null;
        public Texture2D GenerateTexture()
        {
            if (library == null)
            {
                Debug.LogWarning("No BlendMode Shader Library Set\nRequired To Generate Texture.");
            }
            else
            {
                ShaderTextureBuilder.SetShaderLibrary(library);
                texture = ShaderTextureBuilder.RenderBundle(layerBundle, outputSize.x, outputSize.y, generateOutput);
            }
            if (texture != null && generateOutput)
            {
                var fileExtension = outputLocation.Substring(outputLocation.LastIndexOf(".")).ToUpper();
                byte[] bytes = null;
                switch (fileExtension)
                {
                    case ".EXR":
                        bytes = texture.EncodeToEXR();
                        break;
                    case ".JPG":
                        bytes = texture.EncodeToJPG();
                        break;
                    case ".PNG":
                        bytes = texture.EncodeToPNG();
                        break;
                    case ".TGA":
                        bytes = texture.EncodeToTGA();
                        break;
                    default:
                        outputLocation += ".png";
                        bytes = texture.EncodeToPNG();
                        break;
                }
                var outputpath = Path.Combine(Application.dataPath, outputLocation);
                File.WriteAllBytes(outputpath, bytes);
                Debug.Log($"Writting Image:\n{outputpath}");
#if UNITY_EDITOR
                DestroyImmediate(texture);
                var assetpath = Path.Combine("Assets", outputLocation);
                AssetDatabase.ImportAsset(assetpath);
                texture = AssetDatabase.LoadAssetAtPath<Texture2D>(assetpath);
#endif
            }
            UpdateMaterials(texture);
            onTextureGenerated.Invoke(texture);
            return texture;
        }
    }

#if UNITY_EDITOR
#endif
}