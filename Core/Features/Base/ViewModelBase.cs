﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<TValue>(ref TValue prop, TValue value, [CallerMemberName] string propertyName = "")
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected ViewModelBase(string title) 
            => Title = title;

        public virtual async Task InitializeAsync()
            => await Task.FromResult(true);

        public virtual  async Task InitializeAsync(object parameter)
            => await Task.FromResult(true);
    }
}
