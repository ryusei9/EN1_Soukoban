using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    // 配列の宣言
    int[,] map;
    /* void PrintArray()
     {
         string debugText = "";
         for (int i = 0; i < map.Length; i++)
         {
             // 変更。文字列に結合していく
             debugText += map[i].ToString() + ",";
         }
         Debug.Log(debugText);
     }
     int GetPlayerIndex()
     {
         for (int i = 0; i < map.Length; i++)
         {
             if (map[i] == 1)
             {
                 return i;
             }
         }
         return -1;
     }
     bool MoveNumber(int number, int moveFrom, int moveTo)
     {
         if (moveTo < 0 || moveTo >= map.Length)
         {
             // 動けない条件を先に書き、リターン
             return false;
         }
         if (map[moveTo] == 2)
         {
             // どの方向へ移動するかを算出
             int velocity = moveTo - moveFrom;
             // プレイヤーの移動先から、さらに2を移動させる
             bool success = MoveNumber(2, moveTo, moveTo + velocity);
             // 箱の移動が失敗したらプレイヤーの移動も失敗させる
             if (!success)
             {
                 return false;
             }
         }
         map[moveTo] = number;
         map[moveFrom] = 0;
         return true;
     }*/
    // Start is called before the first frame update
    void Start()
    {
        /*GameObject instance = Instantiate(
            playerPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity
            );*/
        // 配列の実態の作成と初期化
        map = new int[,]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
        };
        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
        // PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (Input.GetKeyDown(KeyCode.RightArrow))
          {
              // 見つからなかった時のために-1で初期化
              int playerIndex = GetPlayerIndex();
              MoveNumber(1, playerIndex, playerIndex + 1);
              PrintArray();
          }
          if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
              // 見つからなかった時のために-1で初期化
              int playerIndex = GetPlayerIndex();

              MoveNumber(1, playerIndex, playerIndex - 1);
              PrintArray();
          }*/
    }
}
