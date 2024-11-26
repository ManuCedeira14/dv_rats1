using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] int frameSkip;

    List<MementoEntity> _allEntities;

    Coroutine _loadMementosCoroutine;

    public static bool ItsRewindTime { get; private set; }

    private void Start()
    {
        _allEntities = new List<MementoEntity>(FindObjectsOfType<MementoEntity>());
        Debug.Log($"Se encontraron {_allEntities.Count} entidades.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Iniciar recuperacion de datos en cada Entity

            _loadMementosCoroutine = StartCoroutine(LoadMementos());
            Debug.Log("datos recuperados tocando R!!!");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            //Terminar recuperacion de datos en cada Entity
            if (_loadMementosCoroutine == null) return;

            StopCoroutine(_loadMementosCoroutine);
            _loadMementosCoroutine = null;

            ItsRewindTime = false;
            Debug.Log("se termino de guardar datos soltando R!!!");
        }
    }

    IEnumerator LoadMementos()
    {
        ItsRewindTime = true;
        Debug.Log("Iniciando rebobinado...");

        int frames;

        while (true)
        {
            //Recargo los datos de cada MementoEntity
            foreach (var entity in _allEntities)
            {
                if (entity != null)
                {
                    Debug.Log($"Rebobinando: {entity.name}");
                    entity.TryLoadStates();
                }
                entity.TryLoadStates();
            }

            //Espero al siguiente frame
            yield return null;

            frames = 0;

            //Mientras no se haya esperado los suficientes frames que quiero
            //esperar para seguir tomando datos
            while (frames < frameSkip)
            {
                //Espero
                frames++;
                yield return null;
            }
        }
    }
}
