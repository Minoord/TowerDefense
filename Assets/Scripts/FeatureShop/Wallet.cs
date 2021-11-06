using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public int pocketMoney;
    public Text PrintWallet;

    private void Update()
    {
        //Debug.Log(pocketMoney);
        PrintWallet.text = "Money:" + pocketMoney;
    }

    public void AddMoney(int moneyToAdd)
    {
        pocketMoney += moneyToAdd;
    }

    public void MinusMoney(int minusMoney)
    {
        pocketMoney -= minusMoney;
    }
}
