using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mt;
    [SerializeField] public float velocidadParallax;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;
        offset = mt.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += Time.deltaTime / velocidadParallax;

        mt.mainTextureOffset = offset;
    }
}
