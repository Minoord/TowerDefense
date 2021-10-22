using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTower : MonoBehaviour
{
    private Vector3 _mOffset;
    [SerializeField] private bool _inRangeOfTile;

    public bool isDraggable;
    public int towerWorth;
    public Shop shop;
    public Wallet wallet;
    public TowerAttack attackTower;
    public TowerHealth healthTower;
    public Shooting shootingTower;
    public GameObject placeInShop;
    public GameObject thisTowerPrefab;

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
            wallet.MinusMoney(towerWorth);
            shop.RefillShop(thisTowerPrefab, placeInShop);
            isDraggable = false;
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

        if (collision.gameObject.tag == "Shop")
        {
            isDraggable = true;
        }
        else
        {
            if(_inRangeOfTile == false && isDraggable)
            {
                Destroy(this.gameObject);
            }
        }
    }

}

