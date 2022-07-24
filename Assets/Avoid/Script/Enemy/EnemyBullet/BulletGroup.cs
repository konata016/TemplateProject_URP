using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGroup
{
    private BulletBase[] bulletArr;

    public BulletGroup(BulletBase[] bulletArr)
    {
        for (var i = 0; i < bulletArr.Length; i++)
        {
            this.bulletArr[i] = bulletArr[i];
        }
    }
}
