using UnityEngine;
namespace ScottyFoxArt.PixelTools.ShaderTextures
{
    public class ShaderTextureBuilder_Job
    {
        private BlendModeShaderLibrary _library = null;
        private System.Action<Texture2D> _listener = null;
        private LayerBundle _bundle = null;
        private int _width = -1;
        private int _height = -1;
        public bool _readtomemory = false;
        private Texture2D _texture = null;
        private RenderTexture _buffer = null;
        private Material _material = null;
        public ShaderTextureBuilder_Job(BlendModeShaderLibrary library, System.Action<Texture2D> listener, LayerBundle bundle, int width, int height, bool readtomemory)
        {
            _library = library;
            _listener = listener;
            _bundle = bundle;
            _width = width;
            _height = height;
            _readtomemory = readtomemory;
        }
        public Texture2D Render()
        {
            if (!Validate())
                return null;
            Prepare();
            RenderBackground();
            foreach (var layer in _bundle.layers)
            {
                RenderLayer(layer);
            }
            if (_readtomemory)
                ReadToMemory();
            Cleanup();
            _listener?.Invoke(_texture);
            return _texture;
        }
        private bool Validate()
        {
            //Use The Global Default Shader Library.
            if (_library == null)
                _library = ShaderTextureBuilder.shaderLibrary;
            return _library != null && _width > 0 && _height > 0;
        }
        private void Prepare()
        {
            //Setup The RenderTexture And Texture!
            _buffer = new RenderTexture(_width, _height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
            _texture = new Texture2D(_width, _height, TextureFormat.ARGB32, false, false, true);
        }
        private bool FetchShader(Layer layer)
        {
            //Grab Shader From Library//
            var shader = _library.GetBlendMode(layer.mode);
            if (shader == null)
            {
                Debug.Log("Shader Missing!!! Check Library.");
                return false;
            }
            //Generate Working Material//
            if (_material == null)
                _material = new Material(shader);
            if (_material.shader != shader)
                _material.shader = shader;
            return true;
        }
        private void RenderBackground()
        {
            Color32[] pixels = new Color32[_width * _height];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = _bundle.backgroundColor;
            _texture.SetPixels32(pixels);
            _texture.Apply();
            var old_buffer = RenderTexture.active;
            Graphics.CopyTexture(_texture, _buffer);
            RenderTexture.active = old_buffer;
        }
        private void RenderLayer(Layer layer)
        {
            if (!layer.enabled)
                return;
            if (!FetchShader(layer))
                return;
            //Set Material Properties//
            _material.SetColor("_Color", layer.color);
            _material.SetTexture("_BaseMap", _texture);
            _material.SetTexture("_BlendMap", layer.texture);
            _material.SetTexture("_MaskMap", layer.mask);
            //Apply Material Shader To Texture//
            var old_buffer = RenderTexture.active;
            Graphics.Blit(null, _buffer, _material, 0);
            Graphics.CopyTexture(_buffer, _texture);
            RenderTexture.active = old_buffer;
        }
        private void ReadToMemory()
        {
            var old_buffer = RenderTexture.active;
            RenderTexture.active = _buffer;
            _texture.ReadPixels(new Rect(0, 0, _width, _height), 0, 0, false);
            _texture.Apply();
            RenderTexture.active = old_buffer;
        }
        private void Cleanup()
        {
            //Make Sure Our RenderTexture Isn't Being Used//
            if (RenderTexture.active == _buffer)
                RenderTexture.active = null;
            //Clean Up!//
            _buffer.Release();
            Object.DestroyImmediate(_material);
            Object.DestroyImmediate(_buffer);
        }
    }
}