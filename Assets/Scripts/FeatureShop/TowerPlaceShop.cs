using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceShop : MonoBehaviour
{
    [SerializeField] private float _numberPlaceInShop;
    [SerializeField] private float _maxLengthOfShop;
    [SerializeField] private int _numberOfTowers;
    [SerializeField] private ShopBackground _shopBG;

    private float _posY = 0;

    private void Start()
    {
        _shopBG = FindObjectOfType<ShopBackground>();
    }
    private void Update()
    {
        _maxLengthOfShop = Screen.height + (Screen.height / 2);
        _posY = _maxLengthOfShop - (Screen.height / (_numberOfTowers + 1)) * _numberPlaceInShop;
        this.gameObject.transform.position = new Vector2(_shopBG.transform.position.x, _posY);
    }
}
