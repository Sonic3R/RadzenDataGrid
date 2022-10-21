using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using Radzen.Blazor;

namespace BlazorApp1.Client
{
    public abstract class InlineComponentBase<TItem> : ComponentBase where TItem : class
    {
        protected List<TItem> _items;
        protected EditForm _editForm;
        protected abstract TItem _selectedItem { get; }
        protected RadzenDataGrid<TItem> _grid;
        protected int _totalItems;
        protected int _page;
        protected readonly int _pageSize = 20;
        protected int _pageNumber = 1;
        protected bool _isLoading;

        protected abstract Task LoadDataAsync();

        protected virtual async Task LoadData(LoadDataArgs args)
        {
            _isLoading = true;

            try
            {
                await LoadDataAsync();
                _totalItems = _items.Count;
            }
            finally
            {
                _isLoading = false;
            }
        }

        protected virtual Task EditRow(TItem item)
        {
            return _grid.EditRow(item);
        }

        protected Task SaveRow(TItem item)
        {
            return _grid.UpdateRow(item);
        }

        protected void CancelEdit(TItem item)
        {
            _grid.CancelEditRow(item);
        }
    }
}
