using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileScript : MonoBehaviour
{
    [SerializeField] private bool _isBuildable;
    [SerializeField] private int _towerPrice;
    public GameObject tower;
    public GameObject spawnpointTower;
    public Wallet wallet;
    public Color tempColor;
    public Color normalColor;

    private void Start()
    {
        wallet = FindObjectOfType<Wallet>();
        gameObject.GetComponent<Renderer>().material.color = normalColor;
    }

    private void OnMouseDown()
    {
        if(_isBuildable == true && wallet.pocketMoney >= _towerPrice)
        {
            Instantiate(tower, spawnpointTower.transform.position, Quaternion.identity);
            _isBuildable = false;
            wallet.pocketMoney -= _towerPrice;
        }
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material.color = tempColor;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = normalColor;
    }
}
