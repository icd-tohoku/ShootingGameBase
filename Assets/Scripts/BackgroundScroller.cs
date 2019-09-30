using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundScroller : MonoBehaviour
{
    private Sprite _sprite;

    private void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        Debug.Log(_sprite.bounds.size.x);
    }

    private void Update()
    {
        transform.Translate (-0.1f, 0, 0);
        if (transform.position.x < -_sprite.bounds.size.x * transform.localScale.x ) {
            transform.position = new Vector3 (_sprite.bounds.size.x * transform.localScale.x, 0, 0);
        }
    }
}
