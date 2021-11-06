using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTower : MonoBehaviour
{
    private Vector3 _mOffset;
    [SerializeField] private string _nameOfThePlaceShop;

    public bool isDraggable;
    public bool inRangeOfTile;
    public int towerWorth;
    public TileScript tile;
    public Shop shop;
    public Wallet wallet;
    public TowerPlaceShop towerPlaceShop;
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
        towerPlaceShop = placeInShop.GetComponentInChildren<TowerPlaceShop>();
        towerWorth = towerPlaceShop.towerPrice;
        inRangeOfTile = false;
        isDraggable = true;
    }

    private void Update()
    {
        if (isDraggable == false && inRangeOfTile)
        {
            if (shootingTower)
            {
                shootingTower.canAttack = true;
            }
            else if (attackTower)
            {
                attackTower.canAttack = true;
            }
        }
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseUp()
    {
        if (inRangeOfTile && isDraggable)
        {
            if(tile == true)
            {
                wallet.MinusMoney(towerWorth);
                towerPlaceShop.towerPrice += 30;
                shop.RefillShop(thisTowerPrefab, placeInShop);
                this.transform.position = new Vector2 (tile.transform.position.x , tile.transform.position.y + 30);
                tile.canBuildOn = false;
                isDraggable = false;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (inRangeOfTile == false && isDraggable)
            {
                shop.RefillShop(thisTowerPrefab, placeInShop);
                Destroy(gameObject);
            }
        }

    }
    void OnMouseDown()
    {
        _mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        
       if (wallet.pocketMoney >= towerWorth && inRangeOfTile == false)
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


}

