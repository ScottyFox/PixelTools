using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace ScottyFoxArt.PixelTools.ShaderTextures
{
#if UNITY_EDITOR
    [CustomEditor(typeof(LayerBundleData))]
    public class LayerBundleDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            LayerBundleData data = (LayerBundleData)target;
            GUILayout.Space(16);
            GUILayout.BeginVertical();
            data.generateOutput = GUILayout.Toggle(data.generateOutput, "Create Image File");
            if (data.generateOutput)
            {
                GUILayout.Label("Output Location");
                data.outputLocation = GUILayout.TextField(data.outputLocation);
            }
            if (GUILayout.Button("Generate Texture"))
            {
                data.GenerateTexture();
            }
            GUILayout.EndVertical();
        }
    }
#endif
}