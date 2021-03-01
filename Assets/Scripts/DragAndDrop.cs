using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Block))]
[RequireComponent(typeof(Collider2D))]
public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private bool _isDrugging;
    private Block _sumTarget;
    private Block _curretBlock;
    private ItemSlot _itemSlot;
    private Vector3 _startPosition;
    private Collider2D _collider;

    public bool IsDrugging => _isDrugging;
    public event UnityAction<GameObject> Destroied;

    private void OnMouseDown()
    {
        _collider.isTrigger = true;
        _isDrugging = true;
    }

    private void OnMouseUp()
    {
        TrySum();
        _isDrugging = false;

        _collider.isTrigger = false;
    }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _curretBlock = GetComponent<Block>();
    }

    private void Update()
    {
        if (_isDrugging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);
        }

        if (_startPosition.z == 0)
        {
            _startPosition.z -= 1;
        }
    }

    public void ChangeStartPosition(Vector3 newPosition)
    {
        _startPosition = newPosition;
        _startPosition.z -= 1;
    }

    private void TrySum()
    {
        if (_sumTarget != null && _curretBlock.Color == _sumTarget.Color)
        {
            _sumTarget.LevelUp();
            Destroied?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Block block))
        {
            if (block.Level == _curretBlock.Level)
            {
                _sumTarget = block;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _sumTarget = null;
    }
}
