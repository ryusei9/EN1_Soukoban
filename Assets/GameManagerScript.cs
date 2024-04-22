using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject boxprefab;
    // 配列の宣言
    int[,] map;
    GameObject[,] field;

    /* void PrintArray()
     {
         string debugText = "";
         for (int i = 0; i < map.Length; i++)
         {
             // 変更。文字列に結合していく
             debugText += map[i].ToString() + ",";
         }
         Debug.Log(debugText);
     }*/
    // int型からVector2Int型に変更
    Vector2Int GetPlayerIndex()
    {
        // mapからfieldに変えて二次元配列に対応させる
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                // nullチェックをしてnullならcontinueを使う
                if (field[y, x] == null) { continue; }
                // ループを続ける。nullでなかったらtagチェック
                // ２次元配列のそれぞれのインデックスをVector2Int型で返す
                if (field[y, x].tag == "Player") { return new Vector2Int(x, y); }
            }
        }
        // x,yそれぞれに-1を入れたVector2Int型の値を返す
        return new Vector2Int(-1, -1);
    }
    // moveFromおよびmoveToをVector2Int型で受け取る
    bool MoveNumber(string tag, Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0))
        {
            // 動けない条件を先に書き、リターン
            return false;
        }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1))
        {
            // 動けない条件を先に書き、リターン
            return false;
        }
        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            // どの方向へ移動するかを算出
            Vector2Int velocity = moveTo - moveFrom;
            // プレイヤーの移動先から、さらにBoxを移動させる
            bool success = MoveNumber(tag, moveTo, moveTo + velocity);
            // 箱の移動が失敗したらプレイヤーの移動も失敗させる
            if (!success)
            {
                return false;
            }
        }
        // GameObjectの座標(position)を移動させてからインデックスの入れ替え
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {

        // 配列の実態の作成と初期化
        map = new int[,]
        {
            { 1, 0, 0, 2, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        };
        field = new GameObject
            [
            map.GetLength(0),
            map.GetLength(1)
            ];
        //string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(
                        playerPrefab,
                        new Vector3(x - map.GetLength(1) / 2 + 0.5f, -y + map.GetLength(0) / 2, 0),
                        Quaternion.identity
                    );
                }
                //debugText += map[y, x].ToString() + ",";
            }
            //debugText += "\n";
        }
        //Debug.Log(debugText);
        // PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            // メソッド化した処理を使用
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber("Player", playerIndex, playerIndex + new Vector2Int(1, 0));
            //PrintArray();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // メソッド化した処理を使用
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Player", playerIndex, playerIndex + new Vector2Int(-1, 0));
            //PrintArray();
        }
    }
}
