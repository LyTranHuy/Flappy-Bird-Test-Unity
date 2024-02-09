using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float moveSpeed;

    public float oldPosition;
    public float minY;
    public float maxY;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 6;
        obj = gameObject;
        oldPosition = 10;
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(moveSpeed * -1 * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GenerateWall();
       
    }

    void GenerateWall()
    {
        obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
    }

}
