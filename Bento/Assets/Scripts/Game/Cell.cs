using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
    public GameObject _cell { get; set; }
    public int _num { get; set; }

    public static Cell InputCell(GameObject obj, int num)
    {
        Cell prefab = new Cell();
        prefab._cell = obj;
        prefab._num = num;
        return prefab;
    }
}
