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

    private GameObject _back_ground = null;
    public GameObject BackGround
    {
        get
        {
            if (_back_ground != null) { return _back_ground; }
            _back_ground = Resources.Load<GameObject>("Game/GamePrefabs/BackGround");
            return _back_ground;
        }
    }
    #endregion


    Cell[] _menu_cells = new Cell[9];
    SampleCreate sample = new SampleCreate();

    float _timer = 0;

    void Start()
    {
        sample = gameObject.GetComponent<SampleCreate>();

        if (sample._isPlaySample)
        {
            for (int i = 0; i < 9; i++)
            {
                _menu_cells[i] = gameObject.GetComponent<Cell>();
            }
        }
    }

    // 背景や『お品書き』など、動きのない画像表示
    private IEnumerator CreateUI()
    {
        var BackGround_prefab = Instantiate(BackGround);
        var UI_prefab = Instantiate(Menu);
        var Box_prefab = Instantiate(Box);
        yield return null;
    }

    // 『お品書き』欄に表示するボタン
    private IEnumerator CreateButton()
    {
        int count = 1;
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                switch (count)
                {
                    case 1:
                        _menu_cells[count - 1] = Cell.InputCell(Menu1, count);
                        break;
                    case 2:
                        _menu_cells[count - 1] = Cell.InputCell(Menu2, count);
                        break;
                    case 3:
                        _menu_cells[count - 1] = Cell.InputCell(Menu3, count);
                        break;
                    case 4:
                        _menu_cells[count - 1] = Cell.InputCell(Menu4, count);
                        break;
                    case 5:
                        _menu_cells[count - 1] = Cell.InputCell(Menu5, count);
                        break;
                    case 6:
                        _menu_cells[count - 1] = Cell.InputCell(Menu6, count);
                        break;
                    case 7:
                        _menu_cells[count - 1] = Cell.InputCell(Menu7, count);
                        break;
                    case 8:
                        _menu_cells[count - 1] = Cell.InputCell(Menu8, count);
                        break;
                    case 9:
                        _menu_cells[count - 1] = Cell.InputCell(Menu9, count);
                        break;
                }
                var menus_r = (1.7f * (r + 1)) + (1.0f * r);
                var menus_c = 0.6f - (2.2f * c);
                var prefab = Instantiate(_menu_cells[count - 1]._cell);
                prefab.transform.position = new Vector2(menus_r, menus_c);
                prefab.transform.name = "Menu_" + count;
                count++;
                yield return null;
            }
        }
    }

    // 『お弁当箱』に表示するセル(初期状態では全て０)
    Cell[] _box_obj = new Cell[9];
    bool _isCreate = false;
    private void CreateBoxCells()
    {
        if (!_isCreate)
        {
            int count = 0;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    _box_obj[count] = Cell.InputCell(Menu0, count);
                    var box_r = -6.95f + (2.5f * r);
                    var box_c = 3.11f - (3.0f * c);
                    _box_obj[count]._cell = Instantiate(_box_obj[count]._cell);
                    _box_obj[count]._cell.transform.position = new Vector2(box_r, box_c);
                    count++;
                }
            }
            _isCreate = true;
        }
    }


    // プレイヤーのstateを表示・変更 & Box側のCellの変更
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

                // 画面右側の判定
                if (0 < TapPoint.x)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (obj.name == _menu_cells[i]._cell.name)
                        {
                            _player_state = _menu_cells[i]._num;
                            Debug.Log("Player_State = " + _player_state);
                        }
                    }
                }

                // 画面左側の判定
                else if (0 > TapPoint.x)
                {
                    var obj_pos = obj.transform.position;
                    switch (_player_state)
                    {
                        case 1:
                            UpdateCellNumber(TapPoint, Menu1, obj_pos, _player_state);
                            break;

                        case 2:
                            UpdateCellNumber(TapPoint, Menu2, obj_pos, _player_state);
                            break;

                        case 3:
                            UpdateCellNumber(TapPoint, Menu3, obj_pos, _player_state);
                            break;

                        case 4:
                            UpdateCellNumber(TapPoint, Menu4, obj_pos, _player_state);
                            break;

                        case 5:
                            UpdateCellNumber(TapPoint, Menu5, obj_pos, _player_state);
                            break;

                        case 6:
                            UpdateCellNumber(TapPoint, Menu6, obj_pos, _player_state);
                            break;

                        case 7:
                            UpdateCellNumber(TapPoint, Menu7, obj_pos, _player_state);
                            break;

                        case 8:
                            UpdateCellNumber(TapPoint, Menu8, obj_pos, _player_state);
                            break;

                        case 9:
                            UpdateCellNumber(TapPoint, Menu9, obj_pos, _player_state);
                            break;
                    }
                }
            }
        }
    }

    // タッチした座標にあるオブジェクトの配列番号を検索、新しい画像に差し替え処理
    void UpdateCellNumber(Vector3 TouchPosition, GameObject obj, Vector3 obj_pos, int num)
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                var box_r = -6.95f + (2.5f * r);
                var box_c = 3.11f - (3.0f * c);
                if (TouchPosition.x > box_r - 1.28 && TouchPosition.x < box_r + 1.28 &&
                    TouchPosition.y > box_c - 1.28 && TouchPosition.y < box_c + 1.28)
                {
                    _box_obj[((r * 3) + c)]._num = num;
                    Destroy(_box_obj[((r * 3) + c)]._cell);
                    _box_obj[((r * 3) + c)]._cell = Instantiate(obj);
                    _box_obj[((r * 3) + c)]._cell.transform.position = obj_pos;
                    Debug.Log("_box_obj[" + ((r * 3) + c) + "]._num :" + _box_obj[((r * 3) + c)]._num);
                }
            }
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;

        sample.Create(_timer);
        if (sample._isPlaySample)
        {
            if (!_isCreate)
            {
                StartCoroutine(CreateButton());
                StartCoroutine(CreateUI());
            }
            PlayerStateUpdate();
            CreateBoxCells();
        }
    }
}
