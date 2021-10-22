using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBackground : MonoBehaviour
{
    //1. set shop position v
    //2. set shop height v
    //3. set shop width v
    //4. set towers locations 

    [SerializeField] private GameObject _shopBG;
    [SerializeField] private float _shopHeight;
    [SerializeField] private float _shopWidth;
    [SerializeField] private float _shopPosX;



    private void Start()
    {
        _shopBG = this.gameObject;
    }

    private void Update()
    {
        _shopWidth = Screen.width / 5;
        _shopHeight = Screen.height;
        _shopPosX = Screen.width / 5 * 2;
        _shopBG.transform.position = new Vector2(_shopPosX,0);
        _shopBG.transform.localScale = new Vector2(_shopWidth, _shopHeight);
    }
}
