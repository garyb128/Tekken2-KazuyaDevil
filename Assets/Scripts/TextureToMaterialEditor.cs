#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class TextureToMaterialEditor : Editor
{
    [MenuItem("Assets/Create Material from Texture", false, 201)]
    private static void CreateMaterial()
    {
        Object[] selectedTextures = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Assets);

        foreach (Object textureObj in selectedTextures)
        {
            string texturePath = AssetDatabase.GetAssetPath(textureObj);
            Texture2D texture = (Texture2D)AssetDatabase.LoadAssetAtPath(texturePath, typeof(Texture2D));

            if (texture != null)
            {
                Material material = new Material(Shader.Find("Standard"));
                material.name = texture.name + "_mat";
                material.mainTexture = texture;

                string materialPath = AssetDatabase.GenerateUniqueAssetPath(texturePath.Replace(".png", ".mat"));
                AssetDatabase.CreateAsset(material, materialPath);
                Debug.Log("Created material: " + materialPath);
            }
        }

        AssetDatabase.Refresh();
    }
}
#endif
