using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _prefubs;
    [SerializeField] protected List<ItemSlot> _slots;

    protected bool TryGetObject(out ItemSlot result)
    {
        List<ItemSlot> slots = _slots.Where(slot => slot.IsEmpty == true).ToList();

        result = slots.ElementAtOrDefault(Random.Range(0, slots.Count));

        return result != null;
    }
}
