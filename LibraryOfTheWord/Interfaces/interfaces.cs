namespace LibraryOfTheWorld.Interfaces
{
    public interface IuserDataHandlerJson
    {
        void SaveDataJson<T>(List<T> data, string fileName);
        List<T> LoadDataJson<T>(string fileName);
    }
}

