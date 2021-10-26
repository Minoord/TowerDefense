using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTower : MonoBehaviour
{
    private Vector3 _mOffset;
    [SerializeField] private bool _inRangeOfTile;
    [SerializeField] private string _nameOfThePlaceShop;

    public bool isDraggable;
    public int towerWorth;
    public Shop shop;
    public Wallet wallet;
    public TowerAttack attackTower;
    public Shooting shootingTower;
    public GameObject placeInShop;
    public GameObject thisTowerPrefab;

    private void Start()
    {
        attackTower = this.gameObject.GetComponent<TowerAttack>();
        shootingTower = this.gameObject.GetComponent<Shooting>();
        wallet = FindObjectOfType<Wallet>();
        shop = FindObjectOfType<Shop>();
        placeInShop = GameObject.Find(_nameOfThePlaceShop);
        _inRangeOfTile = false;
        isDraggable = true;
    }

    private void Update()
    {
        if (isDraggable == false && _inRangeOfTile)
        {

            attackTower.canAttack = true;
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
        
       if (wallet.pocketMoney >= towerWorth && _inRangeOfTile == false )
        {
            isDraggable = true;
        }
        else
        {
            isDraggable = false;
        }
    }

    void OnMouseDrag()
    {
        if (isDraggable)
        {
            transform.position = GetMouseAsWorldPoint() + _mOffset;
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Tile")
        {
            Debug.Log("in range of tile");
            _inRangeOfTile = true;
        }
        else
        {
            _inRangeOfTile = false;
            //Destroy(this.gameObject);
        }
    }

}

