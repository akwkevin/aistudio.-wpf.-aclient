/***************************************************************************************

   Toolkit for WPF

   Copyright (C) 2007-2016 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ************************************************************************************/

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Util.Controls.Xceed;

namespace AIStudio.Wpf.DemoPage.Views.Resources
{
    /// <summary>
    /// Interaction logic for WindowModelEditor.xaml
    /// </summary>
    public partial class WindowModelEditor : UserControl
  {
    public WindowModelEditor()
    {
      InitializeComponent();

      ObservableCollection<ColorItem> alphaAvailableColors = new ObservableCollection<ColorItem>();
      foreach( ColorItem item in _titleShadowBrushColorPicker.AvailableColors )
      {
        System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb( ( byte )100, item.Color.Value.R, item.Color.Value.G, item.Color.Value.B );
        alphaAvailableColors.Add( new ColorItem( color, item.Name ) );
      }
      _titleShadowBrushColorPicker.AvailableColors = alphaAvailableColors;
    }

    #region IsStyleEnabled

    public static readonly DependencyProperty IsStyleEnabledProperty =
        DependencyProperty.Register( "IsStyleEnabled", typeof( bool ), typeof( WindowModelEditor ), new UIPropertyMetadata( false ) );

    public bool IsStyleEnabled
    {
      get { return ( bool )GetValue( IsStyleEnabledProperty ); }
      set { SetValue( IsStyleEnabledProperty, value ); }
    }

    #endregion //IsStyleEnabled
  }
}
