using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public int savedCount;

    public float[] savedPosition;

    public PlayerData (Hatin player)
    {
        savedCount = Hatin.count;

        savedPosition = new float[3];

        savedPosition[0] = player.transform.position.x;
        savedPosition[1] = player.transform.position.y;
        savedPosition[2] = player.transform.position.z;
    }



}
