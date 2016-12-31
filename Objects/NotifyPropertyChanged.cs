using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Expense_Tracker
{
    /// <summary>
    /// Default DMC implementation of the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged, IDisposable
    {

        /// <summary>
        /// Sets a property to a new value and fires the PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="sender">The Caller.</param>
        /// <param name="handler">The event.</param>
        /// <param name="original">The original property value.</param>
        /// <param name="value">The new value.</param>
        /// <param name="property">The name of the property being changed.</param>
        /// <returns>Returns <c>true</c> if the property is set and the property changed event fires. Returns <c>false</c> if <paramref name="original"/> equals <paramref name="value"/>.</returns>
        public static bool SetProperty<T>(INotifyPropertyChanged sender, PropertyChangedEventHandler handler, ref T original, T value, [CallerMemberName] string property = null)
        {
            if (NotifyPropertyChanged.AreValuesEqual(original, value))
            {
                return false;
            }
            else
            {
                original = value;
// ReSharper disable ExplicitCallerInfoArgument
                EventHelper.FireEvent(sender, handler, property);
// ReSharper restore ExplicitCallerInfoArgument
                return true;
            }
        }

        /// <summary>
        /// Check if the two values are equal.
        /// </summary>
        /// <typeparam name="T">Type of value being compared</typeparam>
        /// <param name="original">The original value.</param>
        /// <param name="value">The new value.</param>
        /// <returns>Returns <c>true</c> if the two values are equal and <c>false</c> if they are not.</returns>
        private static bool AreValuesEqual<T>(T original, T value)
        {
            if (Object.Equals(original, null) && Object.Equals(value, null))
            {
                // Both objects are null
                return true;
            }
            else if (Object.Equals(original, null) || Object.Equals(value, null))
            {
                // One object is null and other is not
                return false;
            }
            else if (Object.Equals(original, value))
            {
                // Objects are same reference
                return true;
            }
            else
            {
                // Value equality
                return original.Equals(value);
            }
        }

        /// <summary>
        /// Sets a property to a new value and fires the PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="original">The original property value.</param>
        /// <param name="value">The new value.</param>
        /// <param name="property">The name of the property being changed.</param>
        /// <returns>Returns <c>true</c> if the property is set and the property changed event fires. Returns <c>false</c> if <paramref name="original"/> equals <paramref name="value"/>.</returns>
        protected bool SetProperty<T>(ref T original, T value, [CallerMemberName] string property = null)
        {
            // ReSharper disable ExplicitCallerInfoArgument
            return NotifyPropertyChanged.SetProperty(this, this.PropertyChanged, ref original, value, property);
            // ReSharper restore ExplicitCallerInfoArgument
        }

        /// <summary>
        /// Fires the property changed event for the <paramref name="property"/>.
        /// </summary>
        /// <param name="property">The name of the property being changed.</param>
        /// <returns>Returns <c>true</c> if the event is fired successfully. Otherwise returns <c>false</c>.</returns>
        protected bool FirePropertyChanged([CallerMemberName] string property = null)
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            return NotifyPropertyChanged.FireNotifyPropertyChanged(this, this.PropertyChanged, property);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Unsubscribe external property subscriptions
            this.PropertyChanged = null;

            this.OnDisposed();
        }

        /// <summary>
        /// Called when [disposed].
        /// </summary>
        protected virtual void OnDisposed()
        {
        }

        /// <summary>
        /// Fires the notify property changed event for the <paramref name="property"/>.
        /// </summary>
        /// <param name="sender">The caller.</param>
        /// <param name="handler">The event.</param>
        /// <param name="property">The name of the property being changed.</param>
        /// <returns>Returns <c>true</c> if the event is fired successfully. Otherwise returns <c>false</c>.</returns>
        public static bool FireNotifyPropertyChanged(INotifyPropertyChanged sender, PropertyChangedEventHandler handler, [CallerMemberName] string property = null)
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            return EventHelper.FireEvent(sender, handler, property);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}