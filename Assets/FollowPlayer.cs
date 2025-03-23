using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;


    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;
        transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y + 1f, PlayerPosition.z);
    }
}
