using System;

public interface IState<T> where T : Enum
{
    StateController<T> Controller { get; }

    T StateTypeNum { get; }

    /// <summary>
    /// ���ꎞ����
    /// </summary>
    void OnEnter();

    /// <summary>
    /// �X�V������
    /// </summary>
    void OnUpdate();

    /// <summary>
    /// �ޏꎞ����
    /// </summary>
    void OnExit();
}