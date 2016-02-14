using UnityEngine;
using System.Collections;

// 画面右側「お品書き」部分の処理
public class CreateMenu : MonoBehaviour
{
    void Start()
    {

    }

    // 「お品書き」の枠内に１～９までの画像を表示
    public void DrawMenuList(Vector2 pos, GameObject obj)
    {
        var prefab = Instantiate(obj);
        prefab.transform.position = pos;
    }

    // タッチした画像に合わせてプレイヤーのStateをその番号に変更する
    // ※元々のプレイヤーのStateは０(None)とする
    public void ChangePlayerState()
    {

    }
}
