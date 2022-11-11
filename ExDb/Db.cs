using System;
using System.IO;
using System.Text;
using System.Text.Json;
using ExNoSQL;

namespace ExDb
{
    public static class Db<T> where T : Context, new()
    {
        public static T Context { get; private set; }

        public static void Import()
        {
            Context = Activator.CreateInstance<T>();

            if (!File.Exists(Context.FilePath)) return;

            string fileText = File.ReadAllText(Context.FilePath, Encoding.UTF8);
            Context = JsonSerializer.Deserialize<T>(fileText);
        }

        public static void Export()
        {
            File.WriteAllText(Context.FilePath, JsonSerializer.Serialize(Context));
        }
    }
}
