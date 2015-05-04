using butterfly.com.mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace DayOff.Model
{    
    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
    public class DayOffGroup
    {
        public DayOffType Type { get; set; }
        public int State { get; set; }
    }
    public class DateTimeConverter : BaseConverter, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string format = parameter as string;
            if (value != null)
            {
                if (!String.IsNullOrEmpty(format))
                {
                    return String.Format(culture, format, value);
                }
                else
                {
                    return value.ToString();
                }
            }
            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
    [ValueConversion(typeof(object), typeof(string))]
    public class VisibilityConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            //string format = parameter as string;
            //if (!String.IsNullOrEmpty(format))
            //{
            //    return String.Format(culture, format, value);
            //}
            //else
            //{
            //    return value.ToString();
            //}
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class DayItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ViewDataTemplate { get; set; }
        public DataTemplate EditDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            MongoDayOff dayOff = item as MongoDayOff;
            if (dayOff != null)
            {
                FrameworkElement elem = container as FrameworkElement;
                if (elem != null)
                {
                    if (!dayOff.Edit)
                    {
                        return ViewDataTemplate;
                        //ViewDataTemplate = elem.FindResource("viewDataTemplate") as DataTemplate;
                        //return ViewDataTemplate;
                    }
                    else
                    {
                        return EditDataTemplate;
                        //EditDataTemplate = elem.FindResource("editDataTemplate") as DataTemplate;
                        //return EditDataTemplate;
                    }
                }
            }
            return null;
        }
        
    }
}
