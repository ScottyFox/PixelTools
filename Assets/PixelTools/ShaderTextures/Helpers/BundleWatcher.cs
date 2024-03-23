using UnityEngine;

namespace ScottyFoxArt.PixelTools.ShaderTextures
{
    [ExecuteInEditMode]
    public class BundleWatcher : MonoBehaviour
    {
        public LayerBundleData layerBundleData = null;
        public Renderer meshRenderer = null;
        public int materialIndex = 0;
        private void OnValidate()
        {
            layerBundleData?.onTextureGenerated.RemoveListener(OnTextureGenerated);
            layerBundleData?.onTextureGenerated.AddListener(OnTextureGenerated);
        }
        public void OnEnable()
        {
            layerBundleData?.onTextureGenerated.AddListener(OnTextureGenerated);
        }
        public void OnDisable()
        {
            layerBundleData?.onTextureGenerated.RemoveListener(OnTextureGenerated);
        }
        public void OnDestroy()
        {
            layerBundleData?.onTextureGenerated.RemoveListener(OnTextureGenerated);
        }
        public void OnTextureGenerated(Texture2D texture)
        {
            if (meshRenderer == null)
                return;
            var materials = meshRenderer.sharedMaterials;
            if (materialIndex < 0 && materialIndex >= materials.Length)
                return;
            materials[materialIndex].mainTexture = texture;
        }
    }
}
