using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;


[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private List<GameObject> _variants;
    [SerializeField] private Player _player;

    private SpriteRenderer _spriteRenderer;
    private Color _color;
    private int _level = 0;

    public Color Color => _color;
    public int Level => _level;

    public event UnityAction<int> LevelChanged;

    private void Awake()
    {
        _player = Camera.main.GetComponent<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;        
    }

    private void Start()
    {
        LevelChanged?.Invoke(_level);    
    }

    public void LevelUp()
    {
        _player.AddScore(_level * 2);
        _level++;
        LevelChanged?.Invoke(_level);

        ChangeBlock();
    }


    private void ChangeBlock()
    {
        _color = _variants.ElementAtOrDefault(Random.Range(0, _variants.Count)).GetComponent<SpriteRenderer>().color;
        _spriteRenderer.color = _color;        
    }
}
