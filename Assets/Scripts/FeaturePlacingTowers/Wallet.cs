using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int pocketMoney;

    public void AddMoney(int moneyToAdd)
    {
        pocketMoney += moneyToAdd;
    }
}
