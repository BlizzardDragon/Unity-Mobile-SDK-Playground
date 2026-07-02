using System.Threading.Tasks;
using Firebase.RemoteConfig;
using UnityEngine;

namespace _project.Scripts.Services.Firebase
{
    public class FirebaseRemoteConfigService
    {
        public async Task Fetch()
        {
            await FirebaseRemoteConfig.DefaultInstance.FetchAsync(System.TimeSpan.Zero);
            await FirebaseRemoteConfig.DefaultInstance.ActivateAsync();

            Debug.Log("Remote Config fetched");
        }

        public string GetString(string key, string defaultValue = "")
        {
            return FirebaseRemoteConfig.DefaultInstance.GetValue(key).StringValue;
        }
    }
}