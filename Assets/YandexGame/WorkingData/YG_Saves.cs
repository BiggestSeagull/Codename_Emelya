using UnityEngine;
using YG;

public class YG_Saves : MonoBehaviour
{
    private static YG_Saves instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Load there
    public static bool[] LoadBalalaika()
    {
        return YandexGame.savesData.balalaikaTiles;
    }
    public static bool[] LoadBroomstick()
    {
        return YandexGame.savesData.broomstickTiles;
    }
    public static bool[] LoadDoor()
    {
        return YandexGame.savesData.doorTiles;
    }
    public static bool[] LoadHandkerchief()
    {
        return YandexGame.savesData.handkerchiefTiles;
    }
    public static bool[] LoadHolder()
    {
        return YandexGame.savesData.holderTiles;
    }
    public static bool[] LoadLedder()
    {
        return YandexGame.savesData.ledderTiles;
    }
    public static bool[] LoadRug()
    {
        return YandexGame.savesData.rugTiles;
    }

    // Save there
    public static void SaveBalalaika(bool[] valueToSave)
    {
        YandexGame.savesData.balalaikaTiles = valueToSave;
        SaveProgress();
    }
    public static void SaveBroomstick(bool[] valueToSave)
    {
        YandexGame.savesData.broomstickTiles = valueToSave;
        SaveProgress();
    }
    public static void SaveDoor(bool[] valueToSave)
    {
        YandexGame.savesData.doorTiles = valueToSave;
        SaveProgress();
    }
    public static void SaveHandkerchief(bool[] valueToSave)
    {
        YandexGame.savesData.handkerchiefTiles = valueToSave;
        SaveProgress();
    }
    public static void SaveHolder(bool[] valueToSave)
    {
        YandexGame.savesData.holderTiles = valueToSave;
        SaveProgress();
    }
    public static void SaveLedder(bool[] valueToSave)
    {
        YandexGame.savesData.ledderTiles = valueToSave;
        SaveProgress();
    }
    public static void SaveRug(bool[] valueToSave)
    {
        YandexGame.savesData.rugTiles = valueToSave;
        SaveProgress();
    }


    public static void SaveProgress()
    {
        YandexGame.SaveProgress();
    }
}
