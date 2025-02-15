using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float mouseSensitivity;
    public int playerHealth;
    public float[] playerPos;

    public PlayerData(PlayerMovement player)
    {
        playerPos = new float[3];
        playerPos[0] = player.transform.position.x;
        playerPos[1] = player.transform.position.y;
        playerPos[2] = player.transform.position.z;
    }
}