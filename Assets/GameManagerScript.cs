using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    // �z��̐錾
    int[,] map;
    /* void PrintArray()
     {
         string debugText = "";
         for (int i = 0; i < map.Length; i++)
         {
             // �ύX�B������Ɍ������Ă���
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
             // �����Ȃ��������ɏ����A���^�[��
             return false;
         }
         if (map[moveTo] == 2)
         {
             // �ǂ̕����ֈړ����邩���Z�o
             int velocity = moveTo - moveFrom;
             // �v���C���[�̈ړ��悩��A�����2���ړ�������
             bool success = MoveNumber(2, moveTo, moveTo + velocity);
             // ���̈ړ������s������v���C���[�̈ړ������s������
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
        // �z��̎��Ԃ̍쐬�Ə�����
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
              // ������Ȃ��������̂��߂�-1�ŏ�����
              int playerIndex = GetPlayerIndex();
              MoveNumber(1, playerIndex, playerIndex + 1);
              PrintArray();
          }
          if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
              // ������Ȃ��������̂��߂�-1�ŏ�����
              int playerIndex = GetPlayerIndex();

              MoveNumber(1, playerIndex, playerIndex - 1);
              PrintArray();
          }*/
    }
}
