using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace CheckBox.Controls
{
	public class CustomCheckbox : View
	{
		public event EventHandler OnCheckChanged;

		public static BindableProperty CheckedCommandProperty = BindableProperty.Create(nameof(CheckedCommand), typeof(ICommand), typeof(CustomCheckbox), null);
		public static BindableProperty CheckedCommandParameterProperty = BindableProperty.Create(nameof(CheckedCommandParameter), typeof(object), typeof(CustomCheckbox), null);
		public static BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CustomCheckbox), false, BindingMode.TwoWay);
		public static BindableProperty CheckColorProperty = BindableProperty.Create(nameof(CheckColor), typeof(Color), typeof(CustomCheckbox), Color.Black);
		public static BindableProperty SizeRequestProperty = BindableProperty.Create(nameof(SizeRequest), typeof(double), typeof(CustomCheckbox), (double)28);
		public static BindableProperty OutlineColorProperty = BindableProperty.Create(nameof(OutlineColor), typeof(Color), typeof(CustomCheckbox), Color.Black);
		public static BindableProperty InnerColorProperty = BindableProperty.Create(nameof(InnerColor), typeof(Color), typeof(CustomCheckbox), Color.White);
		public static BindableProperty CheckedOutlineColorProperty = BindableProperty.Create(nameof(CheckedOutlineColor), typeof(Color), typeof(CustomCheckbox), Color.Black);
		public static BindableProperty CheckedInnerColorProperty = BindableProperty.Create(nameof(CheckedInnerColor), typeof(Color), typeof(CustomCheckbox), Color.White);

		public ICommand CheckedCommand
		{
			get
			{
				return (ICommand)GetValue(CheckedCommandProperty);
			}
			set
			{
				SetValue(CheckedCommandProperty, value);
			}
		}

		public object CheckedCommandParameter
		{
			get
			{
				return GetValue(CheckedCommandParameterProperty);
			}
			set
			{
				SetValue(CheckedCommandParameterProperty, value);
			}
		}

		public bool IsChecked
		{
			get
			{
				return (bool)GetValue(IsCheckedProperty);
			}
			set
			{
				SetValue(IsCheckedProperty, value);
			}
		}

		public Color CheckColor
		{
			get
			{
				return (Color)GetValue(CheckColorProperty);
			}
			set
			{
				SetValue(CheckColorProperty, value);
			}
		}

		public Color OutlineColor
		{
			get
			{
				return (Color)GetValue(OutlineColorProperty);
			}
			set
			{
				SetValue(OutlineColorProperty, value);
			}
		}

		public Color InnerColor
		{
			get
			{
				return (Color)GetValue(InnerColorProperty);
			}
			set
			{
				SetValue(InnerColorProperty, value);
			}
		}

		public Color CheckedInnerColor
		{
			get
			{
				return (Color)GetValue(CheckedInnerColorProperty);
			}
			set
			{
				SetValue(CheckedInnerColorProperty, value);
			}
		}

		public Color CheckedOutlineColor
		{
			get
			{
				return (Color)GetValue(CheckedOutlineColorProperty);
			}
			set
			{
				SetValue(CheckedOutlineColorProperty, value);
			}
		}

		public double SizeRequest
		{
			get
			{
				return (double)GetValue(SizeRequestProperty);
			}
			set
			{
				SetValue(SizeRequestProperty, value);
			}
		}

		public void FireCheckChange()
		{
			OnCheckChanged?.Invoke(this, new CheckChangedArgs
			{
				IsChecked = IsChecked
			});
		}

		public class CheckChangedArgs : EventArgs
		{
			public bool IsChecked { get; set; }
		}

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == nameof(SizeRequest))
			{
				WidthRequest = SizeRequest;
				HeightRequest = SizeRequest;
			}
		}
	}
}
