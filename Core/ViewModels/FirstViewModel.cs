using FrHello.NetLib.Core.Mvx;
using Models;
using MvvmCross.Commands;

namespace Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public TestModel TestModel { get; private set; }

        public MvxCommand GetInput1Command { get; private set; }

        public FirstViewModel()
        {
            TestModel = new TestModel();

            GetInput1Command = new MvxCommand(GetInput1CommandHandler);
        }

        private void GetInput1CommandHandler()
        {
            var x = TestModel.Input1;
        }
    }
}
