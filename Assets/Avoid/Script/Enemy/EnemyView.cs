using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Transform muzzlePivot;

    public Vector3 MuzzlePosition => muzzlePivot.position;
    public Quaternion MuzzleRotation => muzzlePivot.rotation;

    public CancellationToken CancellationTokenOnDestroy => this.GetCancellationTokenOnDestroy();

    public void Initialize()
    {

    }

    public T AddComponent<T>() where T : MonoBehaviour
    {
        return gameObject.AddComponent<T>();
    }

    public T CreateResource<T>(string path, Transform parent = null)
        where T : MonoBehaviour
    {
        var prefab = Resources.Load<T>(path);
        return Instantiate(prefab, parent);
    }

    public GameObject CreateResource(string path, Transform parent = null)
    {
        var prefab = Resources.Load<GameObject>(path);
        return Instantiate(prefab, parent);
    }

    public GameObject CreateGameObject(
        string name,
        Transform parent = null)
    {
        var obj = new GameObject(name);
        obj.transform.parent = parent;
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;

        return obj;
    }
}
