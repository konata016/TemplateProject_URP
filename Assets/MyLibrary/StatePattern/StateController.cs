using System;
using System.Collections.Generic;

public class StateController<T> where T : Enum
{
    private Dictionary<T, IState<T>> stateMap;

    public T CurrentStateType { get; private set; }

    public StateController()
    {
        stateMap = new Dictionary<T, IState<T>>();
    }

    /// <summary>
    /// �X�e�[�g�̒ǉ�
    /// </summary>
    public void AddState(T stateType, IState<T> state)
    {
        stateMap.Add(stateType, state);
    }

    /// <summary>
    /// �X�e�[�g��ύX����
    /// </summary>
    public void ChangeState(T nextStateType)
    {
        if (CurrentStateType.Equals(nextStateType))
        {
            return;
        }

        if (stateMap.ContainsKey(CurrentStateType))
        {
            stateMap[CurrentStateType].OnExit();
        }
       
        CurrentStateType = nextStateType;
        stateMap[CurrentStateType].OnEnter();
    }

    /// <summary>
    /// �X�V������
    /// </summary>
    public void OnStateUpdate()
    {
        if (!stateMap.ContainsKey(CurrentStateType))
        {
            return;
        }

        stateMap[CurrentStateType].OnUpdate();
    }
}
