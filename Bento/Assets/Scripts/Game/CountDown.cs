using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour
{
    public float _time;
    public bool _isTimeUp;
    void Start()
    {
        _time = 15 + 5;
        _isTimeUp = false;
        GetComponent<Text>().color = new Color(1, 1, 1);
        GetComponent<Text>().transform.position = new Vector2((Screen.width / 5) * 3.75f, (Screen.height / 5) * 4.6f);
    }

    void Update()
    {
        _time -= Time.deltaTime;
        if (_time < 0) { _time = 0; }
        if (_time <= 16)
        {
            GetComponent<Text>().text = "残り時間：" + ((int)_time).ToString();
            ChangeColor((int)_time);
        }
    }

    void ChangeColor(int time)
    {
        if (11 > time && time >= 6)
        {
            GetComponent<Text>().color = new Color(1, 1, 0);
        }
        else if (6 > time)
        {
            GetComponent<Text>().color = new Color(1, 0, 0);
        }
    }

    // ******************** //
    // タイムアップでリザルト //
    // ******************** //
}
