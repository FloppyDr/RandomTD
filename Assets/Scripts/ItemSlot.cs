using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    private bool _isEmpty = true;
    private DragAndDrop _curretBlock;

    public bool IsEmpty => _isEmpty;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (_curretBlock == null)
    //    {
    //        if (collision.TryGetComponent(out DragAndDrop drug))
    //        {
    //            _curretBlock = drug;
    //        }
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
       if (_curretBlock == null)
        {
            if (collision.TryGetComponent(out DragAndDrop drug) && _isEmpty)
            {
                _curretBlock = drug;
                drug.ChangeStartPosition(gameObject.transform.position);
                _isEmpty = false;
            }
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DragAndDrop drug) && drug == _curretBlock)
        {
            _curretBlock = null;
            _isEmpty = true;
        }
    }

}
