using UnityEngine;
using Photon.Pun;

public class NetworkingController : MonoBehaviourPunCallbacks
{
    private const int MAX_CONNECTIONS = 100;
    private const int SERVER_IP = 100;
    private const int SERVER_PORT = 8999;
    private const int WEB_PORT = 8998;
    private const int BUFFER_SIZE = 1024;

    private int reliableChannelId;
    private int unreliableChannelId;

    private void Start()
    {

    }
}
