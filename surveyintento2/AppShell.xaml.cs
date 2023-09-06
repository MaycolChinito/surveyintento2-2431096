using surveyintento2.View;
namespace surveyintento2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(partesqlPage), typeof(partesqlPage));
        }
    }
}