
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        #region Puzzles
        // Balalaika
        public bool[] balalaikaTiles = new bool[6];

        // Broomstick
        public bool[] broomstickTiles = new bool[6];


        // Door
        public bool[] doorTiles = new bool[6];


        // Handkerchief
        public bool[] handkerchiefTiles = new bool[6];


        // Holder
        public bool[] holderTiles = new bool[6];


        // Ledder
        public bool[] ledderTiles = new bool[6];


        // Rug
        public bool[] rugTiles = new bool[6];

        #endregion



        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
