using System;

public interface IState<T> where T : Enum
{
    StateController<T> Controller { get; }

    T StateTypeNum { get; }

    /// <summary>
    /// 入場時処理
    /// </summary>
    void OnEnter();

    /// <summary>
    /// 更新時処理
    /// </summary>
    void OnUpdate();

    /// <summary>
    /// 退場時処理
    /// </summary>
    void OnExit();
}