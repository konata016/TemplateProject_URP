using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public CancellationToken CancellationTokenOnDestroy => this.GetCancellationTokenOnDestroy();

    public void Initialize()
    {

    }

    public T AddComponent<T>() where T : MonoBehaviour
    {
        return gameObject.AddComponent<T>();
    }
}
