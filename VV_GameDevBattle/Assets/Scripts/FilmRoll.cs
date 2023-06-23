using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilmRoll : MonoBehaviour
{
    public List<RawImage> images;
    private List<Texture> textures = new List<Texture>();
    private int currentTexture = 0;

    public void Render(Camera camera)
    {
        if (textures.Count < images.Count)
        {
            textures.Add(new RenderTexture(256, 128, 16));
            (textures[currentTexture] as RenderTexture).Create();
        }

        camera.targetTexture = textures[currentTexture] as RenderTexture;
        camera.Render();
        images[currentTexture].texture = textures[currentTexture];
        currentTexture = (currentTexture + 1) % images.Count;
        camera.targetTexture = null;
    }
}
