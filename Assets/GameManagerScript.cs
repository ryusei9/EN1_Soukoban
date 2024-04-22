using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject boxprefab;
    // �z��̐錾
    int[,] map;
    GameObject[,] field;

    /* void PrintArray()
     {
         string debugText = "";
         for (int i = 0; i < map.Length; i++)
         {
             // �ύX�B������Ɍ������Ă���
             debugText += map[i].ToString() + ",";
         }
         Debug.Log(debugText);
     }*/
    // int�^����Vector2Int�^�ɕύX
    Vector2Int GetPlayerIndex()
    {
        // map����field�ɕς��ē񎟌��z��ɑΉ�������
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                // null�`�F�b�N������null�Ȃ�continue���g��
                if (field[y, x] == null) { continue; }
                // ���[�v�𑱂���Bnull�łȂ�������tag�`�F�b�N
                // �Q�����z��̂��ꂼ��̃C���f�b�N�X��Vector2Int�^�ŕԂ�
                if (field[y, x].tag == "Player") { return new Vector2Int(x, y); }
            }
        }
        // x,y���ꂼ���-1����ꂽVector2Int�^�̒l��Ԃ�
        return new Vector2Int(-1, -1);
    }
    // moveFrom�����moveTo��Vector2Int�^�Ŏ󂯎��
    bool MoveNumber(string tag, Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0))
        {
            // �����Ȃ��������ɏ����A���^�[��
            return false;
        }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1))
        {
            // �����Ȃ��������ɏ����A���^�[��
            return false;
        }
        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            // �ǂ̕����ֈړ����邩���Z�o
            Vector2Int velocity = moveTo - moveFrom;
            // �v���C���[�̈ړ��悩��A�����Box���ړ�������
            bool success = MoveNumber(tag, moveTo, moveTo + velocity);
            // ���̈ړ������s������v���C���[�̈ړ������s������
            if (!success)
            {
                return false;
            }
        }
        // GameObject�̍��W(position)���ړ������Ă���C���f�b�N�X�̓���ւ�
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {

        // �z��̎��Ԃ̍쐬�Ə�����
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

            // ���\�b�h�������������g�p
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber("Player", playerIndex, playerIndex + new Vector2Int(1, 0));
            //PrintArray();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // ���\�b�h�������������g�p
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber("Player", playerIndex, playerIndex + new Vector2Int(-1, 0));
            //PrintArray();
        }
    }
}
