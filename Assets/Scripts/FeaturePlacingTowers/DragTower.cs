using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTower : MonoBehaviour
{
    private Vector3 _mOffset;
    [SerializeField] private bool _inRangeOfTile;

    public bool isDraggable;
    public int towerWorth;
    public Wallet wallet;
    public TowerAttack attackTower;
    public TowerHealth healthTower;
    public Shooting shootingTower;

    private void Start()
    {
        attackTower = this.gameObject.GetComponent<TowerAttack>();
        healthTower = this.gameObject.GetComponent<TowerHealth>();
        shootingTower = this.gameObject.GetComponent<Shooting>();
        wallet = FindObjectOfType<Wallet>();
    }

    private void Update()
    {
        if (isDraggable == false && _inRangeOfTile)
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
        if (_inRangeOfTile && isDraggable)
        {
            isDraggable = false;
            wallet.pocketMoney -= towerWorth;
        }
    }
    void OnMouseDown()
    {
        _mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    void OnMouseDrag()
    {
        if (isDraggable)
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

