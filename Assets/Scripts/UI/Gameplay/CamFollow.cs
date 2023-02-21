using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    Transform player;
    Vector2 mb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.Player.transform;
        mb = new Vector2(GameManager.Instance.cameraSize.x - 4f, GameManager.Instance.cameraSize.y - 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, mb.x, -mb.x), Mathf.Clamp(player.position.y, mb.y, -mb.y), transform.position.z);
    }
}
