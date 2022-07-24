using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class EnemyBullet : BulletBase
{
    [SerializeField] private new Renderer renderer;

    public override bool IsMoving { get; protected set; }

    private float movingSpeed;

    public override void Initialize()
    {
        gameObject.SetActive(false);
        renderer.OnBecameInvisibleAsObservable().Subscribe((x) => IsMoving = false);
    }

    public override void OnEnter(float movingSpeed, Vector3 position, Quaternion rotation)
    {
        this.movingSpeed = movingSpeed;

        transform.position = position;
        transform.rotation = rotation;

        IsMoving = true;
        gameObject.SetActive(true);
    }

    public override void OnUpdate()
    {
        transform.Translate(transform.up * movingSpeed * Time.deltaTime, Space.World);
    }

    public override void OnExit()
    {
        gameObject.SetActive(false);
    }
}
