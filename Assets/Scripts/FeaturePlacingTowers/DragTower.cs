using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTower : MonoBehaviour
{
    private Vector3 _mOffset;
    [SerializeField] private bool _isDraggable;
    [SerializeField] private bool _inRangeOfTile;
    public TowerAttack attackTower;
    public TowerHealth healthTower;
    public Shooting shootingTower;

    private void Start()
    {
        attackTower = this.gameObject.GetComponent<TowerAttack>();
        healthTower = this.gameObject.GetComponent<TowerHealth>();
        _isDraggable = true;
    }

    private void Update()
    {
        if (_isDraggable == false)
        {
            attackTower.canAttack = true;
            healthTower.canBeHit = true;
            shootingTower.canAttack = true;
        }
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseUp()
    {
        if (_inRangeOfTile)
        {
            _isDraggable = false;
        }
    }
    void OnMouseDown()
    {
        _mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    void OnMouseDrag()
    {
        if (_isDraggable)
        {
            transform.position = GetMouseAsWorldPoint() + _mOffset;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tile")
        {
            _inRangeOfTile = true;
        }
        else
        {
            _inRangeOfTile = false;
            //Destroy(this.gameObject);
        }
    }

}

