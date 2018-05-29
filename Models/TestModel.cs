using System;
using System.Threading;
using System.Threading.Tasks;
using DataBase;

namespace Models
{
    public class TestModel : TestDbModel
    {
        public string TestString { get; private set; } = "das";

        public override string TestDbProperty2 { get; set; } = "Db2";

        public TestModel()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(2000);

                    TestString = Guid.NewGuid().ToString("N");
                    TestDbProperty2 = Guid.NewGuid().ToString("N");
                    TestDbProperty1 = Guid.NewGuid().ToString("N");
                }
            });
        }
    }
}
