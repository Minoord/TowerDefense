using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //1 make a wallet V
    //2 check if wallet has enough money to purchase the tower V
    //3 so yes, tower becomes draggable V
    //4 and takes money from the wallet V
    //5 refills the shop v

    [SerializeField] private GameObject _towerOperaPlace;
    [SerializeField] private GameObject _towerSullivianPlace;
    [SerializeField] private GameObject _towerAsmodeusPlace;
    [SerializeField] private GameObject _towerClaraPlace;
    [SerializeField] private GameObject _towerKalegoPlace;
    [SerializeField] private GameObject _towerBeastOfValleyPlace;

    [SerializeField] private GameObject _towerOpera;
    [SerializeField] private GameObject _towerSullivian;
    [SerializeField] private GameObject _towerAsmodeus;
    [SerializeField] private GameObject _towerClara;
    [SerializeField] private GameObject _towerKalego;
    [SerializeField] private GameObject _towerBeastOfValley;

    public void RefillShop(GameObject refillTower, GameObject towerPlace)
    {
        Instantiate(refillTower, towerPlace.transform.position, Quaternion.identity);
    }

    public void RefillShopStart()
    {
        RefillShop(_towerOpera, _towerOperaPlace);
        RefillShop(_towerSullivian, _towerSullivianPlace);
        RefillShop(_towerAsmodeus, _towerAsmodeusPlace);
        RefillShop(_towerClara, _towerClaraPlace);
        RefillShop(_towerKalego, _towerKalegoPlace);
        RefillShop(_towerBeastOfValley, _towerBeastOfValleyPlace);
    }
    private void Start()
    {
        Invoke("RefillShopStart", 1);
    }
}
