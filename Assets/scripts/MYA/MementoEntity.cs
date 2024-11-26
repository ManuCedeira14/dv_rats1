using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MementoEntity : MonoBehaviour
{
    protected MementoState _memento;

    protected MementoEntity()
    {
        Debug.Log("memento asignado correctamente");
        _memento = new MementoState();
    }

    private void Awake()
    {
        if (_memento == null)
        {
            _memento = new MementoState();
            Debug.Log("MementoState inicializado correctamente.");
        }
        else
        {
            Debug.Log("MementoState ya estaba inicializado.");
        }
    }

    protected virtual void Update()
    {
        SaveStates();
    }

    protected abstract void SaveStates();

    public void TryLoadStates()
    {
        if (_memento.MemoriesAmount == 0) return;

        var state = _memento.LoadMemory();

        LoadStates(state);
    }

    protected abstract void LoadStates(object[] state);

}
