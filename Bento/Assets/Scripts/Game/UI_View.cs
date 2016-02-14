using UnityEngine;
using System.Collections;

public class UI_View : MonoBehaviour
{
    #region 画像の呼び出し…他に書き方あるでしょコレ…
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

    private GameObject _menu = null;
    public GameObject Menu
    {
        get
        {
            if (_menu != null) { return _menu; }
            _menu = Resources.Load<GameObject>("Game/GamePrefabs/MenuList");
            return _menu;
        }
    }
    #endregion


    Cell[] _menu_cells = new Cell[9];
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            _menu_cells[i] = gameObject.GetComponent<Cell>();
        }

        StartCoroutine(CreateButton());
        StartCoroutine(CreateBoxCells());
        StartCoroutine(CreateUI());
    }

    // 『お品書き』欄に表示するボタン
    private IEnumerator CreateButton()
    {
        int count = 0;
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                switch (count)
                {
                    case 0:
                        _menu_cells[count] = Cell.InputCell(Menu1, count + 1);
                        break;
                    case 1:
                        _menu_cells[count] = Cell.InputCell(Menu2, count + 1);
                        break;
                    case 2:
                        _menu_cells[count] = Cell.InputCell(Menu3, count + 1);
                        break;
                    case 3:
                        _menu_cells[count] = Cell.InputCell(Menu4, count + 1);
                        break;
                    case 4:
                        _menu_cells[count] = Cell.InputCell(Menu5, count + 1);
                        break;
                    case 5:
                        _menu_cells[count] = Cell.InputCell(Menu6, count + 1);
                        break;
                    case 6:
                        _menu_cells[count] = Cell.InputCell(Menu7, count + 1);
                        break;
                    case 7:
                        _menu_cells[count] = Cell.InputCell(Menu8, count + 1);
                        break;
                    case 8:
                        _menu_cells[count] = Cell.InputCell(Menu9, count + 1);
                        break;
                }
                var menus_r = (1.7f * (r + 1)) + (1.0f * r);
                var menus_c = 0.6f - (2.2f * c);
                var prefab = Instantiate(_menu_cells[count]._cell);
                prefab.transform.position = new Vector2(menus_r, menus_c);
                count++;
                yield return null;
            }
        }
    }

    private IEnumerator CreateUI()
    {
        var UI_prefab = Instantiate(Menu);
        var Box_prefab = Instantiate(Box);
        yield return null;
    }


    // 『お弁当箱』に表示するセル(初期状態では全て０)
    GameObject[] _box_obj = new GameObject[9];
    private IEnumerator CreateBoxCells()
    {
        int count = 0;
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                _box_obj[count] = Menu0;
                var box_r = -6.95f + (2.5f * r);
                var box_c = 3.11f - (3.0f * c);
                var prefab = Instantiate(_box_obj[count]);
                prefab.transform.position = new Vector2(box_r, box_c);
                count++;
                yield return null;
            }
        }
    }


    // プレイヤーのstateを表示・変更
    private int _player_state = 0;
    private void PlayerStateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 TapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D Collider2d = Physics2D.OverlapPoint(TapPoint);
            if (Collider2d)
            {
                GameObject obj = Collider2d.transform.gameObject;
                Debug.Log(obj.name);
            }
        }
    }

    void Update()
    {
        PlayerStateUpdate();
    }
}
