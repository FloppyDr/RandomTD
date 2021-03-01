using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    private bool _isEmpty = true;
    private DragAndDrop _curretBlock;

    public bool IsEmpty => _isEmpty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_curretBlock == null)
        {
            if (collision.TryGetComponent(out DragAndDrop block) && _isEmpty)
            {
                _curretBlock = block;
                block.ChangeStartPosition(gameObject.transform.position);
                _isEmpty = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DragAndDrop block) && block == _curretBlock)
        {
            _curretBlock = null;
            _isEmpty = true;
        }
    }

}
