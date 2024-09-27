using System.Threading.Tasks;
using Unity.Services.RemoteConfig;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class RemoteConfigExample : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public static RemoteConfigExample Instance;

    public float jumpForce;
    public float playerSpeed;
    public string enemyName;
    public int actualLife;
    public string playerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    async Task InitializeRemoteConfigAsync()
    {
        // Initialize Unity Services
        await UnityServices.InitializeAsync();

        // Authentication is required for Remote Config
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }

    async Task Start()
    {
        if (Utilities.CheckForInternetConnection())
        {
            await InitializeRemoteConfigAsync();
        }

        RemoteConfigService.Instance.FetchCompleted += ApplyRemoteSettings;
        RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
    }

    void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        Debug.Log("RemoteConfigService.Instance.appConfig fetched: " + RemoteConfigService.Instance.appConfig.config.ToString());

        jumpForce = RemoteConfigService.Instance.appConfig.GetFloat("JumpForce");
        playerSpeed = RemoteConfigService.Instance.appConfig.GetFloat("PlayerSpeed");
        enemyName = RemoteConfigService.Instance.appConfig.GetString("EnemyName");
        playerName = RemoteConfigService.Instance.appConfig.GetString("PlayerName");
        actualLife = RemoteConfigService.Instance.appConfig.GetInt("ActualLife");

        // Actualizar los valores del Player con las configuraciones remotas
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.Actuallife = actualLife;
            player.speed = playerSpeed;
        }
    }
}
