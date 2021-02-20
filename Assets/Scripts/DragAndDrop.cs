using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
   [SerializeField] private float _speed =1;

    private bool _isDrugging;
    private Block _sumTarget;
    private ItemSlot _temSlot;
    private Vector3 _startPosition;

    public bool IsDrugging => _isDrugging;

    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        _isDrugging = true;
    }

    private void OnMouseUp()
    {
        TrySum();
        _isDrugging = false;
        
        gameObject.GetComponent<Collider2D>().isTrigger = false;
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
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed*Time.deltaTime);
        }

        if (_startPosition.z ==0)
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
        if (_sumTarget!= null && gameObject.GetComponent<SpriteRenderer>().color == _sumTarget.GetComponent<SpriteRenderer>().color)
        {
            _sumTarget.LevelUp();
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Block block))
        {
            if (block.Level == gameObject.GetComponent<Block>().Level && block.Level<999) // Не забыть поменять на 6
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
