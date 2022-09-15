namespace R4iny.Desk.Library.Test
{
    [TestClass]
    public class TestTest
    {
        private static readonly string MaterialRoot = Path.Combine(Directory.GetCurrentDirectory(), Config.MaterialFolder);

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            // Delete materials
            if (Directory.Exists(TestTest.MaterialRoot))
            {
                Directory.Delete(TestTest.MaterialRoot, true);
            }
        }

        [TestMethod]
        public void Init()
        {
            string materialPath = Path.Combine(TestTest.MaterialRoot, nameof(TestTest.Init));
            Directory.CreateDirectory(materialPath);

            string content = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");

            Console.WriteLine($"{nameof(TestTest.Init)}:\n\tUTC Time -> {content}");
            File.WriteAllText(Path.Combine(materialPath, "now.txt"), content);
        }
    }
}
