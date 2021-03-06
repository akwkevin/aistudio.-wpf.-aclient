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
using System.ComponentModel;
using System.Diagnostics;

namespace Xceed.Wpf.DataGrid
{
  internal abstract class ToggleColumnSortCommand : ColumnSortCommand
  {
    #region Constructor

    protected ToggleColumnSortCommand()
    {
    }

    #endregion

    #region Properties

    #region CanSort Protected Property

    protected abstract bool CanSort
    {
      get;
    }

    #endregion

    #region Columns Protected Property

    protected abstract ColumnCollection Columns
    {
      get;
    }

    #endregion

    #region DataGridContext Protected Property

    protected abstract DataGridContext DataGridContext
    {
      get;
    }

    #endregion       

    #region MaxSortLevels Protected Property

    protected abstract int MaxSortLevels
    {
      get;
    }

    #endregion

    #region SortDescriptions Protected Property

    protected abstract SortDescriptionCollection SortDescriptions
    {
      get;
    }

    #endregion

    #endregion

    #region Methods

    public bool CanExecute( ColumnBase column, bool resetSort )
    {
      return ( column != null )
          && ( this.CanExecuteCore( column, resetSort ) );
    }

    public void Execute( ColumnBase column, bool resetSort )
    {
      if( !this.CanExecute( column, resetSort ) )
        return;

      using( this.SetQueueBringIntoViewRestrictions( AutoScrollCurrentItemSourceTriggers.CollectionViewCurrentItemChanged ) )
      {
        this.ExecuteCore( column, resetSort );
      }
    }

    protected virtual bool CanExecuteCore( ColumnBase column, bool resetSort )
    {
      if( string.IsNullOrEmpty( column.FieldName ) )
        return false;

      if( !this.CanSort || !this.Columns.Contains( column ) )
        return false;

      if( column.SortDirection == SortDirection.None )
      {
        int maxSortCount = this.MaxSortLevels;

        // Cannot insert sort description since it would go beyond the max sort description count, but only if Shift key is pressed
        if( !resetSort && ( maxSortCount >= 0 ) && ( this.SortDescriptions.Count >= maxSortCount ) )
          return false;

        //When Shift key is not pressed, simply evaluate if one sort description can be added, since all others will be cleared.
        if( resetSort && maxSortCount == 0 )
          return false;
      }

      return true;
    }

    protected virtual void ExecuteCore( ColumnBase column, bool resetSort )
    {
      if( !this.ToggleColumnSort( column, resetSort ) )
        return;

      this.UpdateColumnSort();
    }

    protected virtual SortDescriptionsSyncContext GetSortDescriptionsSyncContext()
    {
      return null;
    }

    protected virtual void ValidateSynchronizationContext( SynchronizationContext synchronizationContext )
    {
    }

    protected virtual IDisposable DeferResortHelperItemsSourceCollection()
    {
      return null;
    }

    protected virtual bool TryDeferResortSourceDetailConfiguration( out IDisposable defer )
    {
      defer = null;
      return false;
    }

    protected virtual IDisposable SetQueueBringIntoViewRestrictions( AutoScrollCurrentItemSourceTriggers triggers )
    {
      return null;
    }

    protected virtual void ValidateToggleColumnSort()
    {
    }

    protected virtual void DeferRestoreStateOnLevel( Disposer disposer )
    {
    }

    protected virtual void UpdateColumnSort()
    {
      var dataGridContext = this.DataGridContext;

      if( this.DataGridContext != null )
      {
        var command = dataGridContext.UpdateColumnSortCommand;
        if( command.CanExecute() )
        {
          command.Execute();
        }
      }
    }

    protected override bool CanExecuteImpl( object parameter )
    {
      return this.CanExecute( parameter as ColumnBase, true );
    }

    protected override void ExecuteImpl( object parameter )
    {
      this.Execute( parameter as ColumnBase, true );
    }

    protected static SortDirection GetNextSortDirection( SortDirection direction )
    {
      switch( direction )
      {
        case SortDirection.Ascending:
          return SortDirection.Descending;

        case SortDirection.Descending:
          return SortDirection.None;

        default:
          return SortDirection.Ascending;
      }
    }

    protected static void DeferRestoreStateOnLevel( Disposer disposer, DataGridContext dataGridContext )
    {
      ToggleColumnSortCommand.ThrowIfNull( disposer, "disposer" );
      ToggleColumnSortCommand.ThrowIfNull( dataGridContext, "dataGridContext" );

      var parentDataGridContext = dataGridContext.ParentDataGridContext;

      // Defer the RestoreState of each DataGridContext of the same level
      // to ensure all the DataGridContext will be correctly restored once
      // all of them are completely resorted
      if( parentDataGridContext != null )
      {
        foreach( var childContext in parentDataGridContext.GetChildContexts() )
        {
          disposer.Add( childContext.DeferRestoreState(), DisposableType.DeferRestoreState );
        }
      }
    }

    #endregion

    #region Private Methods

    private static ListSortDirection Convert( SortDirection value )
    {
      if( value == SortDirection.None )
        throw new ArgumentException( "Cannot convert the value to ListSortDirection.", "value" );

      if( value == SortDirection.Descending )
        return ListSortDirection.Descending;

      return ListSortDirection.Ascending;
    }

    private bool ToggleColumnSort( ColumnBase column, bool resetSort )
    {
      ToggleColumnSortCommand.ThrowIfNull( column, "column" );

      this.ValidateToggleColumnSort();

      using( var synchronizationContext = this.StartSynchronizing( this.GetSortDescriptionsSyncContext() ) )
      {
        this.ValidateSynchronizationContext( synchronizationContext );

        using( var disposer = new Disposer() )
        {
          this.DeferRestoreStateOnLevel( disposer );

          // This will ensure that all DataGridCollectionViews mapped to the SortDescriptions collection will only refresh their sorting once!
          var sortDescriptions = this.SortDescriptions;
          disposer.Add( this.DeferResortHelper( sortDescriptions ), DisposableType.DeferResort );

          var newSortDirection = ToggleColumnSortCommand.GetNextSortDirection( column.SortDirection );
          string columnName = column.FieldName;
          int insertionIndex;

          if( ( resetSort ) &&
              ( ( column.SortIndex == -1 ) || ( sortDescriptions.Count > 1 ) ) )
          {
            insertionIndex = 0;

            if( sortDescriptions.Count > 0 )
            {
              sortDescriptions.Clear();
            }

            Debug.Assert( sortDescriptions.Count == 0 );
          }
          else
          {
            for( insertionIndex = 0; insertionIndex < sortDescriptions.Count; insertionIndex++ )
            {
              if( sortDescriptions[ insertionIndex ].PropertyName == columnName )
                break;
            }
          }

          if( insertionIndex < sortDescriptions.Count )
          {
            if( newSortDirection == SortDirection.None )
            {
              sortDescriptions.RemoveAt( insertionIndex );
            }
            else
            {
              sortDescriptions[ insertionIndex ] = new SortDescription( columnName, ToggleColumnSortCommand.Convert( newSortDirection ) );
            }
          }
          else if( newSortDirection != SortDirection.None )
          {
            sortDescriptions.Add( new SortDescription( columnName, ToggleColumnSortCommand.Convert( newSortDirection ) ) );
          }
        }
      }

      return true;
    }

    private IDisposable DeferResortHelper( SortDescriptionCollection sortDescriptions )
    {
      IDisposable defer;

      if( this.TryDeferResort( sortDescriptions, out defer ) )
        return defer;

      if( this.TryDeferResortSourceDetailConfiguration( out defer ) )
        return defer;

      return this.DeferResortHelperItemsSourceCollection();
    }

    #endregion
  }
}
