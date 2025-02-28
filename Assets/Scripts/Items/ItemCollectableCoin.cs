using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Itens;

public class ItemCollectableCoin : ItemCollectableBase
{

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddByType(ItemType.COIN);
        collider.enabled = false;
    }
}
