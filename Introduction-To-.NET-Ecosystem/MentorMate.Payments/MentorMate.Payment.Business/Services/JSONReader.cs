namespace MentorMate.Payment.Business.Services
{
    public static class JSONReader
    {
        public static string ReadJsonFile(string sourcePath)
        {
            try
            {
                var jsonString = File.ReadAllText(sourcePath);
                return jsonString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
    }
}
