using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoState
{
    //Variable que va a guardar una seguidilla de datos
    Stack<object[]> _states;
    //Queue<object[]> _states;

    public int MemoriesAmount => _states.Count;

    public MementoState()
    {
        _states = new Stack<object[]>();
        //_states = new Queue<object[]>();
    }

    //Metodo que guarde un dato
    public void SaveMemory(params object[] state)
    {
        _states.Push(state);
        //_states.Enqueue(state);
    }

    //Metodo que devuelva un dato
    public object[] LoadMemory()
    {
        return _states.Pop();
        //return _states.Dequeue();
    }
}
