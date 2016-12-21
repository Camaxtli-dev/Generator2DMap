using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour {

    public Renderer textureRender;

    public void DrawTexture(Texture2D noiseTexture, MapType[] regions) {
        Material[] materials = new Material[regions.Length];
        for(int i = 0; i < materials.Length; i++) {
            materials[i] = MaterialSetup(noiseTexture, regions[i].texture, regions[i].height, regions[i].tiling);
        }
        textureRender.materials = materials;
        textureRender.transform.localScale = new Vector3(noiseTexture.width, 1, noiseTexture.height);
    }

    private Material MaterialSetup(Texture noiseTexutre, Texture secondTexture, float height, Vector2 secondTextureTiling) {
        Material material = new Material(Shader.Find("Transparent/Cutout/Diffuse"));
        material.SetTexture("_MainTex", noiseTexutre);
        material.SetTexture("_SecondTex", secondTexture);
        material.SetFloat("_Cutoff", height);
        material.SetTextureScale("_SecondTex", secondTextureTiling);

        return material;
    }
}