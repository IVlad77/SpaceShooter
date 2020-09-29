using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;

    private float xScroll;

    private MeshRenderer meshRender;

    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        xScroll = Time.time * scrollSpeed;

        Vector2 offset = new Vector2(0.0f, xScroll);
        meshRender.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }    
}
