using UnityEngine;
using System.Collections;

public class SampleCreate : MonoBehaviour
{
    #region 画像読み込みはあとで書き直し
    private GameObject _back = null;
    public GameObject BackGround
    {
        get
        {
            if (_back != null) { return _back; }
            _back = Resources.Load<GameObject>("Game/GamePrefabs/SampleBackGround");
            return _back;
        }
    }

    private GameObject _menu0 = null;
    public GameObject Menu0
    {
        get
        {
            if (_menu0 != null) { return _menu0; }
            _menu0 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_0");
            return _menu0;
        }
    }

    private GameObject _menu1 = null;
    public GameObject Menu1
    {
        get
        {
            if (_menu1 != null) { return _menu1; }
            _menu1 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_1");
            return _menu1;
        }
    }

    private GameObject _menu2 = null;
    public GameObject Menu2
    {
        get
        {
            if (_menu2 != null) { return _menu2; }
            _menu2 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_2");
            return _menu2;
        }
    }

    private GameObject _menu3 = null;
    public GameObject Menu3
    {
        get
        {
            if (_menu3 != null) { return _menu3; }
            _menu3 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_3");
            return _menu3;
        }
    }

    private GameObject _menu4 = null;
    public GameObject Menu4
    {
        get
        {
            if (_menu4 != null) { return _menu4; }
            _menu4 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_4");
            return _menu4;
        }
    }

    private GameObject _menu5 = null;
    public GameObject Menu5
    {
        get
        {
            if (_menu5 != null) { return _menu5; }
            _menu5 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_5");
            return _menu5;
        }
    }

    private GameObject _menu6 = null;
    public GameObject Menu6
    {
        get
        {
            if (_menu6 != null) { return _menu6; }
            _menu6 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_6");
            return _menu6;
        }
    }

    private GameObject _menu7 = null;
    public GameObject Menu7
    {
        get
        {
            if (_menu7 != null) { return _menu7; }
            _menu7 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_7");
            return _menu7;
        }
    }

    private GameObject _menu8 = null;
    public GameObject Menu8
    {
        get
        {
            if (_menu8 != null) { return _menu8; }
            _menu8 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_8");
            return _menu8;
        }
    }

    private GameObject _menu9 = null;
    public GameObject Menu9
    {
        get
        {
            if (_menu9 != null) { return _menu9; }
            _menu9 = Resources.Load<GameObject>("Game/GamePrefabs/Menu_9");
            return _menu9;
        }
    }

    private GameObject _box = null;
    public GameObject Box
    {
        get
        {
            if (_box != null) { return _box; }
            _box = Resources.Load<GameObject>("Game/GamePrefabs/Box");
            return _box;
        }
    }
    #endregion

    Cell[] _cells = new Cell[9];
    GameObject _sample_box = null;
    GameObject _sample_back_ground = null;

    public bool _isPlaySample = false;
    bool _isCreate = false;

    public void Create(float timer)
    {
        if (timer < 4 && !_isCreate)
        {
            for (int i = 0; i < 9; i++)
            {
                _cells[i] = gameObject.GetComponent<Cell>();
            }
            _sample_back_ground = Instantiate(BackGround);
            _sample_box = Instantiate(Box);
            _sample_box.transform.position = new Vector2(0, 0);
            StartCoroutine(DrawSample());
            _isCreate = true;
        }
        else if(timer >= 4)
        {
            for (int i = 0; i < 9; i++)
            {
                Destroy(_cells[i]._cell);
                Debug.Log("Count " + i);
            }
            Destroy(_sample_back_ground);
            Destroy(_sample_box);
            Debug.Log("テスト");
            _isPlaySample = true;
        }
    }

    Vector2[] _sample_pos = new Vector2[9];

    // サンプルの描画
    public IEnumerator DrawSample()
    {
        for (int r = 0; r < 3; r++)
        {
            for(int c = 0; c < 3; c++)
            {
                var sample_r = -6.95f + (2.5f * r);
                var sample_c = 3.11f - (3.0f * c);
                _sample_pos[((r * 3) + c)] = new Vector2(sample_r+4.5f, sample_c);
            }
        }

        for (int i = 0; i < 9; i++)
        {
            int random = Random.Range(1, 9);
            switch (random)
            {
                case 1:
                    _cells[i] = Cell.InputCell(Menu1, 1);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;

                case 2:
                    _cells[i] = Cell.InputCell(Menu2, 2);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;

                case 3:
                    _cells[i] = Cell.InputCell(Menu3, 3);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;

                case 4:
                    _cells[i] = Cell.InputCell(Menu4, 4);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;

                case 5:
                    _cells[i] = Cell.InputCell(Menu5, 5);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;

                case 6:
                    _cells[i] = Cell.InputCell(Menu6, 6);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;

                case 7:
                    _cells[i] = Cell.InputCell(Menu7, 7);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;

                case 8:
                    _cells[i] = Cell.InputCell(Menu8, 8);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;

                case 9:
                    _cells[i] = Cell.InputCell(Menu9, 9);
                    _cells[i]._cell = Instantiate(_cells[i]._cell);
                    _cells[i]._cell.transform.position = _sample_pos[i];
                    break;
            }
        }
        yield return null;
    }

    public int ReturnSampleNumber(int i)
    {
        return _cells[i]._num;
    }
}
