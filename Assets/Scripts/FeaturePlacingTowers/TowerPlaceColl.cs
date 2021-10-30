using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceColl : MonoBehaviour
{
    [SerializeField] private DragTower dragTower;

    private void Start()
    {
        dragTower = this.gameObject.GetComponentInParent<DragTower>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Tile")
        {
            Debug.Log("in range of tile");
            dragTower.inRangeOfTile = true;
            dragTower.tile = collision.gameObject.GetComponent<TileScript>();
        }
        else
        {
            dragTower.tile = null;
            dragTower.inRangeOfTile = false;
        }

    }
}
