using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;
    public bool adjustSize = true;
    public float tilingX = 1f;
    public float tilingY = 1f;

    private Renderer rend;
    private Material material;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        material = rend.material;

        if (adjustSize)
        {
            AdjustObjectSize();
        }
    }

    private void Update()
    {
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;

        material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));

        material.SetTextureScale("_MainTex", new Vector2(tilingX, tilingY));
    }

    private void AdjustObjectSize()
    {
        Texture mainTexture = material.GetTexture("_MainTex");
        if (mainTexture != null)
        {
            float textureAspectRatio = mainTexture.width / (float)mainTexture.height;

            Vector3 scale = transform.localScale;
            scale.x = scale.y * textureAspectRatio;
            transform.localScale = scale;
        }
    }
}
