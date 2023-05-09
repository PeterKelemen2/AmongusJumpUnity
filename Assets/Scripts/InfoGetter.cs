using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGetter : MonoBehaviour
{
    public GameObject player;
    public int shownCoins;

    void Start()
    {
        shownCoins = player.GetComponent<PlayerController>().getAllCoinsFromGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
