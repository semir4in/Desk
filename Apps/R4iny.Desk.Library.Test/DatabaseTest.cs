using R4iny.Desk.Library.Data;

namespace R4iny.Desk.Library.Test
{
    [TestClass]
    public class DatabaseTest
    {
        private static readonly string MaterialPath = Path.Combine(Directory.GetCurrentDirectory(), Config.MaterialFolder, nameof(DatabaseTest));

        [TestMethod]
        public void Init()
        {
            Database db = new Database()
            {
                DatabasePath = "SOME_WHERE_OVER_THE_RAINBOW",
                RootPath = "SOME_WHERE_OVER_THE_R4444444INBOW",
            };

            Assert.IsNotNull(db);
            Assert.IsTrue(db.RootPath.Length > 0);
            Assert.IsTrue(db.DatabasePath.Length > 0);
        }

        [TestMethod]
        public void Save()
        {
            string materialPath = Path.Combine(DatabaseTest.MaterialPath, nameof(DatabaseTest.Save));
            Directory.CreateDirectory(materialPath);

            // Save linker database
            string databasePath = Path.Combine(materialPath, "db.json");
            Database db = new Database()
            {
                DatabasePath = databasePath,
                RootPath = "SOME_WHERE_OVER_THE_RAINBOW",
            };

            Assert.AreEqual(db.Save(), 0);
            Assert.IsTrue(File.Exists(databasePath));

            string serialized = File.ReadAllText(databasePath);
            Console.WriteLine($"serialized:\n{serialized}");

            // Check clear-removal
            Directory.Delete(materialPath, true);
            Assert.IsFalse(File.Exists(databasePath));
        }

        [TestMethod]
        public void AddEntry()
        {
            string materialPath = Path.Combine(DatabaseTest.MaterialPath, nameof(DatabaseTest.AddEntry));
            if (Directory.Exists(materialPath)) Directory.Delete(materialPath, true);
            Directory.CreateDirectory(materialPath);

            // Save linker database
            string databasePath = Path.Combine(materialPath, "db.json");
            Database db = new Database()
            {
                DatabasePath = databasePath,
                RootPath = "SOME_WHERE_OVER_THE_R4444444INBOW",
            };

            db.AddEntry(new Entry("Name 1"));
            db.AddEntry(new Entry("Name 2"));

            Assert.AreEqual(db.Save(), 0);
            Assert.IsTrue(File.Exists(databasePath));

            Console.WriteLine($"{nameof(db)}:\n{db.ToString(true)}");

            Directory.Delete(materialPath, true);
            Assert.IsTrue(!Directory.Exists(materialPath));
        }
    }
}