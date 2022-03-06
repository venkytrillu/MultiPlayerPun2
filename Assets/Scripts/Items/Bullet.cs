using System;
using System.Collections;
using System.Collections.Generic;
using Items.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Sprite> _spriteLists;
    public List<Sprite> Bullets => _spriteLists;

    private void Start()
    {
        SetBullet();
    }

    public Sprite GetBullet()
    {
       return Bullets[Random.Range(0, Bullets.Count - 1)];
    }

    public void SetBullet()
    {
        _spriteRenderer.sprite = GetBullet();
    }
}
