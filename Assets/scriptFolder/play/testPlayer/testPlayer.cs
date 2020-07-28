using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    //判定
    public bool MovMode = true;

    //付属オブジェクト
    public Camera FPCamera;
    public Camera TPCamera;

    //変数
    public float speed = 0.2f;

    public float rotetoY = 90;
    public float rotetoYReset = 90;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, rotetoY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Mov();
        if (Input.GetKey(KeyCode.Alpha1))//モード切替え
        {
            MovMode = true;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            MovMode = false;
        }

        if (MovMode == true)//物を投げたり移動するとき(特殊能力は使えない)
        {
            FPCamera.gameObject.SetActive(true);
            TPCamera.gameObject.SetActive(false);
            
        }
        if (MovMode == false)//特殊能力を見る時(物を投げたり移動出来ない)
        {
            TPCamera.gameObject.SetActive(true);
            FPCamera.gameObject.SetActive(false);
        }
    }
    public void Mov()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.z < 14.7f)//前移動
        {
            Vector3 mov = Quaternion.Euler(0, rotetoY, 0) * Vector3.forward * speed;
            transform.position += mov;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.z > -14.9f)//後ろ移動
        {
            Vector3 mov = Quaternion.Euler(0, rotetoY, 0) * Vector3.back * speed;
            transform.position += mov;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -19.8f)//左移動
        {
            Vector3 mov = Quaternion.Euler(0, rotetoY, 0) * Vector3.left * speed;
            transform.position += mov;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 19.7f)//右移動
        {
            Vector3 mov = Quaternion.Euler(0, rotetoY, 0) * Vector3.right * speed;
            transform.position += mov;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rotetoY += 2;
            transform.rotation = Quaternion.Euler(0, rotetoY, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotetoY -= 2;
            transform.rotation = Quaternion.Euler(0, rotetoY, 0);
        }
    }
}
