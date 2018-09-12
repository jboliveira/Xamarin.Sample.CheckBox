using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Widget;
using CheckBox.Controls;
using CheckBox.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomCheckbox), typeof(CheckboxRenderer))]
namespace CheckBox.Droid.Renderers
{
	/// <summary>
	/// Xamarin.Forms custom renderer for the Checkbox control
	/// </summary>
	public class CheckboxRenderer : ViewRenderer<CustomCheckbox, AppCompatCheckBox>, CompoundButton.IOnCheckedChangeListener
	{
		public CheckboxRenderer(Context context) 
			: base(context)
		{
		}

		/// <summary>
		/// Used for registration with dependency service to ensure it isn't linked out
		/// </summary>
		public static void Init()
		{
			// intentionally empty
		}

		/// <summary>
		/// Update element bindable property from event
		/// </summary>
		/// <param name="buttonView">Button view.</param>
		/// <param name="isChecked">If set to <c>true</c> is checked.</param>
		public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
		{
			((IViewController)Element).SetValueFromRenderer(CustomCheckbox.IsCheckedProperty, isChecked);
			Element.CheckedCommand?.Execute(Element.CheckedCommandParameter);
		}

		/// <summary>
		/// Called when the control is created or changed
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<CustomCheckbox> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					var checkBox = new AppCompatCheckBox(this.Context);

					// CheckBox displays its height from the TEXT, as well as images.
					checkBox.Text = "";
					checkBox.SetTextSize(Android.Util.ComplexUnitType.Sp, 0);

					// Set the width and height based on SizeRequest
					if (Element.SizeRequest >= 0)
					{
						checkBox.SetWidth((int)Element.SizeRequest);
						checkBox.SetHeight((int)Element.SizeRequest);
					}

					// Reset Button Drawable
					checkBox.SetButtonDrawable(null);
					// Set Background Drawable with the default CheckBox provided by Android
					checkBox.SetBackgroundDrawable(GetDefaultCheckBoxDrawable(this));

					checkBox.SetOnCheckedChangeListener(this);
					SetNativeControl(checkBox);
				}

				Control.Checked = e.NewElement.IsChecked;
			}
		}

		/// <summary>
		/// Gets the default check box drawable and set the color to the CheckColor.
		/// </summary>
		/// <returns>The default check box drawable.</returns>
		/// <param name="view">View.</param>
		private Drawable GetDefaultCheckBoxDrawable(Android.Views.View view)
		{
			TypedValue value = new TypedValue();
			view.Context.Theme.ResolveAttribute(Android.Resource.Attribute.ListChoiceIndicatorMultiple, value, true);
			var origImg = view.Context.Resources.GetDrawable(value.ResourceId);
			var porterDuffColor = new Android.Graphics.PorterDuffColorFilter(Element.CheckColor.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
			origImg.SetColorFilter(porterDuffColor);
			return origImg;
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == nameof(Element.IsChecked))
			{
				Control.Checked = Element.IsChecked;
			}
		}

		/// <summary>
		/// Sync from native control
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void CheckBoxCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			Element.IsChecked = e.IsChecked;
		}
	}
}
