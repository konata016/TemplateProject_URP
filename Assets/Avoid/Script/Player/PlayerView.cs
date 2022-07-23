using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [field: SerializeField] public LineRenderer LineRenderer { get; private set; }

    public CancellationToken CancellationTokenOnDestroy => this.GetCancellationTokenOnDestroy();

    public void Initialize()
    {

    }

    public T AddComponent<T>() where T : MonoBehaviour
    {
       return gameObject.AddComponent<T>();
    }
}
