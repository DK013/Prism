using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Prism.Modularity
{
    public sealed class ModuleCatalogItemCollection : Collection<IModuleCatalogItem>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected override void InsertItem(int index, IModuleCatalogItem item)
        {
            base.InsertItem(index, item);

            this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        protected void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs eventArgs)
        {
            this.CollectionChanged?.Invoke(this, eventArgs);
        }
    }
}
