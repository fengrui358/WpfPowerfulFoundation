using System.Threading.Tasks;
using FrHello.NetLib.Core.Mvx;
using Models;
using MvvmCross.Commands;

namespace Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public TestModel TestModel { get; private set; }

        public MvxCommand GetInput1Command { get; private set; }

        /// <summary>
        /// 数据变化会自动改变
        /// </summary>
        public bool IsChanged { get; set; }

        public FirstViewModel()
        {
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                TestModel = new TestModel();
            });

            
            GetInput1Command = new MvxCommand(GetInput1CommandHandler, () => TestModel != null);
        }

        private void GetInput1CommandHandler()
        {
            var x = TestModel.Input1;
        }
    }
}
