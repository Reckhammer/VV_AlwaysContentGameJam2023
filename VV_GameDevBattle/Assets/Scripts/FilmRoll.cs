using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilmRoll : MonoBehaviour
{
    public List<RawImage> images;
    private List<Texture> textures;
    private int currentTexture;

    public void Render(Camera camera)
    {
        textures.Add(new RenderTexture(camera.activeTexture));
        (textures[currentTexture] as RenderTexture).Create();
        camera.targetTexture = textures[currentTexture] as RenderTexture;
        camera.Render();
        images[currentTexture].texture = textures[currentTexture];
        currentTexture++;
    }
}
