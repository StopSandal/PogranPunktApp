using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    public class ClassProperyListLayout<T> : StackLayout
    {
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<T>), typeof(ClassProperyListLayout<T>), null, propertyChanged: OnItemsSourceChanged);
        public static readonly BindableProperty ItemsOrientationProperty =
            BindableProperty.Create(nameof(ItemOrientation), typeof(StackOrientation), typeof(ClassProperyListLayout<T>), null, propertyChanged: OnItemOrientationChanged);

        public StackOrientation ItemOrientation
        {
            get { return (StackOrientation)GetValue(ItemsOrientationProperty); }
            set { SetValue(ItemsOrientationProperty, value); }
        }

        public IEnumerable<T> ItemsSource
        {
            get { return (IEnumerable<T>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }


        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var stackLayout = (ClassProperyListLayout<T>)bindable;
            stackLayout.GenerateItems();
        }
        private static void OnItemOrientationChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var stackLayout = (ClassProperyListLayout<T>)bindable;
            stackLayout.GenerateItems();
        }
        private void GenerateItems()
        {
            Children.Clear();
            Margin = new Thickness(5);

            if (ItemsSource != null)
            {
                foreach (var item in ItemsSource)
                {
                    StackLayout stackLayoutItems = new StackLayout { HorizontalOptions = LayoutOptions.FillAndExpand, Orientation = ItemOrientation };

                    foreach (var property in typeof(T).GetProperties())
                    {
                        var displayNameAttribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute;
                        var displayName = displayNameAttribute != null ? displayNameAttribute.DisplayName : property.Name;

                        StackLayout stackLayout = new StackLayout { HorizontalOptions = LayoutOptions.FillAndExpand, Orientation=StackOrientation.Vertical };
                        stackLayout.Children.Add(new Label { Text = displayName, FontSize=18,FontAttributes=FontAttributes.Bold,TextColor= (Color)Application.Current.Resources["TextContrastColor"] });
                        stackLayout.Children.Add(new Label { Text = property.GetValue(item)?.ToString() ?? "N/A", TextColor = (Color)Application.Current.Resources["TextContrastColor"],Margin=new Thickness(0,0,0,5) });

                        stackLayoutItems.Children.Add(stackLayout);
                    }
                    Children.Add(stackLayoutItems);
                }
            }
        }
    }
}
