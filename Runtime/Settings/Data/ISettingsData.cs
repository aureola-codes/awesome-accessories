namespace Aureola.Settings
{
    public interface ISettingsData
    {
        public ISettingsData FromJson(string jsonString);
    }
}
