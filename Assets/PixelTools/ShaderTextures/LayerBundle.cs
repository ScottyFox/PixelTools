using System;
using System.Collections.Generic;
using UnityEngine;
namespace ScottyFoxArt.PixelTools.ShaderTextures
{
    [Serializable]
    public struct Layer
    {
        public string name;
        public bool enabled;
        public BlendMode mode;
        public Color color;
        public Texture2D texture;
        public Texture2D mask;
        public Layer(string name = "Layer", bool enabled = true, BlendMode mode = BlendMode.Overwrite, Color color = default, Texture2D texture = null, Texture2D mask = null)
        {
            this.name = name;
            this.enabled = enabled;
            this.mode = mode;
            this.color = color;
            this.texture = texture;
            this.mask = mask;
        }
    }
    [Serializable]
    public partial class LayerBundle
    {
        public Color backgroundColor = Color.white;
        public List<Layer> layers = new List<Layer>();
        public int AddLayer(string name, Texture2D texture, Texture2D mask, Color color, BlendMode mode = BlendMode.Overwrite, bool enabled = true, int index = int.MaxValue)
        {
            Layer newLayer = new Layer(name, enabled, mode, color, texture, mask);
            AddLayer(newLayer, index);
            return index;
        }
        public int AddLayer(Layer layer, int index = int.MaxValue)
        {
            index = GetNearestValidIndex(index);
            if (index == layers.Count)
                layers.Add(layer);
            else
                layers.Insert(index, layer);
            return index;
        }
        public void AddLayers(IEnumerable<Layer> layers)
        {
            foreach (var layer in layers)
            {
                AddLayer(layer);
            }
        }
        public bool RemoveLayer(int index)
        {
            if (!IsValidIndex(index))
                return false;
            layers.RemoveAt(index);
            return true;
        }
        public bool RemoveLayer(string name)
        {
            return RemoveLayer(FindName(name));
        }
        public bool SetLayer(int index, Layer layer)
        {
            if (!IsValidIndex(index))
                return false;
            layers[index] = layer;
            return true;
        }
        public bool SetLayer(string name, Layer layer)
        {
            return SetLayer(FindName(name), layer);
        }
        public int FindName(string name)
        {
            int index = 0;
            foreach (var layer in layers)
            {
                if (layer.name == name)
                    break;
                index++;
            }
            return (index == layers.Count) ? -1 : index;
        }
        public bool TryGetLayer(int index, out Layer layer)
        {
            layer = default(Layer);
            if (!IsValidIndex(index))
                return false;
            layer = layers[index];
            return true;
        }
        public bool TryGetLayer(string name, out Layer layer)
        {
            return TryGetLayer(FindName(name), out layer);
        }
        public bool IsValidIndex(int index)
        {
            return index >= 0 && index < layers.Count;
        }
        public int GetNearestValidIndex(int index)
        {
            if (index > layers.Count)
                index = layers.Count;
            else if (index < 0)
                index = 0;
            return index;
        }
    }
    public partial class LayerBundle
    {
        //
        public void SetLayerEnabled(int index, bool enabled)
        {
            if (!TryGetLayer(index, out var layer))
                return;
            layer.enabled = enabled;
            SetLayer(index, layer);
        }
        public void SetLayerEnabled(string name, bool enabled)
        {
            SetLayerEnabled(FindName(name), enabled);
        }
        //
        public void SetLayerMode(int index, BlendMode mode)
        {
            if (!TryGetLayer(index, out var layer))
                return;
            layer.mode = mode;
            SetLayer(index, layer);
        }
        public void SetLayerMode(string name, BlendMode mode)
        {
            SetLayerMode(FindName(name), mode);
        }
        //
        public void SetLayerTexture(int index, Texture2D texture)
        {
            if (!TryGetLayer(index, out var layer))
                return;
            layer.texture = texture;
            SetLayer(index, layer);
        }
        public void SetLayerTexture(string name, Texture2D texture)
        {
            SetLayerTexture(FindName(name), texture);
        }
        //
        public void SetLayerMask(int index, Texture2D mask)
        {
            if (!TryGetLayer(index, out var layer))
                return;
            layer.texture = mask;
            SetLayer(index, layer);
        }
        public void SetLayerMask(string name, Texture2D mask)
        {
            SetLayerMask(FindName(name), mask);
        }
        //
        public void SetLayerColor(int index, Color color)
        {
            if (!TryGetLayer(index, out var layer))
                return;
            layer.color = color;
            SetLayer(index, layer);
        }
        public void SetLayerColor(string name, Color color)
        {
            SetLayerColor(FindName(name), color);
        }
        //
    }

}
