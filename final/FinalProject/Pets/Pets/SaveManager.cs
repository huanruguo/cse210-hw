using System.IO;
using System.Text.Json;

namespace VirtualPetProject
{
    public static class SaveManager
    {
        public static void SaveGame(GameState state)
        {
            string json = JsonSerializer.Serialize(state);
            File.WriteAllText("save.json", json);
        }
        public static GameState LoadGame()
        {
            try
            {
                string json = File.ReadAllText("save.json");
                return JsonSerializer.Deserialize<GameState>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
