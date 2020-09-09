using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{


    public float speed = 50f;
    public Transform player;
    public Vector2 target;
    Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        // target = new Vector2(player.position.x, player.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


        if (Input.GetMouseButtonDown(0))
            clicked();
    }


    void clicked()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
   Input.mousePosition.y, Camera.main.nearClipPlane));

        Debug.Log("Pressed primary button.");
        Debug.Log(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Debug.Log(worldPosition.x);
        target.x = worldPosition.x;
        target.y = worldPosition.y;
    }
}
