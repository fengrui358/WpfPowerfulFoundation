using FrHello.NetLib.Core.Mvx;
using Models;

namespace Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public TestModel TestModel { get; private set; }

        public FirstViewModel()
        {
            TestModel = new TestModel();
        }
    }
}
