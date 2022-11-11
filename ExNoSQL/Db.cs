using System.IO;
using System.Text;
using System.Text.Json;

namespace ExNoSQL
{
    public static class Db<T> where T : Context, new()
    {
        public static T Context { get; set; }

        public static void Import()
        {
            Context = new T();
            
            bool isFileExist = File.Exists(Context.GetPath());

            if (!isFileExist) return;

            string fileText = File.ReadAllText(Context.GetPath(), Encoding.UTF8);
            Context = JsonSerializer.Deserialize<T>(fileText);
            if (Context != null) return;
            Context = new T();
        }

        public static void Export()
        {
            File.WriteAllText(Context.GetPath(), JsonSerializer.Serialize(Context));
        }
    }
}
