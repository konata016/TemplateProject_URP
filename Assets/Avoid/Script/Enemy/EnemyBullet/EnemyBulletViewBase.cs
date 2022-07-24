using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public abstract class EnemyBulletViewBase : MonoBehaviour
{
    public CancellationToken CancellationTokenOnDestroy => this.GetCancellationTokenOnDestroy();

    public abstract void Initialize();

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetRotation(Quaternion rot)
    {
        transform.rotation = rot;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
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
