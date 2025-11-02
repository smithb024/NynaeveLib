namespace NynaeveLib.Json
{
    using Newtonsoft.Json;
    using System;
    using System.IO;

    /// <summary>
    /// Static class which reads and writes to a Json file. 
    /// </summary>
    /// <remarks>
    /// Ensure that the Newtonsoft Json dll library is available.
    /// </remarks>
    public static class JsonFileIo
    {
        /// <summary>
        /// Deserialise a class from a JSON file.
        /// </summary>
        /// <typeparam name="T">Root class</typeparam>
        /// <param name="fileName">Filename (including path) of the file to read.</param>
        /// <returns>deserialised file</returns>
        public static T ReadJson<T>(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader file = File.OpenText(fileName))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.NullValueHandling = NullValueHandling.Ignore;
                        T output = (T)serializer.Deserialize(file, typeof(T));
                        return output;
                    }
                }

                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: {fileName} doesn't exist",
                        new Exception());
                throw exception;
            }
            catch (UnauthorizedAccessException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: An unauthorised access error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (ArgumentNullException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: A null argument error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (ArgumentException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: An argument error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (PathTooLongException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: A path error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (DirectoryNotFoundException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: A directory error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (FileNotFoundException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: A file error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (NotSupportedException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: An unsupported error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (Exception ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Deserialisation: An error occurred during serialisation: {ex}",
                        ex);
                throw exception;
            }
        }

        /// <summary>
        /// Serialise a class to a JSON file.
        /// </summary>
        /// <typeparam name="T">Root class</typeparam>
        /// <param name="root">Root class</param>
        /// <param name="fileName">Filename (including path) of the file to read.</param>
        public static void WriteJson<T>(
          T root,
          string fileName)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.Formatting = Formatting.Indented;

                using (StreamWriter sw = new StreamWriter(fileName))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, root);
                }
            }
            catch (IOException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Serialisation: An I/O error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (ObjectDisposedException ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Serialisation: An object disposed error has occurred: {ex}",
                        ex);
                throw exception;
            }
            catch (Exception ex)
            {
                JsonException exception =
                    new JsonException(
                        $"JSON Serialisation: An error occurred during serialisation: {ex}",
                        ex);
                throw exception;
            }
        }
    }
}
