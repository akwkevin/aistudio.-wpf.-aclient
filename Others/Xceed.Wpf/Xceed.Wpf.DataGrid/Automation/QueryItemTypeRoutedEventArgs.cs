/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Xceed.Wpf.DataGrid.Automation
{
  public delegate void QueryItemTypeRoutedEventHandler( object sender, QueryItemTypeRoutedEventArgs e );

  public class QueryItemTypeRoutedEventArgs : RoutedEventArgs
  {
    public QueryItemTypeRoutedEventArgs( RoutedEvent routedEvent, object source )
      : base( routedEvent, source )
    {
    }

    #region ItemType Property

    public string ItemType
    {
      get;
      set;
    }

    #endregion
  }
}
