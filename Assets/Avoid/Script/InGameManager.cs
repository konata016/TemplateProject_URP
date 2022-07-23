using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private EnemyPresenter[] enemyPresenterArr;

    public void Awake()
    {
        playerPresenter.Initialize();

        for (var i = 0; i < enemyPresenterArr.Length; i++)
        {
            enemyPresenterArr[i].Initialize();
        }
    }
}
