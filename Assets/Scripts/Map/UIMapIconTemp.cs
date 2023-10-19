using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class UIMapIconTemp : MonoBehaviour
{
    Location locationInfo;
    public GameObject Seleted;
    public GameObject Seletable;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OpenMap);
    }

    private void Update()
    {
        Location location = MapManager.Instance.CurrentLocation;

        if (location == locationInfo)
        {
            Seleted.SetActive(true);
            Seletable.SetActive(false);
        }
        else if (MapManager.Instance.selectablePos.Contains(locationInfo.LocationPos))
        {
            Seleted.SetActive(false);
            Seletable.SetActive(true);
        }
        else
        {

            Seleted.SetActive(false);
            Seletable.SetActive(false);
        }     

    }

    public void Init(Location location)
    {
        locationInfo = location;
    }
    private void OpenMap()
    {
        if (!MapManager.Instance.selectablePos.Contains(locationInfo.LocationPos))
        {
            return;
        }
        if (SceneManager.GetActiveScene().name == "Lobby Scene")
        {
            SceneManager.sceneLoaded += WaitSceneLoad;
            SceneManager.LoadScene("Game Scene");
        }
        else
        {
            MapManager.Instance.EnterMap(locationInfo.LocationPos);
            transform.parent.parent.gameObject.SetActive(false);
        }
    }

    public void WaitSceneLoad(Scene scene, LoadSceneMode mode)
    {
        OpenMap();
        SceneManager.sceneLoaded -= WaitSceneLoad;
    }
}
