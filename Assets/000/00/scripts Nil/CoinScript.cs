using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private GameObject _myPlayer;
    public static bool _magnetActive = false;

    void Start()
    {
        _myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_magnetActive)
        {
            MoveTowardsPlayer();

        }    
    
    }
    void MoveTowardsPlayer()
    {
        transform.position = Vector3.Lerp(a: this.transform.position, b: _myPlayer.transform.position, t: 3f * Time.deltaTime);
    }

}
