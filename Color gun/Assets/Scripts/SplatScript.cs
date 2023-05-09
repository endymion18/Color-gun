using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private static int _curWeapon;
    public Sprite[] sprites;
    
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize()
    {
        
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        _curWeapon = WeaponChoosingScript.CurWeapon;
        _spriteRenderer.sprite = sprites[_curWeapon];
    }
}
