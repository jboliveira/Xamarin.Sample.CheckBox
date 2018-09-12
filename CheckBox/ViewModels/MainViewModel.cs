using System.Windows.Input;
using CheckBox.ViewModels.Base;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace CheckBox.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private bool _useExistingAddress;

		public bool UseExistingAddress
		{
			get
			{
				return _useExistingAddress;
			}

			set
			{
				_useExistingAddress = value;
				RaisePropertyChanged(() => UseExistingAddress);
				CheckCommand.Execute(null);
			}
		}

		public ICommand CheckCommand => new Command(async () => await Check());

		public async Task Check()
		{
			var message = UseExistingAddress ? "Using existing address." : "Not Using existing address.";
			var task = Application.Current?.MainPage?.DisplayAlert("CheckBox", message, "OK");

			if (task == null)
				return;

			await task;
		}
	}
}
