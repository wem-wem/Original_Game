using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
    public GameObject _cell { get; set; }
    public int _num { get; set; }

    public Cell(GameObject obj, int num)
    {
        _cell = obj;
        _num = num;
    }

    public static Cell InputCell(GameObject obj, int num)
    {
        Cell prefab = new Cell(obj, num);
        return prefab;
    }
}
