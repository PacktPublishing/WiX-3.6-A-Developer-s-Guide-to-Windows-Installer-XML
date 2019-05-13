using CustomBA.ViewModels;
using System.Windows;

namespace CustomBA.Views
{
    /// <summary>
    /// Interaction logic for InstallView.xaml
    /// </summary>
    public partial class InstallView : Window
    {
        public InstallView(InstallViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;

            this.Closed += (sender, e) => viewModel.CancelCommand.Execute(this); 
        }
    }
}
