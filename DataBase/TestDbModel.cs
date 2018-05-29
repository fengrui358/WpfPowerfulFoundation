using MvvmCross.ViewModels;

namespace DataBase
{
    public class TestDbModel : MvxNotifyPropertyChanged
    {
        public virtual string TestDbProperty1 { get; set; } = "DB1";

        public virtual string TestDbProperty2 { get; set; } = "DB2";
    }
}
