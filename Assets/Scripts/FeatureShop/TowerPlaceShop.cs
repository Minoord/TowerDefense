using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlaceShop : MonoBehaviour
{
    [SerializeField] private float _numberPlaceInShop;
    [SerializeField] private float _maxLengthOfShop;
    [SerializeField] private int _numberOfTowers;
    [SerializeField] private ShopBackground _shopBG;

    public string nameTower;
    public Text shopText;
    public int towerPrice;

    private float _posY = 0;

    private void Start()
    {
        _shopBG = FindObjectOfType<ShopBackground>();
    }
    private void Update()
    {
        if (_numberPlaceInShop > 1)
        {
            shopText.text = nameTower + ": $" + towerPrice;
        }
        else
        {
            shopText.text = "Shop";
        }
        _maxLengthOfShop = Screen.height + (Screen.height / 2);
        _posY = _maxLengthOfShop - (Screen.height / (_numberOfTowers + 1)) * _numberPlaceInShop;
        this.gameObject.transform.position = new Vector2(_shopBG.transform.position.x - 125, _posY);
    }
}
