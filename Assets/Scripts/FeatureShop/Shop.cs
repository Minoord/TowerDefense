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

    public int worthOfTheTower;
    public Wallet wallet;
    public DragTower draggableTower;

    public void RefillShop(GameObject refillTower, GameObject towerPlace)
    {
        Instantiate(refillTower, towerPlace.transform.position, Quaternion.identity);
    }

    private void Start()
    {
        wallet = FindObjectOfType<Wallet>();
    }

    private void Update()
    {
        worthOfTheTower = draggableTower.towerWorth;

        if(wallet.pocketMoney >= worthOfTheTower)
        {
            draggableTower.isDraggable = true;
        }
        else
        {
            draggableTower.isDraggable = false;
        }
    }
}
