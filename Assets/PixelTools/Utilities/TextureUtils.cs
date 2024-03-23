using UnityEngine;
namespace ScottyFoxArt.PixelTools.Utilities
{
    /// <summary>
    /// General Utility Methods For Unity Textures
    /// </summary>
    public static class TextureUtils
    {
        /// <summary>
        /// Creates a block of color.
        /// </summary>
        /// <param name="color">The fill color.</param>
        /// <param name="width">Color block width.</param>
        /// <param name="height">Color block height.</param>
        /// <returns>Returns a color block, an array of colors.</returns>
        static public Color[] ColorBlock(Color color, int width, int height)
        {
            if (width < 1 || height < 1)
                return null;
            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = color;
            }
            return colors;
        }
        /// <summary>
        /// Creates a block of color.
        /// </summary>
        /// <param name="color">The fill color.</param>
        /// <param name="size">Color block width and height.</param>
        /// <returns>Returns a color block, an array of colors.</returns>
        static public Color[] ColorBlock(Color color, int size)
        {
            return ColorBlock(color, size, size);
        }
        /// <summary>
        /// Creates a block of color. 
        /// (Vector2Int)
        /// </summary>
        /// <param name="color">The fill color.</param>
        /// <param name="size">Color block width and height.</param>
        /// <returns>Returns a color block, an array of colors.</returns>
        static public Color[] ColorBlock(Color color, Vector2Int size)
        {
            return ColorBlock(color, size.x, size.y);
        }
        /// <summary>
        /// Creates a block of color.
        /// (Vector2 : Values will be cast into integers)
        /// </summary>
        /// <param name="color">The fill color.</param>
        /// <param name="size">Color block width and height.</param>
        /// <returns>Returns a color block, an array of colors.</returns>
        static public Color[] ColorBlock(Color color,Vector2 size)
        {
            return ColorBlock(color, (int)size.x, (int)size.y);
        }
    }
}
