# Xamarin.Tip - Custom CheckBox in Xamarin.Forms


#### Overview
Based on [Xamarin.Tip] – Build Your Own CheckBox in Xamarin.Forms article by [Alex Dunn] in order to solve a StackOverflow question.


#### [Problem]: Increase Checkbox Size on Xamarin Android 
> I've implemented checkboxes in my Xamarin Forms App using the following article: [Xamarin.Tip].
> The only issue I have is that I can't set the size of Android, there is a question in the comments section, however there is no solution. 
> No matter what I do the SizeRequest is always 64x64 - can anyone offer any suggestions or reason why I can't resize?
> **Asked by [markpirvine] via StackOverflow**


#### Solution - Version 1
Using the idea provided by [Alex Dunn] on his article [Xamarin.Tip], I did a few changes in order to resize the Checkbox on Android.

The main steps were:
- Add a `BindableProperty` called `SizeRequest` in the custom CheckBox control.
- Create a method `GetDefaultCheckBoxDrawable` to get the default CheckBox drawable.
- Change `OnElementChanged` method to clear the text and resize (), set the width/height based on SizeRequest, reset the button drawable and set a new Background drawable with the default checkbox drawable.

`AndroidCheckboxRenderer.cs`:
```csharp
private Drawable GetDefaultCheckBoxDrawable(Android.Views.View view)
{
    TypedValue value = new TypedValue();
    view.Context.Theme.ResolveAttribute(Android.Resource.Attribute.ListChoiceIndicatorMultiple, value, true);
    var origImg = view.Context.Resources.GetDrawable(value.ResourceId);
    var porterDuffColor = new Android.Graphics.PorterDuffColorFilter(Element.CheckColor.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
    origImg.SetColorFilter(porterDuffColor);
    return origImg;
}

protected override void OnElementChanged(ElementChangedEventArgs<CustomCheckbox> e)
{
    ...
    
    // CheckBox displays its height from the TEXT, as well as images.
    checkBox.Text = "";
    checkBox.SetTextSize(Android.Util.ComplexUnitType.Sp, 0);

    // Set the width and height based on SizeRequest
    if (Element.SizeRequest >= 0)
    {
        checkBox.SetWidth((int)Element.SizeRequest);
        checkBox.SetHeight((int)Element.SizeRequest);
    }

    // Reset the Button Drawable
    checkBox.SetButtonDrawable(null);
    // Set Background Drawable with the default CheckBox
    checkBox.SetBackgroundDrawable(GetDefaultCheckBoxDrawable(this));
    
    ...
}
```


#### Useful Links:
- [Link 1]: Android: How to change the size of CheckBox?
- [Link 2]: What does PorterDuff.Mode mean in android graphics.What does it do?


[//]: #
   [Xamarin.Tip]: <https://alexdunn.org/2018/04/10/xamarin-tip-build-your-own-checkbox-in-xamarin-forms/>
   [Alex Dunn]: <https://github.com/SuavePirate>
   [Problem]: <https://stackoverflow.com/q/52256660/10341660>
   [markpirvine]: <https://stackoverflow.com/users/219689/markpirvine>
   [Link 1]: <http://qaru.site/questions/79052/android-how-to-change-checkbox-size>
   [Link 2]: <https://stackoverflow.com/a/25654603/10341660>