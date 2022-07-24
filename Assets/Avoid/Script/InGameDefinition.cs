using UnityEngine;

public class InGameDefinition
{
    public static string EnemyBulletPrefabPath = "Prefab/EnemyBullet/EnemyBullet";

    private static Camera mainCamera;
    public static Camera MainCamera
    {
        get
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
            return mainCamera;
        }
    }
}
