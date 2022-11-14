using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ExNoSQL
{
    public static class Db<T> where T : Context, new()
    {
        public static T Context { get; private set; }

        
        public static void CreateNewContext()
        {
            Context = Activator.CreateInstance<T>();
        }

        public static void Import()
        {
            if (!File.Exists(Context.FilePathWithoutExtension)) return;

            string fileText = File.ReadAllText(Context.FilePathWithoutExtension, Encoding.UTF8);
            Context = JsonSerializer.Deserialize<T>(fileText);
        }

        public static void Export()
        {
            File.WriteAllText($"{Context.FilePathWithoutExtension}.Save.json", JsonSerializer.Serialize(Context));
        }
    }
}
