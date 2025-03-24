using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;


//class nay dung de spawn player vao trong game network
public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    //khi vao mang thi tao nhan vat cho nguoi choi
    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            //tao nhan vat o vi tri (0,1,0)
            var position = new Vector3(0,1,0);
            //spawn nhan vat o vi tri nay
            Runner.Spawn(PlayerPrefab, position, Quaternion.identity);
        }
    }
}
