using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed = new Vector2(1, 20);
    Vector2 offset;
    Material backgroundMaterial;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        Scroll();
    }

    void Scroll()
    {
        
        //My version (Incorrect)
        // offset  = ((Vector2)transform.position + backgroundMaterial.mainTextureOffset) * moveSpeed * Time.deltaTime;
        // Debug.Log("Offset is "+offset);
        // backgroundMaterial.mainTextureOffset = offset;
        // Debug.Log("backgroundMaterial.mainTextureOffset.y is "+ backgroundMaterial.mainTextureOffset.y);

        offset = moveSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset += offset;
        
    }
}
