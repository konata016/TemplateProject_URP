using System;

public interface IState<T> where T : Enum
{
    StateController<T> Controller { get; }

    T StateType { get; }

    /// <summary>
    /// “üêˆ—
    /// </summary>
    void OnEnter();

    /// <summary>
    /// XVˆ—
    /// </summary>
    void OnUpdate();

    /// <summary>
    /// ‘Şêˆ—
    /// </summary>
    void OnExit();
}